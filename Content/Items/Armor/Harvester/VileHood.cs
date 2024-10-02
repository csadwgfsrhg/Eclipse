namespace Eclipse.Content.Items.Armor.Harvester;

[AutoloadEquip(EquipType.Head)]
public class VileHood : ModItem

{
    public override void SetDefaults() {
        Item.width = 26;
        Item.height = 28;
        Item.maxStack = 1;
        Item.value = 100;
        Item.defense = 2;
        Item.rare = 2;
        ArmorIDs.Head.Sets.IsTallHat[Item.headSlot] = true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.VilePowder, 5);
        recipe.AddIngredient(ItemID.RottenChunk, 3);
        recipe.AddIngredient(ItemID.Silk, 4);
        recipe.AddTile(TileID.WorkBenches);
        recipe.Register();
    }
}
