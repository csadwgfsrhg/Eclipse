using System.IO;
using Eclipse.Content.Classes;
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
public sealed class SwordBeamGlobalProjectile : GlobalProjectile
{

    public override void SetDefaults(Projectile projectile)
    {
        if (projectile.type == ProjectileID.TerraBlade2Shot)

        {
           // projectile.extraUpdates = 1;


        }



    }
    }
   


    


   
