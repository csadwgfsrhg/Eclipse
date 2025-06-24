using Eclipse.Content.Items.Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using static tModPorter.ProgressUpdate;
namespace Eclipse.Content.Items.Weed

{
    public class RollingPaper : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;

            Item.maxStack = 9999;
            //Item.value = Item.buyPrice(platinum: 2);
            Item.rare = ItemRarityID.White;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<HempFiber>(), 1);
            recipe.AddTile(TileID.Loom);
            recipe.Register();

        }
    }
}
