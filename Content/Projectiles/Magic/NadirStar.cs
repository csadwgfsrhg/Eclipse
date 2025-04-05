using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
using Terraria.GameContent;

namespace Eclipse.Content.Projectiles.Magic
{
    public class NadirStar : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 8;
        }
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 55;
            Projectile.aiStyle = -1;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 500;
            Projectile.rotation = -MathHelper.PiOver2;
            Projectile.scale = 2f;

        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            SoundEngine.PlaySound(SoundID.Item14);
            Projectile.NewProjectile(Projectile.GetSource_Misc("idk"), Projectile.position + Projectile.width * Vector2.UnitX / 2, Vector2.Zero, ModContent.ProjectileType<NadirExplosion>(), 0, 0);
            Projectile.Kill();
        }
        
        public override bool PreDraw(ref Color lightColor)
        {
            lightColor = Color.White;
            Rectangle frame = new Rectangle(0, (32 + 2) * Projectile.frame, 55, 33);

            Main.spriteBatch.Draw(TextureAssets.Projectile[Type].Value, Projectile.position - Main.screenPosition, frame, lightColor, Projectile.rotation, new Vector2(55, 0), Projectile.scale, SpriteEffects.None, 1f);

            return false;
        }
        public override void AI()
        {
            if (Projectile.ai[1] % 4 == 0)
                Projectile.frame = (int)(Projectile.ai[2] + Projectile.frame + 1) % 8;

            Projectile.ai[1]++;
        }
    }
}
