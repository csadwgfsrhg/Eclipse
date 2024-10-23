

namespace Eclipse.Content.Projectiles.Enemy
{
	public class ZombiePortal : ModProjectile
	{

        public override void SetDefaults() {
			Projectile.width = 30;
			Projectile.height = 40;
  
            Projectile.friendly = false;
            Projectile.timeLeft = 100;
            Projectile.penetrate = -1;
            Projectile.aiStyle = -1;
            Projectile.tileCollide = true;
			Projectile.usesLocalNPCImmunity = true;

			}

       



        public override void OnKill(int timeLeft)
        {
            NPC minionNPC = NPC.NewNPCDirect(Projectile.GetSource_FromThis(), (int)Projectile.Center.X, (int)Projectile.Center.Y, NPCID.Zombie, Projectile.whoAmI);
        }
        public override void AI()   
        {
            for (int i = 0; i < Main.rand.Next(1, 5); i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Blood);
            }



        }
        }
	}
