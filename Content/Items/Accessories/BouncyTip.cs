namespace Eclipse.Content.Items.Accessories;

public class BouncyTip : ModItem
{
    public override void SetDefaults() {
        Item.width = 40;
        Item.height = 40;
        Item.accessory = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual) {
        player.GetModPlayer<MyPlayer>().BouncyTip = true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.PinkGel, 12);

        recipe.AddTile(TileID.WorkBenches);
        recipe.Register();
    }
}
