using System.IO;
using Eclipse.Content.Classes;
using Eclipse.Utilities.Extensions;

using Terraria.GameContent;
using Terraria.Graphics;

namespace Eclipse.Content.Projectiles.Harvester.Fish;

public class SpiritPiranha : BaseFish
{
    public override void SetStaticDefaults()
    {
        ProjectileID.Sets.TrailingMode[Type] = 3;
        ProjectileID.Sets.TrailCacheLength[Type] = 10;
        Projectile.timeLeft = 2; // int for fish type
        Projectile.extraUpdates = 1;
        Projectile.localNPCHitCooldown = 30;
        Projectile.usesLocalNPCImmunity = true;
        Projectile.penetrate = -1;
        Projectile.width = 18;
        Projectile.height = 18;
    }
}
