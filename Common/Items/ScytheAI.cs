

using Eclipse.Common.Projectiles;
using Eclipse.Content.Items.Harvester.Scythes;
using Eclipse.Content.Projectiles.Harvester.Scythe;
using Eclipse.Content.Projectiles.Ranged.Ammo;
using System.Runtime.InteropServices;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;

namespace Eclipse.Common.Items;
public abstract class ScytheAI : ModItem
{

    public sealed override void SetDefaults()
    {
        Item.damage = 1;
        Item.DamageType = DamageClass.Melee;
       // Item.useStyle = 0;
        Item.knockBack = 6;
        Item.value = 10000;
        Item.shootSpeed = 10f;
        Item.UseSound = SoundID.Item1;

        Item.channel = true;
        Item.noMelee = true;
        Item.noUseGraphic = true;
     
        SetStaticDefaults();
    }
 
   // public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
   // {
      
      

         //   Projectile.NewProjectile(source, player.Center, new Vector2(MathF.Pow(velocity.X, 8.2f), MathF.Pow(velocity.Y, 8.2f)), ModContent.ProjectileType<ScytheProj>(), damage, knockback, player.whoAmI);
       //     return true;
        
   // }
}

public abstract class ScytheProj : ModProjectile
{
    public override string Texture => "Eclipse/Content/Projectiles/Magic/LifeCrystalStaffHeld";
    private Player Owner => Main.player[Projectile.owner];
    public override void SetStaticDefaults()
    {
        ProjectileID.Sets.HeldProjDoesNotUsePlayerGfxOffY[Type] = true;
    }

   
      
    public sealed override void SetDefaults()
    {
        Projectile.netImportant = true;
        Projectile.timeLeft = 30;
        Projectile.penetrate = -1;
        Projectile.tileCollide = false;
        Projectile.Opacity = 100;
        Projectile.knockBack = 0;
        Projectile.friendly = false;
        Projectile.scale = 1;
        Projectile.knockBack = 2;
        Projectile.tileCollide = false;
        Projectile.aiStyle = -1;
        Projectile.localNPCHitCooldown = 10;
        Projectile.usesLocalNPCImmunity = true;
        SetStaticDefaults();



    }

    bool landhit = false;
    int swingspeed = 0;
    private ref float InitialAngle => ref Projectile.ai[1];
     float rotation = 0;
    float charge = 0;
    int timeleft;
    int chargemax = 200;
    bool full = false;
    bool autoreuse = false;
    int rotations = 1;
    bool attacking = false;
    int colorchange = 0;
    bool frame1 = true;
    public override void AI()
    {
        if (full)
             colorchange += 10;

        Player player = Main.player[Projectile.owner];
        Projectile.spriteDirection = player.direction;
        player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Projectile.rotation - MathHelper.ToRadians(90f));
        player.itemAnimation = player.itemAnimationMax;
        player.itemTime = player.itemTimeMax;
        player.heldProj = Projectile.whoAmI;
        Projectile.timeLeft = 60;


        Vector2 playerCenter = player.RotatedRelativePoint(player.MountedCenter);
        if (player.HeldItem.autoReuse && !player.channel)
        {
            Projectile.Kill();
        }
        if (Main.myPlayer == Projectile.owner)
        {

            Vector2 armPosition = Owner.GetFrontHandPosition(Player.CompositeArmStretchAmount.Full, Projectile.rotation - (float)Math.PI / 2); // get position of hand

            armPosition.Y += Owner.gfxOffY;
            Projectile.Center = armPosition;
       //     Projectile.position.Y += 10;
            Projectile.scale = .5f + charge / 200;
  
            Projectile.position.X -= 8 * Projectile.spriteDirection;
            //   Projectile.velocity = 
            Projectile.rotation = rotation * player.direction;
            if (Projectile.spriteDirection == 1)
            {
                Projectile.rotation -= 1.3f;

            }

            else
            {
                Projectile.rotation += 4.5f;

            }

            if ( (player.channel  || rotation > -.5) && attacking == false)
            {

                if (rotation > -1.5)
                    rotation = - charge / 120;


                if (charge < chargemax)
                {
             
                    charge += 100 / player.HeldItem.useTime  ;
                }
                   if (charge >= chargemax && full == false)
                {
                    if (player.HeldItem.autoReuse == false)
                    {
                        full = true;
                        SoundEngine.PlaySound(SoundID.MaxMana, Projectile.position);
                    }
                    else
                        attacking = true;
                    }
                
            

            }
            else
            {
                if (frame1)
                {
                  

                    SoundEngine.PlaySound(SoundID.Item71, Projectile.position);
                }
                if (player.HeldItem.type == ModContent.ItemType<BoneScythe>() && Main.rand.NextBool((int)charge, 1000))
                    Projectile.NewProjectile(Projectile.InheritSource(Projectile), player.Center, Vector2.Zero, ModContent.ProjectileType<SpiritSkull>(), Projectile.damage / 4, 0);
                full = false;
                frame1 = false;
                Projectile.damage = (int)(Projectile.originalDamage * (1 + charge /200));
                attacking = true;
                Projectile.friendly = true;
                charge /=  (player.HeldItem.useTime  / (player.HeldItem.useTime - 2f));
                rotation += charge / 250;
                timeleft++;
              
                //  Projectile.Kill();
                if (charge <= 50)
                {
                  
                    Projectile.Opacity *= .93f;
                    if (charge <= 15)
                        Projectile.Kill();
           
                }

            }
        }

             }
    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {

        Player player = Main.player[Projectile.owner];
        player.statMana += 1;
        player.ManaEffect(1);
    }
    public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
    {
        Vector2 start = Owner.MountedCenter + Projectile.rotation.ToRotationVector2() * ((Projectile.Size.Length() * Projectile.scale) / 2);
        Vector2 end = Owner.MountedCenter + Projectile.rotation.ToRotationVector2() * ((Projectile.Size.Length() * Projectile.scale) );
        float collisionPoint = 0f;
        return Collision.CheckAABBvLineCollision(targetHitbox.TopRight(), targetHitbox.Size(), start, end, 100f * Projectile.scale, ref collisionPoint);
    }

    // Do a similar collision check for tiles
    public override void CutTiles()
    {
        Vector2 start = Owner.MountedCenter;
        Vector2 end = start + Projectile.rotation.ToRotationVector2() * ((Projectile.Size.Length() * Projectile.scale) );
        Utils.PlotTileLine(start, end, 15 * Projectile.scale, DelegateMethods.CutTiles);
    }
    public override bool PreDraw(ref Color lightColor)
    {
        Vector2 origin;
        float rotationOffset;
        SpriteEffects effects;
        if (full)
            lightColor = new Color(colorchange, colorchange, colorchange * 2, 255);
       
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

        // Since we are doing a custom draw, prevent it from normally drawing
        return false;
    }

}

