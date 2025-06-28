
using Eclipse.Content.Buffs;
using Eclipse.Content.Items.Placeable;
using Eclipse.Content.Items.Material;
using System.Collections.Generic;
using Terraria.Localization;
using Eclipse.Content.Items.Weed;
namespace Eclipse.Content.Items.Salves

{
    public class ThcSalve : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 18;
            Item.consumable = true;
            Item.maxStack = 9999;
      
            Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.UseSound = SoundID.Item3;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.potion = true;
            Item.healLife = 20;
            Item.rare = 2;
        }
        public override void GetHealLife(Player player, bool quickHeal, ref int healValue)
        {
            // Make the item heal half the player's max health normally, or one fourth if used with quick heal
            healValue = 20;
        }
        public override bool? UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Relaxed>(), 3600);
            return base.UseItem(player);
        }
        public override void AddRecipes()
        {
            CreateRecipe(3)
               .AddTile<Tiles.MortarAndPestle>()
                .AddIngredient(ModContent.ItemType<Marijauna>(), 1)
                .AddIngredient(ModContent.ItemType<Bowl>(), 3)
              .Register();
        }

    }
}
