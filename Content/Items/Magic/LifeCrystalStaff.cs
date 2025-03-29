

using Eclipse.Common;
using Eclipse.Content.Projectiles.Magic;
using Terraria.DataStructures;
using Terraria.GameContent;

namespace Eclipse.Content.Items.Magic
{
    public class LifeCrystalStaff : ModItem

    {
        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true; 
        }
        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;
            Item.rare = 2;
            Item.damage = 20;
            Item.DamageType = DamageClass.Magic;
            Item.shoot = ModContent.ProjectileType<HeartBig>();
            Item.shootSpeed = 6f;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.mana = 16;
            Item.channel = true;
            Item.useStyle = 5;
            Item.noMelee = true;
           // Item.noUseGraphic = true;
   

        }
        public override bool? UseItem(Player player)
        {
            player.GetModPlayer<EclipseModPlayer>().LifeCrystalStaffHeld = true;
            return true;
        }
       
    }
}


   