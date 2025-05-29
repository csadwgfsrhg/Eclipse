using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ObjectData;

namespace Eclipse.Content.Tiles.Weed
{
    public class MarijuanaItem : ModItem
    {
        public override string Texture => "Eclipse/Content/Tiles/Weed/MarijuanaSeed";
        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 14;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Marijuana>();

        }
    }

    public class Marijuana : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            //TileObjectData.newTile.Height = 1;
            //TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16 };
            //TileObjectData.newTile.Origin = new Point16(1, 3);
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.Width = 1;
            /*ModTranslation name = CreateMapEntryName();
            name.SetDefault("Tyfloite Crystal");*/
            AddMapEntry(new Color(37, 122, 40));
            TileObjectData.addTile(Type);
        }
        public override void PlaceInWorld(int i, int j, Item item)
        {
            base.PlaceInWorld(i, j, item);
        }

        public override void RandomUpdate(int i, int j)
        {
            //TileObjectData.newTile(Type);
            //TileObject.Place(this.tileob)
            WorldGen.PlaceTile(i, j, Type, true);
        }
        public override bool RightClick(int i, int j)
        {
            //WorldGen.ReplaceTile(i, j, (ushort)ModContent.TileType<MarijuanaGrowth2>(), 0);
            //WorldGen.Place3x3(i, j, (ushort)ModContent.TileType<MarijuanaGrowth2>(), 0);
            Main.NewText("HI");

            Tile tile = Framing.GetTileSafely(i, j);
            tile.TileFrameX += 18;

            return false;
        }
        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            return true;
        }
    }
}
