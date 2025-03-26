using System.IO;

using Eclipse.Utilities.Extensions;

using Terraria.GameContent;
using Terraria.Graphics;

namespace Eclipse.Content.Projectiles.Harvester.Fish;

public class SpiritBass : BaseFish
{
    public override void SetStaticDefaults()
    {
        ProjectileID.Sets.TrailingMode[Type] = 3;
        ProjectileID.Sets.TrailCacheLength[Type] = 4;
        timeleft = 300;
        manaamt = 3;
        Projectile.localNPCHitCooldown = 20;
        Projectile.usesLocalNPCImmunity = true;
        Projectile.penetrate = -1;
        Projectile.width = 20;
        Projectile.height = 20;
    }
}
