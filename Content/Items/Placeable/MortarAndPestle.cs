using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eclipse.Content.Items.Placeable
{
    public class MortarAndPestle : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.MortarAndPestle>());
            Item.width = 28; // The item texture's width
            Item.height = 14; // The item texture's height
            Item.value = 150;
        }

        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.CraftingObjects;
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddTile(TileID.WorkBenches)
                .AddIngredient(ItemID.Obsidian, 20)
                .Register();
        }
    }
}
