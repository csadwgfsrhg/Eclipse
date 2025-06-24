


using Terraria;
using Terraria.Audio;

namespace Eclipse.Content.Items.Ranged.Ammo.Blunderbuss
{
    public class CloudInABottle : GlobalItem

    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.CloudinaBottle)
            {
                item.damage = 0;
                item.DamageType = DamageClass.Ranged;
                item.width = 8;
                item.height = 8;
            
       
                item.knockBack = 0f;

    
                item.shoot = ModContent.ProjectileType<CompressedAir>();
                item.shootSpeed = 1f;
                item.ammo = AmmoID.Sand;

            }
        }
    }
    public class CompressedAir : ModProjectile
    {

        public override void SetDefaults()
        {
   

            Projectile.penetrate = 1;
            Projectile.width = 32;
            
            Projectile.height = 32;
            Projectile.timeLeft = 30;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
        }
        bool collide = false;
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
         
          
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            if (collide == false)
            {
                Projectile.timeLeft = 1;
                Projectile.velocity *= -1;
                collide = true;
                Projectile.tileCollide = false;
            }
            return false;
        }
        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 8; i++)
            {
                Dust.NewDust(Projectile.position, 32, 32, DustID.Cloud, 0, 0, 0, newColor: (default), 1f);

            }
    
             
            
            SoundEngine.PlaySound(SoundID.DD2_BetsyFireballImpact, Projectile.position);
            foreach (var npc in Main.ActiveNPCs)
            {
                if (npc.Hitbox.Intersects(Projectile.Hitbox))
                {
                    if (npc.boss)
                    {
                        //  npc.velocity.Y += (Projectile.velocity.Y /5);
                        //  npc.velocity.X += (Projectile.velocity.X / 10);
                        npc.velocity = -npc.velocity / 4f + new Vector2(Projectile.velocity.X * .05f, Projectile.velocity.Y * .05f);
                     
                    }
                      
                    else
                    {
                        npc.AddBuff(BuffID.Featherfall, 10);
                        //   npc.velocity.Y += (Projectile.velocity.Y / 3);
                        //  npc.velocity.X += (Projectile.velocity.X / 8);
                        npc.velocity = -npc.velocity / 3 + new Vector2(Projectile.velocity.X * .8f, Projectile.velocity.Y * 1.4f);
                      //  npc.velocity = npc.velocity / 2 + Projectile.velocity * .6f;
                    }
                        

                }
            }
            foreach (var player in Main.ActivePlayers)
            {
                if (player.Hitbox.Intersects(Projectile.Hitbox) && collide )
                {
                    player.AddBuff(BuffID.Featherfall, 10);

                    //  player.velocity.Y = Projectile.velocity.Y * 1.6f; ;
                    // player.velocity.X = Projectile.velocity.X * .8f;
                    player.velocity = player.velocity / 2;
                      player.velocity +=  new Vector2(Projectile.velocity.X * .6f, Projectile.velocity.Y * 1.4f) ;
                }
            }

        }
        public override void AI()
        {


            Projectile.velocity *= .98f;
            if (Main.rand.NextBool(2))
                Dust.NewDust(Projectile.position, 6, 6, DustID.Cloud);
        }

    }



    }

   