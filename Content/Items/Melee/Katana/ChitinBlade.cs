using Eclipse.Common;
using Eclipse.Content.Projectiles.Melee.Boomerang;
using Eclipse.Content.Projectiles.Melee.Katana;
using Terraria.GameContent.ObjectInteractions;

namespace Eclipse.Content.Items.Melee.Katana;

public class ChitinBlade : ModItem
{
    private int charge;

    public override void SetDefaults() {

        Item.DamageType = DamageClass.Melee;
        Item.damage = 15;
        Item.knockBack = 6f;
        Item.useTime = Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.width = 40;
        Item.height = 40;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item1;
        Item.shoot = ModContent.ProjectileType<ChitinBladeHeld>();
        Item.shootSpeed = 1f;
        Item.channel = true;
        Item.noMelee = true;
        Item.noUseGraphic = true;
    }

    
    public override void HoldItem(Player player) {

        player.GetModPlayer<EclipseModPlayer>().ChitinBladeHeld = true;
        player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, -.6f * player.direction);
        if (player.ownedProjectileCounts[Item.shoot]  < 1)
        {
            Main.NewText("you are holding sword");
          
        }
    }

   
}
