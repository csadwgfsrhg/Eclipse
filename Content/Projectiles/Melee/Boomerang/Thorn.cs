using Terraria;
using Terraria.Audio;

namespace Eclipse.Content.Projectiles.Melee.Boomerang;

public class Thorn : ModProjectile
{


    public override void SetDefaults() {
     
        Projectile.friendly = true;
        Projectile.tileCollide = true;
        Projectile.usesLocalNPCImmunity = true;
        Projectile.localNPCHitCooldown = 30;
        Projectile.width = 10;
        Projectile.height = 10;
        Projectile.extraUpdates = 1;
        Projectile.penetrate = -1;
        Projectile.aiStyle = 1;

        Projectile.timeLeft = 300;
    }
    public override void OnKill(int timeLeft)
    {
        for (int i = 0; i < Main.rand.Next(5, 10); i++)
        {
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Poisoned);
          
        }

    }

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        if (Main.rand.NextBool(4))
        {
            target.AddBuff(BuffID.Poisoned, 20);
        }
    }
    public override void AI() {
       if  (Main.rand.NextBool(20))
        {
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Poisoned);
        }
    }
}
