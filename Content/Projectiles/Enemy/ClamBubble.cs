

using Terraria.Audio;
using Terraria.DataStructures;

namespace Eclipse.Content.Projectiles.Enemy
{
	public class ClamBubble : ModProjectile
	{

        public override void SetDefaults() {
			Projectile.width = 44;
			Projectile.height = 44;
  Projectile.hostile = true;
            Projectile.friendly = false;
            Projectile.timeLeft = 300;
            Projectile.penetrate = 1;
            Projectile.aiStyle = -1;
            Projectile.tileCollide = false;
	

			}

        public override void OnSpawn(IEntitySource source)
        {
            Projectile.scale = Main.rand.NextFloat(.5f, 1f);
            Projectile.Resize((int)(Projectile.width * Projectile.scale), (int)(Projectile.height * Projectile.scale));
        }



        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item54, Projectile.position);
          //  NPC minionNPC = NPC.NewNPCDirect(Projectile.GetSource_FromThis(), (int)Projectile.Center.X, (int)Projectile.Center.Y, NPCID.Zombie, Projectile.whoAmI);
        }
        public override void AI()   
        {
            Player player = Main.LocalPlayer;

          

            if (Projectile.timeLeft >= 240)
            {
                Projectile.velocity.Y -= .1f;

            }
            else
            {
                Projectile.velocity.X += (float)((player.position.X - Projectile.position.X) / 1200 );


                if (player.position.Y <= Projectile.position.Y)
                {
                    Projectile.velocity.Y *= 1.02f;
                }


                Projectile.velocity *= .98f;
            
              
            }
          



        }
        public override bool PreDraw(ref Color lightColor)
        {
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.Transform);
            return true;
        }
        public override void PostDraw(Color lightColor)
        {
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.Transform);
        }
    }

	}
