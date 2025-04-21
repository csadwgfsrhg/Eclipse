


using Eclipse.Content.Buffs;
using Terraria.Audio;
using Terraria.DataStructures;

namespace Eclipse.Content.Projectiles.Magic;

    public class GlowingMushroomDust : ModProjectile
	{
    public override void SetStaticDefaults()
    {
        Main.projFrames[Projectile.type] = 3;
    }
    public override void SetDefaults()
		{
       
            Projectile.knockBack = 0;
            Projectile.rotation = Main.rand.Next(360);
            Projectile.scale = Main.rand.NextFloat(.8f, 1.5f);
            Projectile.width = 32;
			Projectile.height = 32;
			Projectile.timeLeft = 480;
            Projectile.Opacity = 100;
            Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
        Projectile.usesLocalNPCImmunity = true;
        Projectile.localNPCHitCooldown = 50;
        AIType = ProjectileID.Bullet;

       
    }
    public override void OnSpawn(IEntitySource source)
    {
        SpriteEffects spriteEffects = SpriteEffects.None;
        Projectile.frame = Main.rand.Next(0, 2);
        if (Main.rand.NextBool(2))
        {
            spriteEffects = SpriteEffects.FlipHorizontally;
        }
    }
    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
    //    Projectile.damage -= Projectile.damage / 4;

   
    }
    public override void AI()
    {
        Player player = Main.player[Projectile.owner];
      
        Projectile.velocity *= .90f;
        Projectile.knockBack = 0;
        Projectile.Opacity = ((Projectile.timeLeft + 100) / 480f) ;
            Projectile.scale *= 1.002f;
      //  Projectile.Size = new Vector2(32, 32) * Projectile.scale;

        if (player.Hitbox.Intersects(Projectile.Hitbox)  )
        {

            player.AddBuff(ModContent.BuffType<MushroomHealing>(), 60);
            player.AddBuff(ModContent.BuffType<GlowingMushroomHealing>(), 60);

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
