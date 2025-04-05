using System.IO;

using Eclipse.Utilities.Extensions;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Graphics;

namespace Eclipse.Content.Projectiles.Harvester.Fish;

public abstract class BaseFish : ModProjectile
{
    private const float AttackState = 0f;
    private const float ReturnState = 1f;

   public int timeleft;

    public int manaamt;
    private static readonly VertexStrip Strip = new();

    private ref float Timer => ref Projectile.ai[0];
    private ref float TargetIndex => ref Projectile.ai[1];
    private ref float State => ref Projectile.ai[2];

    private ref float ParentIndex => ref Projectile.localAI[0];



    public sealed override void SetDefaults() {
        Projectile.friendly = true;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = false;

      

        Projectile.aiStyle = -1;
        SetStaticDefaults();

    }

    public override void SendExtraAI(BinaryWriter writer) {
        writer.Write(ParentIndex);
    }

    public override void ReceiveExtraAI(BinaryReader reader) {
        ParentIndex = reader.Read7BitEncodedInt();
    }
  
    public override void AI() {
        switch (State) {
            case AttackState:
                UpdateTarget();
                UpdateAttack();
                break;
            case ReturnState:
                UpdateReturn();
                break;
        }

        Timer++;
    }

    public override bool PreDraw(ref Color lightColor) {
        var texture = TextureAssets.Projectile[Type].Value;

        var effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

        var length = ProjectileID.Sets.TrailCacheLength[Type];

        for (var i = 0; i < length; i += 3) {

            Main.EntitySpriteDraw(
                texture,
                Projectile.GetOldDrawPosition(i),
                Projectile.GetDrawFrame(),
                Projectile.GetAlpha(Color.Blue) * (0.8f - i / (float)length),
                Projectile.rotation,
                texture.Size() / 2f + Projectile.GetDrawOriginOffset(),
                Projectile.scale,
                effects
            );
        }

        Main.EntitySpriteDraw(
            texture,
            Projectile.GetDrawPosition(),
            Projectile.GetDrawFrame(),
            Projectile.GetAlpha(Color.White),
            Projectile.rotation,
            texture.Size() / 2f + Projectile.GetDrawOriginOffset(),
            Projectile.scale,
            effects

        );

        return false;
    }

    private void UpdateTarget() {
        var target = Main.npc[(int)TargetIndex];

        if (target.CanBeChasedBy()) {
            return;
        }

        var range = 16f * 16f;
        var npc = Projectile.FindTargetWithinRange(range);

        if (npc == null) {
            return;
        }

        TargetIndex = npc.whoAmI;

        Projectile.netUpdate = true;
    }

    private void UpdateAttack() {
        var parent = Main.projectile[(int)ParentIndex];

        if (parent.ai[0] >= 1f) {
        //    State = ReturnState;
        }

        var target = Main.npc[(int)TargetIndex];

        if (Timer >= timeleft || target == null || !target.CanBeChasedBy()) {
            State = ReturnState;

            Projectile.netUpdate = true;
        }
        else {
            var distance = Vector2.DistanceSquared(Projectile.Center, target.Center);
            var range = 32f * 32f;

            if (distance > range) {
                var frequency = 0.05f;
                var amplitude = 8f;

                var direction = Projectile.DirectionTo(target.Center);
                var perpendicular = new Vector2(-direction.Y, direction.X) * MathF.Sin(Timer * frequency) * amplitude;

                var velocity = direction * 10f + perpendicular;

                Projectile.velocity = Vector2.Lerp(Projectile.velocity, velocity, 0.2f);
            }
            else {
                Projectile.velocity *= 0.98f;
            }
        }

        Projectile.rotation = Projectile.velocity.ToRotation();

        Projectile.spriteDirection = Math.Sign(Projectile.velocity.X);

        if (Projectile.spriteDirection == -1) {
            Projectile.rotation += MathHelper.Pi;
        }
    }

    private void UpdateReturn() {
        var owner = Main.player[Projectile.owner];

   
   
        if (Projectile.Hitbox.Intersects(owner.Hitbox)) {
          owner.statMana += manaamt;
            owner.ManaEffect(manaamt);

            Projectile.Kill();
            return;
        }

   
        var parent = Main.projectile[(int)ParentIndex];

        if (parent.active && parent.ai[0] >= 1f) {
            Projectile.Center = parent.Center;

            Projectile.rotation = Projectile.AngleTo(owner.Center);

            Projectile.spriteDirection = Math.Sign(owner.Center.X - Projectile.Center.X);

            if (Projectile.spriteDirection == -1) {
                Projectile.rotation += MathHelper.Pi;
            }
        }
        else {
            var direction = Projectile.DirectionTo(owner.Center);
            var velocity = direction * 8f;

            Projectile.velocity = Vector2.SmoothStep(Projectile.velocity, velocity, 0.2f);

            Projectile.rotation = Projectile.velocity.ToRotation();

            Projectile.spriteDirection = Math.Sign(Projectile.velocity.X);

            if (Projectile.spriteDirection == -1) {
                Projectile.rotation += MathHelper.Pi;
            }
        }
    }
}
