﻿

using Eclipse.Content.Projectiles.Harvester.Hunger;
using Terraria.DataStructures;

namespace Eclipse.Content.Items.Harvester.Hunger
{
    public class StrawDoll : ModItem

    {
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;
            Item.rare = 1;
            Item.damage = 35;
               Item.shoot = ModContent.ProjectileType<StrawDollProj>();
            Item.shootSpeed = 6f;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.mana = 40;
            Item.useStyle = 4;
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.AddIngredient(ItemID.Hay, 12);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }


      

    }
}


   