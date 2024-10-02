using Terraria.DataStructures;

namespace Eclipse.Content;

public static class GlobalExtensions
{
    public static bool IsLance(this Projectile proj) {
        return proj.type == ProjectileID.HallowJoustingLance
            || proj.type == ProjectileID.JoustingLance
            || proj.type == ProjectileID.ShadowJoustingLance;
    }
}

public class MyPlayer : ModPlayer
{
    public bool BouncyTip;
    public int cooldown;


    public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright) {
        cooldown += 1;
    }

    public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone) {
        var player = Main.player[proj.owner];


        if (BouncyTip & proj.IsLance()) {
            player.velocity = -player.velocity;
        }

        BouncyTip = false;
    }
}
