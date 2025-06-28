
using Eclipse.Content.Buffs;
using Eclipse.Content.Items.Placeable;
using Eclipse.Content.Items.Material;
using System.Collections.Generic;
using Terraria.Localization;
namespace Eclipse.Content.Items.Salves

{
    public class HealingSalve : ModItem
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
            Item.healLife = 10;
            Item.rare = ItemRarityID.Blue;
        }
        public override void GetHealLife(Player player, bool quickHeal, ref int healValue)
        {
            // Make the item heal half the player's max health normally, or one fourth if used with quick heal
            healValue = 10;
        }
        public override bool? UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<MushroomHealing>(), 1200);
            return base.UseItem(player);
        }
        public override void AddRecipes()
        {
            CreateRecipe(3)
               .AddTile<Tiles.MortarAndPestle>()
              .AddIngredient(ItemID.Mushroom, 3)
               .AddIngredient(ItemID.Daybloom, 1)
                .AddIngredient(ModContent.ItemType<Bowl>(), 3)
              .Register();
        }

    }
}
