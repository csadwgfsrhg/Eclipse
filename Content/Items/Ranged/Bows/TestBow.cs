using Eclipse.Common;
using Eclipse.Common.Items;
using Eclipse.Content.Projectiles.Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;

namespace Eclipse.Content.Items.Ranged.Bows
{
    internal class TestBow : GlobalItem
    {
      
        public override void SetDefaults(Item Item)
        {
            if (Item.type == ItemID.WoodenBow)
            {
                Item.DamageType = DamageClass.Ranged;
                Item.useStyle = ItemUseStyleID.Shoot;
                Item.knockBack = 6;
                Item.value = 10000;
                Item.shootSpeed = 10f;
                Item.UseSound = SoundID.Item10;
                Item.damage = 6;
                Item.noMelee = true;
                Item.channel = true;
                Item.useAmmo = 0;
                Item.useTime = 30;
                Item.shoot = ModContent.ProjectileType<TestBowHeld>();
              //  Item.useAmmo = AmmoID.Arrow;

            }
        }

  



    }
   
    internal class TestBowHeld : BowHeld
    {
   //     public override string Texture => $"Terraria/Images/Item_{ItemID.WoodenBow}";
        public override string Texture => "Eclipse/Content/Projectiles/Magic/LifeCrystalStaffHeld";
        public override void SetStaticDefaults()
        {
    
  


        }
    }
}

