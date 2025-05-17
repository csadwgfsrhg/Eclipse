

using Eclipse.Content.NPCs.ClamDiver;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Utilities;

namespace Eclipse.Content.Projectiles.Enemy.Bubble
{
	public class ClamMine : ModProjectile
	{

  
        public override void SetDefaults() {
			Projectile.width = 44;
			Projectile.height = 44;
             Projectile.hostile = false;
            Projectile.friendly = true;
        
            Projectile.penetrate = 1;
            Projectile.aiStyle = -1;
            Projectile.tileCollide = false;

         






        }

       



        public override void OnKill(int timeLeft)
        {

         
            //crab, pirranah , jellyfish, mine, homing bolt, coral shards, clam
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
          
 
        Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center , Vector2.Zero, ModContent.ProjectileType<MineExplosion>(), 15,  10);

            for (int i = 0; i < Main.rand.Next(1, 3); i++)
            {

                Gore.NewGore(Projectile.InheritSource(Projectile), Projectile.Center, new Vector2(Main.rand.Next(-2, 2), Main.rand.Next(-3, 0)), GoreID.ChimneySmoke1, Main.rand.NextFloat(1f, 2f));
            }
            for (int i = 0; i < Main.rand.Next(6, 12); i++)
            {

                Dust.NewDust(Projectile.Center, 44, 44,  DustID.Smoke, Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-3f, 0), Main.rand.Next(255), Color.White, Main.rand.NextFloat(1f, 2f));
            }
         


        }
        public override void AI()   
        {
            Player player = Main.LocalPlayer;
            if (Projectile.position.Y > player.position.Y - 40)
                Projectile.tileCollide = true;
            if (player.Hitbox.Intersects(Projectile.Hitbox))
            {
         
                Projectile.Kill();
            }



                Projectile.rotation = Projectile.velocity.Y / 10;

          

                Projectile.velocity.Y += .5f;
          
          



        }
 
        }
        
    }

	
