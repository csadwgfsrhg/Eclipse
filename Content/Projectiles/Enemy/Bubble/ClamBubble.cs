

using Eclipse.Content.NPCs.ClamDiver;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Utilities;

namespace Eclipse.Content.Projectiles.Enemy.Bubble
{
	public class ClamBubble : ModProjectile
	{
        int bubbleobject;
      

        public override void SetDefaults() {
			Projectile.width = 44;
			Projectile.height = 44;
  Projectile.hostile = false;
            Projectile.friendly = false;
            Projectile.timeLeft = Main.rand.Next(270, 300);
            Projectile.penetrate = 1;
            Projectile.aiStyle = -1;
            Projectile.tileCollide = false;

         






        }

        public override void OnSpawn(IEntitySource source)
        {

            bubbleobject = Main.rand.Next(4);

            if (bubbleobject == 2)
                Projectile.velocity *= 0;


                //     if (bubbleobject == 1)
                // bubbleHeld = ModContent.Request<Texture2D>("Eclipse/Content/Enemy/ClamDiver/Clam", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;




                //   Projectile.scale = Main.rand.NextFloat(.5f, 1f);
                //Projectile.Resize((int)(Projectile.width * Projectile.scale), (int)(Projectile.height * Projectile.scale));

            }


        public override void OnKill(int timeLeft)
        {
       
            Player player = Main.player[Projectile.owner];
            //crab, pirranah , jellyfish, mine, homing bolt, coral shards, clam
            SoundEngine.PlaySound(SoundID.Item54, Projectile.position);
          
            if (bubbleobject == 0) 
        Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, new Vector2(0, 1), ModContent.ProjectileType<ClamMine>(), 10,  1);


            if (bubbleobject == 1)
                NPC.NewNPCDirect(Projectile.GetSource_FromThis(), (int)Projectile.Center.X, (int)Projectile.Center.Y, ModContent.NPCType<Clam>(), Projectile.whoAmI);

            if (bubbleobject == 3)
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Vector2.Normalize(player.position - Projectile.position) * 8  + new Vector2(Main.rand.Next(-2, 2), Main.rand.Next(-7, 0)), ModContent.ProjectileType<Coral>(), 10, 1);



        }
        public override void AI()   
        {
            Player player = Main.LocalPlayer;

            Lighting.AddLight(Projectile.position, .1f, .2f, .3f);
            if (bubbleobject != 2)
            if (Projectile.timeLeft >= 240)
            {
                Projectile.velocity.Y -= Main.rand.NextFloat(.05f, .12f);
                 Projectile.velocity.Y += (float)(((player.position.Y - 500) - Projectile.position.Y) / 10000);
                    if (bubbleobject == 1)
                        Projectile.velocity *= .97f;
            }
            else
            {
                if (bubbleobject == 0)
                    Projectile.velocity += Vector2.Normalize(player.position + new Vector2(0, -300) - Projectile.position) / 7;

                   Projectile.velocity *= .99f;
                    Projectile.velocity.Y *= .96f;


                }

            if (bubbleobject == 2)
            {
                Projectile.velocity += Vector2.Normalize(player.position - Projectile.position) / 10;
                Projectile.velocity *= .99f;
                if (player.Hitbox.Intersects(Projectile.Hitbox))
                {
                   
                    Projectile.timeLeft = 140;
                    bubbleobject = 10;
                }
            }
            if (bubbleobject == 10)
            {
                if (player.Hitbox.Intersects(Projectile.Hitbox))
                {
                    Projectile.scale = 1.5f;
                    player.position = Projectile.position + new Vector2(14, -4);
                    player.velocity = Projectile.velocity + new Vector2(0, -.5f);
                    if (Projectile.timeLeft >= 30)
                    {
                        Projectile.velocity.Y -= .15f;
                    }
                    else
                        Projectile.velocity.Y *= .95f;
                }
                else
                    Projectile.timeLeft = 0;
            }

        }
        public override bool PreDraw(ref Color lightColor)
        {
            Color drawColor = Projectile.GetAlpha(lightColor);
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.TransformationMatrix);
            if (bubbleobject == 0)
                Main.spriteBatch.Draw(ModContent.Request<Texture2D>("Eclipse/Content/Projectiles/Enemy/Bubble/ClamMine", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value, (Projectile.Center - new Vector2(18, 18)) - Main.screenPosition, null, drawColor);
            if (bubbleobject == 1)
                Main.spriteBatch.Draw(ModContent.Request<Texture2D>("Eclipse/Content/Projectiles/Enemy/Bubble/Clam", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value, (Projectile.Center - new Vector2(14, 18)) - Main.screenPosition, null, drawColor);
            if (bubbleobject == 2)
                Main.spriteBatch.Draw(ModContent.Request<Texture2D>("Eclipse/Content/Projectiles/Magic/LifeCrystalStaffHeld", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value, (Projectile.Center - new Vector2(14, 18)) - Main.screenPosition, null, drawColor);
            if (bubbleobject == 3)
                Main.spriteBatch.Draw(ModContent.Request<Texture2D>("Eclipse/Content/Projectiles/Enemy/Bubble/Coral", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value, (Projectile.Center - new Vector2(14, 18)) - Main.screenPosition, null, drawColor);
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone, null, Main.GameViewMatrix.TransformationMatrix);

            return true;
        }
        public override void PostDraw(Color lightColor)
        {
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.Transform);
        }
    }

	}
