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
    public class Marijuana : ModItem
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
            Item.createTile = ModContent.TileType<MarijuanaGrowth1>();

        }
    }

    public class MarijuanaGrowth1 : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            //TileObjectData.newTile.Height = 1;
            //TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16 };
            //TileObjectData.newTile.Width = 1;
            //TileObjectData.newTile.Origin = new Point16(1, 3);
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            /*ModTranslation name = CreateMapEntryName();
            name.SetDefault("Tyfloite Crystal");*/
            AddMapEntry(new Color(37, 122, 40));
            TileObjectData.addTile(Type);
        }

        public override void RandomUpdate(int i, int j)
        {
            //TileObjectData.newTile(Type);
            //TileObject.Place(this.tileob)
            WorldGen.PlaceTile(i, j, Type, true);
        }
        public override void MouseOver(int i, int j)
        {
            if (Main.mouseLeft)
                WorldGen.PlaceTile(i, j, ModContent.TileType<MarijuanaGrowth2>(), true);
        }
    }
    
    public class MarijuanaGrowth2 : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            //TileObjectData.newTile.Height = 1;
            //TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16 };
            //TileObjectData.newTile.Width = 1;
            //TileObjectData.newTile.Origin = new Point16(1, 2);
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            /*ModTranslation name = CreateMapEntryName();
            name.SetDefault("Tyfloite Crystal");*/
            AddMapEntry(new Color(37, 122, 40));
            TileObjectData.addTile(Type);
        }

        public override void RandomUpdate(int i, int j)
        {
            //TileObjectData.newTile(Type);
            //TileObject.Place(this.tileob)
            WorldGen.PlaceTile(i, j, Type, true);
        }
    }
}
