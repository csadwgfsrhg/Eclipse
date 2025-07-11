﻿
using Eclipse.Content.Items.Weed;
using Terraria.Localization;
using Eclipse.Content.Tiles;
namespace Eclipse.Utilities.Extensions
{
    public class Recipes : ModSystem

    {
        public override void AddRecipes()
        {
            Recipe recipeRope = Recipe.Create(ItemID.Rope, 5);
            recipeRope.AddTile(TileID.Loom);
            recipeRope.AddIngredient(ModContent.ItemType<HempFiber>(), 1);
            recipeRope.Register();


            Recipe recipeSilk = Recipe.Create(ItemID.Silk, 1);
            recipeSilk.AddTile(TileID.Loom);
            recipeSilk.AddIngredient(ModContent.ItemType<HempFiber>(), 3);
            recipeSilk.Register();

            Recipe recipeBook = Recipe.Create(ItemID.Book, 3);
            recipeBook.AddIngredient(ModContent.ItemType<Paper>(), 100);
            recipeBook.AddIngredient(ItemID.Leather);
            recipeBook.AddTile(TileID.WorkBenches);
            recipeBook.Register();

            Recipe recipeSilt = Recipe.Create(ItemID.SiltBlock, 1);
            recipeSilt.AddIngredient(ItemID.StoneBlock, 5);
            recipeSilt.AddTile(ModContent.TileType<MortarAndPestle>());
            recipeSilt.Register();

            Recipe recipeSand = Recipe.Create(ItemID.SandBlock, 1);
            recipeSand.AddIngredient(ItemID.HardenedSand);
            recipeSand.AddTile(ModContent.TileType<MortarAndPestle>());
            recipeSand.Register();
        }
        public override void AddRecipeGroups()
        {
            RecipeGroup SilverBarRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.SilverBar)}", ItemID.SilverBar, ItemID.TungstenBar);
            RecipeGroup GoldBarRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldBar)}", ItemID.GoldBar, ItemID.PlatinumBar);
            RecipeGroup CopperBarRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperBar)}", ItemID.CopperBar, ItemID.TinBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.SilverBar), SilverBarRecipeGroup);
            RecipeGroup.RegisterGroup(nameof(ItemID.CopperBar), CopperBarRecipeGroup);
            RecipeGroup.RegisterGroup(nameof(ItemID.GoldBar), GoldBarRecipeGroup);
        }

    }
      
    public static class gENERALeXTENSIONS
    {
     
        /*public static float Distance(this Vector2 a, Vector2 b)
        {
            float dist = MathF.Pow(b.X - a.X, 2) + MathF.Pow(b.Y - a.Y, 2);
            dist = MathF.Sqrt(dist);
            return dist;
        }*/
    }
}
