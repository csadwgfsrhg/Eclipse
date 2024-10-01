
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Eclipse.Content.Projectiles.Harvester.Crops;
using Eclipse.Content.Gui;
using System.Numerics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Xna.Framework.Input;


namespace Eclipse.Content.Items.Harvester.Trowels
{
	public class WoodenTrowel : ModItem
	{
        public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = 0;
			Item.noMelee = true;
            Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<PotatoCrop>();

        }
        int charge = 0;
        public override void HoldItem(Player player)
        {

			Vector2 CropPos = new Vector2(player.position.X + Main.rand.Next(-180, 180), player.position.Y +  Main.rand.Next(-180, 180));

            charge += player.GetModPlayer<HarvestVar>().Cropgrowth / 100;
			if (charge >= 150) {
			//	Projectile.NewProjectile(CropPos, );

				charge = 0;

            }
    
        }
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("Wood", 20);
            recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}