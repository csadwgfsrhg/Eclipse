

using Eclipse.Content.Items.Harvester.Scythes;
using Eclipse.Common.Projectiles;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using System.Collections.Generic;

namespace Eclipse.Common.Items;

internal class TestBow : GlobalItem
{

    public static List<int> BowsToOverride = new List<int>()
        {
                ItemID.DD2BetsyBow,
                ItemID.AshWoodBow,
                ItemID.AshWoodBathtub,
                ItemID.BloodRainBow,
                ItemID.BorealWoodBow,
                ItemID.CopperBow,
                ItemID.DemonBow,
                ItemID.EbonwoodBow,
                ItemID.FairyQueenRangedItem,
                ItemID.GoldBow,
                ItemID.HellwingBow,
                ItemID.IceBow,
                ItemID.IronBow,
                ItemID.Marrow,
                ItemID.MoltenFury,
                ItemID.PalmWoodBow,
                ItemID.PearlwoodBow,
                ItemID.Phantasm,
                ItemID.DD2PhoenixBow,
                ItemID.PlatinumBow,
                ItemID.PulseBow,
                ItemID.RichMahoganyBow,
                ItemID.ShadowFlameBow,
                ItemID.SilverBow,
                ItemID.TendonBow,
                ItemID.BeesKnees,
                ItemID.Tsunami,
                ItemID.TungstenBow,
                ItemID.WoodenBow,
        };
    public override void SetDefaults(Item Item)
    {


        if (BowsToOverride.Contains(Item.type))
        {
            //max charge
            //arrow amnt

            //auto release bool
            //Item.useAmmo = AmmoID.Arrow;
            //Item.useAmmo = AmmoID.Arrow;
            //Item.DamageType = DamageClass.Ranged;
            //Item.useStyle = ItemUseStyleID.Shoot;
            //Item.knockBack = 6;
            //Item.shootSpeed = 10f;
            //Item.damage = 6;
            Item.UseSound = SoundID.Item10; //todo custom sound stylez
            Item.noMelee = true;
            Item.autoReuse = false;
            Item.channel = true;
        }
    }
    public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        if (BowsToOverride.Contains(item.type))
        {
            if (item.type == ItemID.IceBow)
            {

           //     player.GetModPlayer<Bowplayer>().charge = 2;
            }
            Projectile.NewProjectile(source, player.Center, new Vector2(MathF.Pow(velocity.X, 8.2f), MathF.Pow(velocity.Y, 8.2f)), ModContent.ProjectileType<TestBowHeld>(), damage, knockback, player.whoAmI, ai2: type );
            return false;
        }
      
        return true;
    }





}
internal class TestBowHeld : BowHeld
{

    public override string Texture => "Eclipse/Content/Projectiles/Magic/LifeCrystalStaffHeld";
    public override void SetStaticDefaults()
    {

    }
}
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
                Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, (Projectile.velocity / 2 + (Projectile.velocity * (Projectile.ai[0] / 120))),ModContent.ProjectileType<Trajectory>(), 0, 0f, player.whoAmI, ai2: Projectile.ai[2]);
            
                if (Projectile.ai[0] < 80)
                {
                    Projectile.ai[0] += 1; //player.GetModPlayer<Bowplayer>().charge;
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
              
                Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, (Projectile.velocity / 2 + (Projectile.velocity * (Projectile.ai[0] / 120)) ) , (int)Projectile.ai[2], (int)(Projectile.damage /2 + (Projectile.damage  * (Projectile.ai[0] / 45))), 0f, player.whoAmI, player.whoAmI);
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
