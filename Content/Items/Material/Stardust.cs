
using Eclipse.Content.Items.Placeable;

namespace Eclipse.Content.Items.Material

{
    public class Stardust : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 18;

            Item.maxStack = 9999;
            //Item.value = Item.buyPrice(platinum: 2);
            Item.rare =1;
        }
        public override void AddRecipes()
        {
            CreateRecipe(5)
              .AddTile<Tiles.MortarAndPestle> ()
              .AddIngredient(ItemID.FallenStar, 1)
              .Register();
        }

    }
}
