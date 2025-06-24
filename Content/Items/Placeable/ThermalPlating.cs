using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eclipse.Content.Items.Placeable
{
	public class ThermalPlating : ModItem
	{
			public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.IceStructure.ThermalPlating>());
			Item.width = 12;
			Item.height = 12;
			Item.value = 0;
		}
	}
}