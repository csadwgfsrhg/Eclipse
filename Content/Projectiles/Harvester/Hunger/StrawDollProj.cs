using System.IO;
using Eclipse.Content.Classes;
using Eclipse.Utilities.Extensions;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Graphics;

namespace Eclipse.Content.Projectiles.Harvester.Hunger;

public class StrawDollProj : ModProjectile
{


    public override void SetStaticDefaults()
    {
        Main.projFrames[Projectile.type] = 4;
        ProjectileID.Sets.TrailingMode[Type] = 3;
        ProjectileID.Sets.TrailCacheLength[Type] = 20;

    }
    public sealed override void SetDefaults()
    {
        Projectile.friendly = false;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = false;
        Projectile.width = 0;
        Projectile.height = 0;
        Projectile.timeLeft = 400;


        Projectile.aiStyle = -1;
        SetStaticDefaults();

    }
    private Player Owner => Main.player[Projectile.owner];
    public sealed override void OnSpawn(IEntitySource source)
    {
        Owner.GetModPlayer<HarvestDamagePlayer>().Hunger -= 6;
        Projectile.spriteDirection = Main.MouseWorld.X > Owner.MountedCenter.X ? 1 : -1;
    }
    public override void AI()
    {
        Projectile.velocity *= .96f;
        Projectile.ai[0] += 1f;
      
        if (++Projectile.frameCounter >= 8)
        {
            Projectile.frameCounter = 0;
            if (++Projectile.frame >= Main.projFrames[Projectile.type])
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

}