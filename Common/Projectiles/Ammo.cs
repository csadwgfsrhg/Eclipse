using System.IO;
using System.Security.Cryptography.X509Certificates;

using Eclipse.Content.Projectiles.Harvester.Crops;
using Eclipse.Content.Projectiles.Melee.Boomerang;
using Eclipse.Utilities.Extensions;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;

namespace Eclipse.Common.Projectiles;

/// <summary>
///     Handles the behavior of fishing rod bobbers, which should latch onto enemies and spawn phantom
///     fishes accordingly.
/// </summary>
public sealed class Ammo : GlobalProjectile
{

    public override void SetDefaults(Projectile Projectile)
    {

        if (Projectile.type == ProjectileID.JestersArrow)

        {

            Projectile.localNPCHitCooldown = 5;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.penetrate = 10;
        }

        if (Projectile.type == ProjectileID.UnholyArrow)

        {
            Projectile.localNPCHitCooldown -= 1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.penetrate = 10;
        }
    }
    public override void OnSpawn(Projectile Projectile, IEntitySource source)
    {
        if (Projectile.type == ProjectileID.ChlorophyteBullet)
        {
            Projectile.velocity /= 2;

        }

        {
            if (Projectile.type == ProjectileID.JestersArrow)

            {
                Projectile.damage -= Projectile.damage / 3;

            }
        }
    }
    public override void OnHitNPC(Projectile Projectile, NPC target, NPC.HitInfo hit, int damageDone)
    {
        if (Projectile.type == ProjectileID.JestersArrow)

        {
            Projectile.damage -= Projectile.damage / 5;
        }
        if (Projectile.type == ProjectileID.UnholyArrow)

        {
            Projectile.damage -= Projectile.damage / 5;
        }
    }

}


    


   
