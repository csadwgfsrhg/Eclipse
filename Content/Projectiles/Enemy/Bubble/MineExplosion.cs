

using Eclipse.Content.NPCs.ClamDiver;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Utilities;

namespace Eclipse.Content.Projectiles.Enemy.Bubble
{
	public class MineExplosion : ModProjectile
	{

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;
        }
        public override void SetDefaults() {
			Projectile.width = 54;
			Projectile.height = 60;
             Projectile.hostile = true;
            Projectile.friendly = false;
            Projectile.timeLeft = 28;
            Projectile.penetrate = -1;
            Projectile.aiStyle = -1;
            Projectile.tileCollide = false;

         






        }




        public override void AI()
        {
            Lighting.AddLight(Projectile.position, .6f, .3f, .2f);
            if (Projectile.ai[1] % 4 == 0)
                Projectile.frame = (int)(Projectile.ai[2] + Projectile.frame + 1) % 8;

            Projectile.ai[1]++;
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

	
