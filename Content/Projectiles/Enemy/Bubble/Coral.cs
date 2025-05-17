

using Eclipse.Content.NPCs.ClamDiver;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Utilities;

namespace Eclipse.Content.Projectiles.Enemy.Bubble
{
	public class Coral : ModProjectile
	{
      
   
        public override void SetDefaults() {
			Projectile.width = 34;
			Projectile.height = 26;
             Projectile.hostile = true;
            Projectile.friendly = false;
            Projectile.timeLeft = 500;
            Projectile.penetrate = 3;
            Projectile.aiStyle = -1;
            Projectile.tileCollide = true;

         






        }
    
       
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Shatter, Projectile.position);

        }





    
        public override void AI()   
        {
            Player player = Main.LocalPlayer;
    




            Projectile.rotation += Projectile.velocity.X / 30;

          

                Projectile.velocity.Y += .3f;
          
          



        }
 
        }
        
    }

	
