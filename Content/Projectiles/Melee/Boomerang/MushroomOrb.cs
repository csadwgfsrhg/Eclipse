using Eclipse.Utilities.Extensions;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;

namespace Eclipse.Content.Projectiles.Melee.Boomerang;

public class MushroomOrb : ModProjectile
{
    public override void SetStaticDefaults()
    {
        Main.projFrames[Projectile.type] = 2;
        ProjectileID.Sets.TrailingMode[Type] = 3;
        ProjectileID.Sets.TrailCacheLength[Type] = 20;
    }
    public override void SetDefaults() {
     
        Projectile.friendly = false;
        Projectile.tileCollide = true;
        Projectile.usesLocalNPCImmunity = true;
        Projectile.localNPCHitCooldown = 30;
        Projectile.width = 10;
        Projectile.height = 10;
 
        Projectile.penetrate = -1;
        Projectile.aiStyle = -1;

        Projectile.timeLeft = 600;
    }

    public override bool OnTileCollide(Vector2 oldVelocity)
    {

        Projectile.velocity -= Projectile.velocity * 2;

        return false;
    }
    public override void OnSpawn(IEntitySource source)
    {
       if (Main.rand.NextBool(2))
        {
            Projectile.ai[1] = 1;
            Projectile.frame = 1;

        }
       else
        {
            Projectile.ai[1] = 0;
            Projectile.frame = 0;
        }
    }
    public override bool PreDraw(ref Color lightColor)
    {
        var texture = TextureAssets.Projectile[Type].Value;

        var effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

        var length = ProjectileID.Sets.TrailCacheLength[Type];

        for (var i = 0; i < length; i += 3)
        {

            if (Projectile.ai[1] == 0)
            {
                Main.EntitySpriteDraw(
                texture,
                Projectile.GetOldDrawPosition(i),
                Projectile.GetDrawFrame(),
                Projectile.GetAlpha(Color.Red) * (0.8f - i / (float)length),
                Projectile.rotation,
                texture.Size() / 2f + Projectile.GetDrawOriginOffset(),
                Projectile.scale,
                effects
            );
            }
            else
            {
                Main.EntitySpriteDraw(
                              texture,
                              Projectile.GetOldDrawPosition(i),
                              Projectile.GetDrawFrame(),
                              Projectile.GetAlpha(Color.Blue) * (0.8f - i / (float)length),
                              Projectile.rotation,
                              texture.Size() / 2f + Projectile.GetDrawOriginOffset(),
                              Projectile.scale,
                              effects
                                );
            }
        }

        Main.EntitySpriteDraw(
            texture,
            Projectile.GetDrawPosition(),
            Projectile.GetDrawFrame(),
            Projectile.GetAlpha(Color.White),
            Projectile.rotation,
            texture.Size() / 2f + Projectile.GetDrawOriginOffset(),
            Projectile.scale,
            effects

        );

        return false;
    }
    public override void AI() {



        Projectile.ai[0] += 1;
        Projectile.velocity *= .99f;


        if (Projectile.ai[0] >= 500)
        {
            Projectile.scale -= .01f;


        }


            var player = Main.player[Projectile.owner];
          

            Projectile.rotation = Projectile.velocity.ToRotation();

            if (Projectile.Hitbox.Intersects(player.Hitbox))
            {


            SoundEngine.PlaySound(SoundID.Item4 with { Pitch = .5f, PitchVariance = .5f, Volume = .4f }, Projectile.Center);
            Projectile.Kill();

                if (Projectile.ai[1] == 0)
                {
                player.HealEffect(5);
                player.statLife += 5;


                }
                else
                {
                player.ManaEffect(10);
                player.statMana += 10;

                }

            }
        }
    }

