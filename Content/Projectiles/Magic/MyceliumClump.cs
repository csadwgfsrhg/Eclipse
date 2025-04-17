

using Terraria;
using Terraria.Audio;

namespace Eclipse.Content.Projectiles.Magic;

public class MyceliumClump : ModProjectile
{




    public sealed override void SetDefaults()
    {

 


        Projectile.ignoreWater = true;
        Projectile.tileCollide = true;
        Projectile.penetrate = 3;
        Projectile.width = 32;
        Projectile.height = 32;
        Projectile.usesLocalNPCImmunity = true;
        Projectile.localNPCHitCooldown = 30;
        Projectile.friendly = true;

        Projectile.aiStyle = 1;


    }
    public override void AI()
    {
        if (Projectile.ai[1] <= 0)
        {
            Projectile.friendly = true;
        }
        else
        {
            Projectile.friendly = false;
        }
            Projectile.ai[1] -= 1;
        if (Main.rand.NextBool(100))
        {
            Dust.NewDust(Projectile.position, 32, 32, DustID.PureSpray, 0, 0, 255, newColor: (default), 1f);
        }
        if (Main.rand.NextBool(100))
        {
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<MushroomDust>(), 0, Projectile.knockBack, Projectile.owner);
        }
       
      
    }
    public override void OnKill(int timeLeft)
    {
        for (int i = 0; i < 6; i++)
        { 

            Vector2 launchVelocity = new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-5, 5));

            Dust.NewDust(Projectile.position, 32, 32, DustID.PureSpray, 0, 0, 255, newColor: (default), 1f);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ModContent.ProjectileType<MushroomDust>(), 0, Projectile.knockBack, Projectile.owner);
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

            SoundEngine.PlaySound(SoundID.Item127, Projectile.position);
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
      Projectile.velocity.Y = -Projectile.velocity.Y * 1.5f;
        for (int i = 0; i < Main.rand.Next(1, 3); i++)
                {

                    Vector2 launchVelocity = new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-5, 5));

            Dust.NewDust(Projectile.position, 32, 32, DustID.PureSpray, 0, 0, 255 , newColor: (default), 1f);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ModContent.ProjectileType<MushroomDust>(), 1, Projectile.knockBack, Projectile.owner);
                }

                SoundEngine.PlaySound(SoundID.Item127, Projectile.position);
        Projectile.ai[1] = 30;
    }
    
  
}
