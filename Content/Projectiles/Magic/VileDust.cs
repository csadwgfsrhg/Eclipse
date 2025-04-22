


using Eclipse.Content.Buffs;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;

namespace Eclipse.Content.Projectiles.Magic;

    public class VileDust : ModProjectile
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
			Projectile.timeLeft = 180;
            Projectile.Opacity = 100;
            Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = true;
        Projectile.usesLocalNPCImmunity = true;
        Projectile.localNPCHitCooldown = 20;
        AIType = ProjectileID.Bullet;

       
    }
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        if (Projectile.velocity.X == 0)
        {
            Projectile.velocity.X = -Projectile.oldVelocity.X * .8f;
        }
        if (Projectile.velocity.Y == 0)
        {
            Projectile.velocity.Y = -Projectile.oldVelocity.Y * .8f;
        }
        return false;
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
        Projectile.velocity *= .96f;
        Projectile.knockBack = 0;
        Projectile.Opacity *= .99f;
            Projectile.scale *= 1.005f;
        

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
