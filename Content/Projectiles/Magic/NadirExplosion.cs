using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
using Terraria.GameContent;

namespace Eclipse.Content.Projectiles.Magic
{
    public class NadirExplosion : ModProjectile
    {
        //72+2

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 7;
        }
        public override void SetDefaults()
        {
            Projectile.width = 84;
            Projectile.height = 68;
            Projectile.friendly = true;
            Projectile.aiStyle = -1;
            Projectile.timeLeft = 55;
            Projectile.frame = 0;
            Projectile.tileCollide = false;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            lightColor = Color.White;
            return true;
        }

        public override void AI()
        {
            if (Projectile.timeLeft % 5 == 0)
                Projectile.frame++;
            base.AI();
        }
    }
}
