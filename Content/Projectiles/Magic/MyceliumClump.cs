

using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;

namespace Eclipse.Content.Projectiles.Magic;

public class MyceliumClump : ModProjectile
{


    public override void SetStaticDefaults()
    {
        Main.projFrames[Projectile.type] = 3;
    }

    public sealed override void SetDefaults()
    {

 


        Projectile.ignoreWater = true;
        Projectile.tileCollide = true;
        Projectile.penetrate = 3;
        Projectile.width = 26;
        Projectile.DamageType = DamageClass.Magic;
        Projectile.height = 26;
        Projectile.usesLocalNPCImmunity = true;
        Projectile.localNPCHitCooldown = 30;
        Projectile.friendly = true;
        Projectile.rotation = Main.rand.Next(360);
        Projectile.aiStyle = -1;


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
    public override void AI()
    {
        Projectile.rotation += (Projectile.velocity.X / 20);
        Projectile.velocity.Y += .2f;
            Projectile.ai[1] -= 1;
        if (Main.rand.NextBool(100))
        {
            Dust.NewDust(Projectile.position, 32, 32, DustID.PureSpray, 0, 0, 255, newColor: (default), 1f);
        }
        if (Main.rand.NextBool(100))
        {
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<MushroomDust>(), 1, Projectile.knockBack, Projectile.owner);
        }
       
      
    }
    public override void OnKill(int timeLeft)
    {
        for (int i = 0; i < 6; i++)
        { 

            Vector2 launchVelocity = new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-5, 5));

            Dust.NewDust(Projectile.position, 32, 32, DustID.PureSpray, 0, 0, 255, newColor: (default), 1f);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ModContent.ProjectileType<MushroomDust>(), 1, Projectile.knockBack, Projectile.owner);
        }

        SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
    }
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
      
        
        if (Projectile.ai[1] <= 0)
        {
            Projectile.penetrate -= 1;
            for (int i = 0; i < Main.rand.Next(1, 3); i++)
            {

                Vector2 launchVelocity = new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-5, 5));

                Dust.NewDust(Projectile.position, 32, 32, DustID.PureSpray, 0, 0, 255, newColor: (default), 1f);
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ModContent.ProjectileType<MushroomDust>(), 1, Projectile.knockBack, Projectile.owner);
            }
            SoundEngine.PlaySound(SoundID.Item154 with { PitchVariance = .4f }, Projectile.position);
            Projectile.ai[1] = 30;
        }
            if (Projectile.velocity.X == 0)
            {
                Projectile.velocity.X = -Projectile.oldVelocity.X * 1.5f;
            }
            if (Projectile.velocity.Y == 0)
            {
                Projectile.velocity.Y = -Projectile.oldVelocity.Y * 1.5f;
            }
       
        return false;
}
    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
    
        for (int i = 0; i < Main.rand.Next(1, 3); i++)
                {

                    Vector2 launchVelocity = new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-5, 5));

            Dust.NewDust(Projectile.position, 32, 32, DustID.PureSpray, 0, 0, 255 , newColor: (default), 1f);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ModContent.ProjectileType<MushroomDust>(), 1, Projectile.knockBack, Projectile.owner);
                }

        SoundEngine.PlaySound(SoundID.Item154 with { PitchVariance = .4f }, Projectile.position);
        Projectile.velocity.Y = -Projectile.velocity.Y * 1.5f;

    }
    
  
}
