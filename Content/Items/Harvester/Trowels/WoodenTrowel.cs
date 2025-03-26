
using Eclipse.Content.Projectiles.Harvester.Crops;

namespace Eclipse.Content.Items.Harvester.Trowels;

public class WoodenTrowel : ModItem
{
    private int charge;

    public override void SetDefaults() {
        Item.autoReuse = true;
        Item.noMelee = true;



        Item.damage = 15;
        Item.knockBack = 6f;

        Item.width = 40;
        Item.height = 40;

        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.UseSound = SoundID.Item1;
        Item.useStyle = ItemUseStyleID.Swing;

        Item.shoot = ModContent.ProjectileType<PotatoCrop>();

        Item.value = Item.sellPrice(gold: 1);
    }

    public override void HoldItem(Player player) {
    

    
    }

    public override void AddRecipes() {
        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 20)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}
