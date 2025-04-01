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
        int fequency = 0;
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
        }

        public override void OnSpawn(IEntitySource source)
        {
           fequency = Main.rand.Next(5);
        }
        public override void AI()
        {

            Projectile.aiStyle = 1;
            fequency += Main.rand.Next(5); 

            if (fequency >= 15)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType <BeamGlow>());
                fequency = 0;


            }

        }
    }
}