

using Eclipse.Content.Classes;
using Eclipse.Content.Projectiles.Harvester.Hunger;
using Eclipse.Utilities.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;

namespace Eclipse.Content.Projectiles.Ranged.Bullets
{
  


    public class EagleBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {


            ProjectileID.Sets.TrailingMode[Type] = 0;
            ProjectileID.Sets.TrailCacheLength[Type] = 50;
        }
        public override void SetDefaults()
        {
            Projectile.localNPCHitCooldown = 0;
            Projectile.extraUpdates = 20;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.penetrate = 1;
            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.timeLeft = 2000;
            AIType = ProjectileID.Bullet;
            Projectile.friendly = true;

        }
        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < Main.rand.Next(5, 15); i++)
            {
                if (Projectile.ai[1] == 1)
                {
                    Dust.NewDust(Projectile.position, 10, 10, DustID.Firework_Blue);
                   
                }
                else
                {
                    Dust.NewDust(Projectile.position, 10, 10, DustID.Firework_Red);

                }
            }

        }
        public override void OnSpawn(IEntitySource source)
        {
            Projectile.velocity *= .5f;
          if (Main.rand.NextBool(2))
            {

                Projectile.ai[1] = 1;

            }
          else
            {
                Projectile.ai[1] = 0;
            }
        }
        public override void AI()
        {
         

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {

            if (Projectile.ai[1] == 1)
            {
                target.AddBuff(BuffID.Frostburn2, 120);
            }
            else
            {
                target.AddBuff(BuffID.OnFire3, 120);
            }

            
         
        }


        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;


            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(Color.Red) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            return true;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(1f, 1f, 1f);

        }

    }
}
