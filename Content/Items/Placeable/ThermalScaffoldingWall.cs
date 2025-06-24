using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eclipse.Content.Items.Placeable
{
	public class ThermalScaffoldingWall : ModItem
	{
			public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults() {
			Item.DefaultToPlaceableWall(ModContent.WallType<Tiles.IceStructure.ThermalScaffoldingWall>());
			Item.width = 12;
			Item.height = 12;
			Item.value = 0;
		}
	}
}