

using Eclipse.Content.Items.Harvester.Scythes;
using Eclipse.Common.Projectiles;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;

namespace Eclipse.Common.Items;

public abstract class BowHeld : ModProjectile
{

    public override void SetDefaults()
    {
        Projectile.width = 50;
        Projectile.height = 50;
        Projectile.friendly = false;
        Projectile.tileCollide = false;
        Projectile.penetrate = -1;

        Projectile.aiStyle = -1;
        Projectile.hide = true;
    }


    public override void AI()
    {
        Player player = Main.player[Projectile.owner];

        Projectile.timeLeft = 60;

        
        Vector2 playerCenter = player.RotatedRelativePoint(player.MountedCenter);
        if (Main.myPlayer == Projectile.owner)
        {

            if (player.channel ||  Projectile.ai[0] <= 20)
                {
                Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, (Projectile.velocity / 3 + (Projectile.velocity * (Projectile.ai[0] / 180))),ModContent.ProjectileType<Trajectory>(), 0, 0f, player.whoAmI, player.whoAmI);
            
                if (Projectile.ai[0] < 80)
                {
                    Projectile.ai[0] += 1;
                }
               
                     if (Projectile.ai[0] == 79)
                {
                    SoundEngine.PlaySound(SoundID.Item4);
                }
                    float holdoutDistance = player.HeldItem.shootSpeed * Projectile.scale;

                Vector2 holdoutOffset = holdoutDistance * Vector2.Normalize(Main.MouseWorld - playerCenter);
                if (holdoutOffset.X != Projectile.velocity.X || holdoutOffset.Y != Projectile.velocity.Y)
                {

                    Projectile.netUpdate = true;
                }


                Projectile.velocity = holdoutOffset;
            }
            else
            {
              

                SoundEngine.PlaySound(SoundID.Item5 with { Pitch = ( -1/4 + (Projectile.ai[0] / 120)), Volume = (Projectile.ai[0] / 30) });
                //ammo conversion?
              Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, (Projectile.velocity / 3 + (Projectile.velocity * (Projectile.ai[0] / 180)) ) , ProjectileID.WoodenArrowFriendly, (int)(Projectile.damage /2 + (Projectile.damage  * (Projectile.ai[0] / 45))), 0f, player.whoAmI, player.whoAmI);
                Projectile.Kill();

            }
        }

        if (Projectile.velocity.X > 0f)
        {
            player.ChangeDir(1);
        }
        else if (Projectile.velocity.X < 0f)
        {
            player.ChangeDir(-1);
        }

        Projectile.spriteDirection = Projectile.direction;
        player.ChangeDir(Projectile.direction); 
        player.heldProj = Projectile.whoAmI; 
        player.SetDummyItemTime(2); 
        Projectile.Center = playerCenter; 
        Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        player.itemRotation = (Projectile.velocity * Projectile.direction).ToRotation();



    }

}
internal class TestBow : GlobalItem
{

    public override void SetDefaults(Item Item)
    {
        if (Item.type == ItemID.WoodenBow)
        {
            //max charge
            //arrow amnt
            //minimum charge
            //auto release bool
            //Item.useAmmo = AmmoID.Arrow;
            Item.useAmmo = 0;
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 6;
            Item.shootSpeed = 10f;
            Item.UseSound = SoundID.Item10;
            Item.damage = 6;
            Item.noMelee = true;
            Item.channel = true;
            Item.shoot = ModContent.ProjectileType<TestBowHeld>();
         

        }
    }

   



}

internal class TestBowHeld : BowHeld
{
    
    public override string Texture => "Eclipse/Content/Projectiles/Magic/LifeCrystalStaffHeld";
    public override void SetStaticDefaults()
    {




    }
}