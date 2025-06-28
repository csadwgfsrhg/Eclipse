
using Eclipse.Content.Items.Placeable;

namespace Eclipse.Content.Items.Material

{
    public class Bowl : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 18;

            Item.maxStack = 9999;

            Item.rare = ItemRarityID.White;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
              .AddTile(TileID.WorkBenches)
              .AddRecipeGroup("Wood", 3)
              .Register();
        }

    }
}
