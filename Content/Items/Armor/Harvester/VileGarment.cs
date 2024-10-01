﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Eclipse.Content.Gui;

namespace Eclipse.Content.Items.Armor.Harvester
{
		[AutoloadEquip(EquipType.Body)]
	public class VileGarment: ModItem
	{

		
			public override void SetDefaults() {
			Item.width = 30;
			Item.height = 20;
			Item.maxStack = 1;
			Item.value = 100;
			Item.defense = 3;
            Item.rare = 2;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 6);
            recipe.AddIngredient(ItemID.VilePowder, 15);
            recipe.AddIngredient(ItemID.RottenChunk, 7);
            recipe.AddIngredient(ItemID.Leather, 1);
            recipe.AddIngredient(ItemID.WormTooth, 2);

            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}