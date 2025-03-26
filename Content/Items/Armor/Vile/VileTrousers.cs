namespace Eclipse.Content.Items.Armor.Vile;

[AutoloadEquip(EquipType.Legs)]
public class VileTrousers : ModItem
{
   

    public override void SetDefaults() {
        Item.width = 20;
        Item.height = 14;

        Item.defense = 2;

        Item.rare = ItemRarityID.Green;
        Item.value = Item.sellPrice(silver: 1);
    }

    public override void AddRecipes() {
        CreateRecipe()
            .AddIngredient(ItemID.VilePowder, 5)
             .AddIngredient(ItemID.RottenChunk, 1)
               .AddIngredient(ItemID.Leather, 1)
            .AddIngredient(ItemID.Silk, 7)
            .AddTile(TileID.WorkBenches)
            .Register();    
    }
}
