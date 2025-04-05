using Eclipse.Dusts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Terraria.DataStructures;

namespace Eclipse.Common.Projectiles
{
    public class Trajectory : ModProjectile
    {
       
        int fequency = -5;
        public override void SetDefaults()
        {
            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.friendly = false;
            Projectile.timeLeft = 120;
            Projectile.penetrate = 1;
            Projectile.tileCollide = true;
            Projectile.aiStyle = 1;
            Projectile.extraUpdates = 120;
            Projectile.ignoreWater = true;
        }

      
        public override void AI()
        {
        
            Projectile.aiStyle = 1;
            fequency += 1; 

            if (fequency >= 5)
            {
                Dust.NewDust(Projectile.position, 0, 0, ModContent.DustType<BeamGlow>(), 0, 0, 255- Projectile.timeLeft * 2, newColor:(default), 1.5f) ;
                fequency = 0;


            }

        }
    }
}