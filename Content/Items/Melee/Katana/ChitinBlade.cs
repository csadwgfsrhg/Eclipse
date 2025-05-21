using Eclipse.Common;
using Eclipse.Content.Projectiles.Melee.Boomerang;
using Eclipse.Content.Projectiles.Melee.Katana;
using Terraria.GameContent.ObjectInteractions;

namespace Eclipse.Content.Items.Melee.Katana;

public class ChitinBlade : ModItem
{


    public override void SetDefaults() {

        Item.DamageType = DamageClass.Melee;
        Item.damage = 27;
        Item.knockBack = 6f;
        Item.width = 40;
        Item.height = 40;
        Item.channel = true;
        Item.rare = 2;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 1;
        Item.useAnimation = 1;
        Item.noMelee = true;
        Item.noUseGraphic = true;
        Item.useTurn = true;
        Item.autoReuse = true;
    }

    public override bool? UseItem(Player player)
    {
        if (player.GetModPlayer<EclipseModPlayer>().ChitinBladeHeld == true)
        {

            return false;
        }
        else
        player.GetModPlayer<EclipseModPlayer>().ChitinBladeHeld = true;

        return true;
    }
   

   
}
