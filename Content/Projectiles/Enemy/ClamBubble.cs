

using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Utilities;

namespace Eclipse.Content.Projectiles.Enemy
{
	public class ClamBubble : ModProjectile
	{
        int bubbleobject;
        public static Texture2D bubbleHeld;

        public override void SetDefaults() {
			Projectile.width = 44;
			Projectile.height = 44;
  Projectile.hostile = true;
            Projectile.friendly = false;
            Projectile.timeLeft = Main.rand.Next(270, 300);
            Projectile.penetrate = 1;
            Projectile.aiStyle = -1;
            Projectile.tileCollide = false;

         






        }

        public override void OnSpawn(IEntitySource source)
        {

            bubbleobject = Main.rand.Next(20);
         //   if (bubbleobject == 0)
          
                bubbleHeld = ModContent.Request<Texture2D>("Eclipse/Content/Projectiles/Enemy/ClamMine", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
            
           
                
             
            //     Projectile.scale = Main.rand.NextFloat(.5f, 1f);
            Projectile.Resize((int)(Projectile.width * Projectile.scale), (int)(Projectile.height * Projectile.scale));

        }



        public override void OnKill(int timeLeft)
        {
       
            Player player = Main.player[Projectile.owner];
            //crab, pirranah , jellyfish, mine, homing bolt, coral shards, clam
            SoundEngine.PlaySound(SoundID.Item54, Projectile.position);
          
            if (bubbleobject == 0) 
        Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, new Vector2(0, 1), ProjectileID.BombSkeletronPrime, 10,  1);

            if (bubbleobject == 1)
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Vector2.Normalize(player.Center - Projectile.Center) * 10, ProjectileID.DD2DarkMageBolt, 10, 1);


            if (bubbleobject == 2)
                NPC.NewNPCDirect(Projectile.GetSource_FromThis(), (int)Projectile.Center.X, (int)Projectile.Center.Y, NPCID.Piranha, Projectile.whoAmI);


            if (bubbleobject == 3)
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, new Vector2(Main.rand.Next(-5, 5), Main.rand.Next(-5, 5)), ProjectileID.GreekFire1, 10, 1);

            if (bubbleobject == 4)
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Vector2.Normalize(player.Center - Projectile.Center) , ProjectileID.DemonSickle, 10, 1);

            if (bubbleobject == 5)
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Vector2.Normalize(player.Center  - Projectile.Center) * 7 + new Vector2(Main.rand.Next(-1, 1), Main.rand.Next(-5, 0)), ProjectileID.WoodenArrowHostile, 10, 1);
            if (bubbleobject == 6)
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Vector2.Normalize(player.Center - Projectile.Center) * 4 + new Vector2(Main.rand.Next(-2, 2), Main.rand.Next(-2, 2)), ProjectileID.LostSoulHostile, 10, 1);
            if (bubbleobject == 7)
                NPC.NewNPCDirect(Projectile.GetSource_FromThis(), (int)Projectile.Center.X, (int)Projectile.Center.Y, NPCID.BlueJellyfish, Projectile.whoAmI);
            if (bubbleobject == 8)
                NPC.NewNPCDirect(Projectile.GetSource_FromThis(), (int)Projectile.Center.X, (int)Projectile.Center.Y, NPCID.Crab, Projectile.whoAmI);
            

        }
        public override void AI()   
        {
            Player player = Main.LocalPlayer;

          

            if (Projectile.timeLeft >= 240)
            {
                Projectile.velocity.Y -= Main.rand.NextFloat(.05f, .12f);
                 Projectile.velocity.Y += (float)(((player.position.Y - 500) - Projectile.position.Y) / 10000);
            }
            else
            {
               
                    Projectile.velocity.X += (float)((player.position.X - Projectile.position.X) / 2800);
                
             

             


                Projectile.velocity *= .98f;
            
              
            }
          



        }
        public override bool PreDraw(ref Color lightColor)
        {
         
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.Transform);
            Main.spriteBatch.Draw(bubbleHeld, (Projectile.Center - new Vector2(16, 16 )) - Main.screenPosition, Color.White);

            return true;
        }
        
    }

	}
