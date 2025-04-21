

using Eclipse.Content.Items.Harvester.Scythes;
using Eclipse.Common.Projectiles;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using System.Collections.Generic;
using System.Drawing;
using Terraria;
using Eclipse.Content.Projectiles.Ranged.Ammo;

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
    
        
       
            Item.UseSound = SoundID.Item10; //todo custom sound stylez
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.channel = true;
        }
    }
    public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        if (BowsToOverride.Contains(item.type))
        {
       
            Projectile.NewProjectile(source, player.Center, new Vector2(MathF.Pow(velocity.X, 8.2f), MathF.Pow(velocity.Y, 8.2f)), ModContent.ProjectileType<TestBowHeld>(), damage, knockback, player.whoAmI, ai1:item.type , ai2: type );
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
    int chargespeed = 3;
    int arrowcount= 1;    
    int maxcharge = 240;
    int arrowspread = 1;
    bool lifesteal = false;
    bool autoreuse = false;
    int charged = 0;
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
    public override void OnSpawn(IEntitySource source)
    {
       if (Projectile.ai[1] == ItemID.DemonBow)
        {
            arrowcount = 2;
            chargespeed = 2;
            arrowspread = 10;
           
        }
        if (Projectile.ai[1] == ItemID.TendonBow)
        {
             lifesteal = true;
            chargespeed = 3;
            maxcharge = 320;

        }
        if (Projectile.ai[1] == ItemID.HellwingBow)
        {
            autoreuse = true;
            chargespeed = 5;

             maxcharge = 120;
        }

        if (Projectile.ai[1] == ItemID.Tsunami)
        {
            autoreuse = true;
            arrowcount = 4;
            chargespeed = 6;
            arrowspread = 10;
            maxcharge = 200;
        }
        if (Projectile.ai[1] == ItemID.FairyQueenRangedItem)
        {
            arrowcount = 5;
            chargespeed = 6;
            arrowspread = 5;
            maxcharge = 600;
        }
        if (Projectile.ai[1] == ItemID.PulseBow)
        { 
            chargespeed = 6;
            maxcharge = 1000;

        }
        if (Projectile.ai[1] == ItemID.DD2BetsyBow)
        {
            autoreuse = true;
            chargespeed = 18;
            maxcharge = 400;

        }
        if (Projectile.ai[1] == ItemID.Phantasm)
        {
            autoreuse = true;
            arrowcount = 3;
            arrowspread = 5;
            chargespeed = 14;
            maxcharge = 700;

        }
    }

    public override void AI()
    {
        Player player = Main.player[Projectile.owner];

        Projectile.timeLeft = 60;

        
        Vector2 playerCenter = player.RotatedRelativePoint(player.MountedCenter);
        if (Main.myPlayer == Projectile.owner)
        {

            if (charged != 2 && (player.channel  ||  Projectile.ai[0] <= maxcharge / 6))
            {


                for (int i = 0; i < arrowcount ; i++)
                {


                    Vector2 newVelocity = Projectile.velocity.RotatedBy((arrowspread / 10f) / (1 + (Projectile.ai[0] * (80 / arrowspread) / maxcharge) ) * (-arrowcount / 2 + i));
                 
                    Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, (newVelocity / 2 + (newVelocity * (Projectile.ai[0] / 360))), ModContent.ProjectileType<Trajectory>(), 0, 0f, player.whoAmI, ai2: Projectile.ai[2]);
                   
                }
                if (Projectile.ai[0] < maxcharge)
                {
                    Projectile.ai[0] += chargespeed;
                }

                if ((Projectile.ai[0] >= maxcharge - 1 ) && charged == 0)
                {
                  
                 
                    if      (autoreuse){
                        charged = 2;
                    }
                    else
                    {
                        SoundEngine.PlaySound(SoundID.Item4);
                        charged = 1;
                    }
                
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

                for (int i = 0; i < arrowcount; i++)
                {

                    Vector2 newVelocity = Projectile.velocity.RotatedBy((arrowspread / 10f) / (1 + (Projectile.ai[0] * (80 / arrowspread) / maxcharge)) * (-arrowcount / 2 + i));
                    if (lifesteal  )
                    {
                        SoundEngine.PlaySound(SoundID.NPCDeath13 with { Pitch = -1 / 4 + (Projectile.ai[0] / 360), Volume = (.2f) });
                        Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, (newVelocity / 2 + (newVelocity * (Projectile.ai[0] / 360))), ModContent.ProjectileType<TendonShot>(), 1 + (int)Projectile.ai[0] / 60, 0f, player.whoAmI, ai2: Projectile.ai[2]);
                    }

                    Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, (newVelocity / 2 + (newVelocity * (Projectile.ai[0] / 360))), (int)Projectile.ai[2], (int)(Projectile.damage / 2 + (Projectile.damage * (Projectile.ai[0] / 120))), 0f, player.whoAmI, player.whoAmI);

                }
                SoundEngine.PlaySound(SoundID.Item5 with { Pitch =  -1/4 + (Projectile.ai[0] / 360), Volume = (Projectile.ai[0] / 90) });
              
                
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
