

using Terraria.DataStructures;
using Terraria.GameContent;

namespace Eclipse.Common.Items;
public abstract class ScytheAI : ModItem
{

    public sealed override void SetDefaults()
    {
        Item.damage = 1;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 6;
        Item.value = 10000;
        Item.shootSpeed = 10f;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        Item.noMelee = true;
        Item.noUseGraphic = true;
        SetStaticDefaults();
    }
}
public abstract class ScytheProj : ModProjectile
{

    private Player Owner => Main.player[Projectile.owner];
    public sealed override void SetDefaults()
    {
        Projectile.timeLeft = 30;
        Projectile.penetrate = -1;
        Projectile.Opacity = 100;
        Projectile.knockBack = 0;
        Projectile.friendly = true;
        Projectile.scale = 1;
        Projectile.knockBack = 2;
        Projectile.tileCollide = false;
        Projectile.aiStyle = -1;
        Projectile.localNPCHitCooldown = 999999;
        Projectile.usesLocalNPCImmunity = true;
        SetStaticDefaults();


    }

    public override bool PreDraw(ref Color lightColor)
    {

        Vector2 origin;
        float rotationOffset;
        SpriteEffects effects;

        if (Projectile.spriteDirection > 0)
        {
            origin = new Vector2(0, Projectile.height);
            rotationOffset = MathHelper.ToRadians(45f);
            effects = SpriteEffects.None;
        }
        else
        {
            origin = new Vector2(Projectile.width, Projectile.height);
            rotationOffset = MathHelper.ToRadians(135f);
            effects = SpriteEffects.FlipHorizontally;
        }

        Texture2D texture = TextureAssets.Projectile[Type].Value;

        Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, default, lightColor * Projectile.Opacity, Projectile.rotation + rotationOffset, origin, Projectile.scale, effects, 0);


        return false;
    }
    bool canharvest = true;
    bool landhit = false;
    int swingspeed = 0;
    private ref float InitialAngle => ref Projectile.ai[1];

    public sealed override void AI()
    {
        if (Projectile.spriteDirection > 0)
        {
            Projectile.rotation = Projectile.spriteDirection * Projectile.ai[0] + 180;
        }
        else { Projectile.rotation = Projectile.spriteDirection * Projectile.ai[0]; }


        Player player = Main.player[Projectile.owner];
        Owner.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Projectile.rotation - MathHelper.ToRadians(90f));
        Vector2 armPosition = Owner.GetFrontHandPosition(Player.CompositeArmStretchAmount.Full, Projectile.rotation - (float)Math.PI / 2); // get position of hand

        armPosition.Y += Owner.gfxOffY;

        Projectile.ai[0] *= 1f + 2f / ((swingspeed) - 3 / 2);





        Owner.heldProj = Projectile.whoAmI;
        Projectile.Center = armPosition;
        if (landhit == true)
        {
          player.statMana += swingspeed / 6;
            player.ManaEffect(swingspeed / 6);
       
            landhit = false;
        }
    }
    public sealed override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
    {
        Vector2 start = Owner.MountedCenter;
        Vector2 end = start + Projectile.rotation.ToRotationVector2() * ((Projectile.Size.Length()) * Projectile.scale);
        float collisionPoint = 0f;
        return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), start, end, 15f * Projectile.scale, ref collisionPoint);
    }
    public sealed override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
    {

        modifiers.HitDirectionOverride = target.position.X > Owner.MountedCenter.X ? 1 : -1;

    }
    public sealed override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {




        if (canharvest == true)
        {
            canharvest = false;
            landhit = true;

        }


    }
    public sealed override void OnSpawn(IEntitySource source)
    {
        swingspeed = Projectile.timeLeft;
        Projectile.spriteDirection = Main.MouseWorld.X > Owner.MountedCenter.X ? 1 : -1;

        Projectile.ai[0] += 1.01f;


    }
}