
using Terraria.DataStructures;

namespace Eclipse.Content.Projectiles.Harvester.Scythe
{
	public class SpiritSkull : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 4;

		}

			public override void SetDefaults() {
			Projectile.width = 22;
			Projectile.height = 24;
			Projectile.friendly = true; 
			Projectile.timeLeft = 120; 
			Projectile.penetrate = 1; 
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
			Projectile.aiStyle = -1;
        }
        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < Main.rand.Next(8, 12); i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Shadowflame);
                Lighting.AddLight(Projectile.position, .4f, .1f, .4f);
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(5))
            {
                target.AddBuff(BuffID.ShadowFlame, 40);
            }

            Player player = Main.player[Projectile.owner];
            player.statMana += 2;
            player.ManaEffect(2);


        }
        private Player Owner => Main.player[Projectile.owner];
        public sealed override void OnSpawn(IEntitySource source)
        {
           
            Projectile.spriteDirection = Main.MouseWorld.X > Owner.MountedCenter.X ? 1 : -1;
        }
        public override void AI() {

            if (Main.rand.NextBool(10))
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Shadowflame);
            }
                Player p = Main.player[Projectile.owner];
            Lighting.AddLight(Projectile.position, .2f, 0f, .2f);
            //Factors for calculations
            double deg = (double)Projectile.ai[0] * 5; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
            double rad = deg * (Math.PI / 180) * Projectile.spriteDirection; //Convert degrees to radians
            double dist = 40  ; //Distance away from the player

            /*Position the player based on where the player is, the Sin/Cos of the angle times the /
            /distance for the desired distance away from the player minus the projectile's width   /
            /and height divided by two so the center of the projectile is at the right place.     */
            Projectile.position.X = p.Center.X - (int)(Math.Cos(rad) * Projectile.spriteDirection * (dist + Projectile.ai[0] )) - Projectile.width / 2;
            Projectile.position.Y = p.Center.Y - (int)(Math.Sin(rad) * Projectile.spriteDirection * (dist + Projectile.ai[0] )) - Projectile.height / 2;

            //Increase the counter/angle in degrees by 1 point, you can change the rate here too, but the orbit may look choppy depending on the value
            Projectile.ai[0] += 1f;


            if (++Projectile.frameCounter >= 8) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= Main.projFrames[Projectile.type])
					Projectile.frame = 0;
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