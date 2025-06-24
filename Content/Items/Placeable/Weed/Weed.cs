
using System.Collections.Generic;
using System.Linq;

using Terraria.DataStructures;

using Terraria.ObjectData;
using Terraria.Enums;

using Eclipse.Content.Items.Weed;
using Terraria.Audio;
using Terraria.Utilities;
using Mono.Cecil;

namespace Eclipse.Content.Items.Placeable.Weed
{
    public abstract class Seed : ModItem
    {
        //public virtual

        public override string Texture => "Eclipse/Content/Items/Placeable/Weed/WeedSeed";
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
            Item.createTile = ModContent.TileType<WeedTile>();
        }
        
    }
    public class WeedSeed : Seed
    {

    }

  
    public class WeedTile : ModTile
    {
        public override string Texture => "Eclipse/Content/Items/Placeable/Weed/WeedTile";
        public override void SetStaticDefaults()
        {
            TileID.Sets.SwaysInWindBasic[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            //TileObjectData.newTile.Height = 1;
            //TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16 };
            //TileObjectData.newTile.Origin = new Point16(-2, 3);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.Width = 1;
            /*ModTranslation name = CreateMapEntryName();
            name.SetDefault("Tyfloite Crystal");*/
            AddMapEntry(new Color(37, 122, 40));
            TileObjectData.addTile(Type);
            HitSound = SoundID.Grass;
        }
        public override void PlaceInWorld(int i, int j, Item item)
        {
            Tile tiol = Framing.GetTileSafely(i, j);

            tiol.TileFrameX = 0;
        //    if (item.type == ModContent.ItemType<ShroomSeed>())
             //   tiol.TileFrameY = 16 * 8;
            if (item.type == ModContent.ItemType<WeedSeed>())
                tiol.TileFrameY = 16 * 12;
         //   if (item.type == ModContent.ItemType<OpiumSeed>())
         //       tiol.TileFrameY = 0;
         //   if (item.type == ModContent.ItemType<MethSeed>())
            //    tiol.TileFrameY = 16 * 4;


            //NVM IDC


            //ghost tiles ig (BADCODE!) 
/*            WorldGen.PlaceTile(i, j - 1, Type, true, true);
            Framing.GetTileSafely(i, j - 1).TileFrameY = short.MinValue;
            WorldGen.PlaceTile(i, j - 2, Type, true, true);
            Framing.GetTileSafely(i, j - 2).TileFrameY = short.MinValue;*/
            
        }

        public override bool CanPlace(int i, int j)
        {
            int[] GoodTiles = { TileID.Dirt, TileID.Grass, TileID.JungleGrass, TileID.Mud, TileID.MushroomGrass, TileID.CorruptGrass, TileID.CrimsonGrass,  };
            Tile below = Framing.GetTileSafely(i, j + 1);
            return GoodTiles.Contains(below.TileType);
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
        {
            //tileFrameX = 16 * 9;
            //tileFrameY = 16 * 12;

            width = 16 * 3;
            height = 16 * 4;
            offsetY = -16 * 3;

            /*if (Framing.GetTileSafely(i, j + 1).TileType == Type)
            {
                width = 0;
                height = 0;
            }*/

            base.SetDrawPositions(i, j, ref width, ref offsetY, ref height, ref tileFrameX, ref tileFrameY);
        }

        public override void RandomUpdate(int i, int j)
        {
            Tile tiol = Framing.GetTileSafely(i, j);
            /*Tile tiol2 = Framing.GetTileSafely(i, j + 1);
            Tile tio33l = Framing.GetTileSafely(i, j + 2);*/

            if (tiol.TileFrameX < 144)
                if (Main.rand.NextBool(7))
                {
                    tiol.TileFrameX += 16 * 3;
                
                    SoundEngine.PlaySound(SoundID.Grass);
                }
        }

        public override bool RightClick(int i, int j)
        {
            Tile tiol = Framing.GetTileSafely(i, j);
            Tile tiol2 = Framing.GetTileSafely(i, j + 1);
            Tile tio33l = Framing.GetTileSafely(i, j + 2);
            if (tiol.TileFrameX > 96 && tiol.TileFrameY > 0)
            {
                Harvest(i, j, 6);
                SoundEngine.PlaySound(SoundID.Grass);
                return true;
            }
            if (tiol2.TileFrameX > 96 && tiol2.TileFrameY > 0)
            {
                Harvest(i, j - 1, 6);
                SoundEngine.PlaySound(SoundID.Grass);
            }
            if (tio33l.TileFrameX > 96 && tio33l.TileFrameY > 0)
            {
                Harvest(i, j - 2, 6);
                SoundEngine.PlaySound(SoundID.Grass);
            }
            return false;
        }
        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            
            Tile tiol = Framing.GetTileSafely(i, j);
            if (tiol.TileFrameX > 96)
                Harvest(i, j, 2);
         
            Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), new Vector2(i, j).ToWorldCoordinates(), ModContent.ItemType<HempFiber>(), Main.rand.Next(2, 7));
            base.KillTile(i, j, ref fail, ref effectOnly, ref noItem);
        }
        public override void MouseOver(int i, int j) // show weed icon on mouse
        {
            Tile tiol = Framing.GetTileSafely(i, j);
            if (tiol.TileFrameX > 96)
            {
                Player player = Main.LocalPlayer;
                player.cursorItemIconEnabled = true;
                player.cursorItemIconID = ModContent.ItemType<Marijauna>();
            }
        }
        public override bool AutoSelect(int i, int j, Item item) // make it yellow
        {
            return base.AutoSelect(i, j, item);
        }

        public void Harvest(int i, int j, int SeedChance = 5)
        {
          
          
      

            Tile tile = Framing.GetTileSafely(i, j);
            /*Tile tiol2 = Framing.GetTileSafely(i, j + 1);
            Tile tio33l = Framing.GetTileSafely(i, j + 2);*/
            tile.TileFrameX -= 16 * 3;
            /*tiol2.TileFrameX -= 16 * 3;
            tio33l.TileFrameX -= 16 * 3*/;
            IEntitySource sex = WorldGen.GetItemSource_FromTileBreak(i, j);
            Item.NewItem(sex, new Vector2(i, j).ToWorldCoordinates(), ModContent.ItemType<Marijauna>(), 1);

            WeightedRandom<int> rando = new WeightedRandom<int>();
            rando.Add(1, 0.75f);
            rando.Add(2, 0.25f);
            rando.Add(3, 0.07f);
            
           // Item.NewItem(sex, new Vector2(i, j).ToWorldCoordinates(), ModContent.ItemType<HempFiber>(), rando.Get());

            if (Main.rand.NextBool(SeedChance))
                Item.NewItem(sex, new Vector2(i, j).ToWorldCoordinates(), ModContent.ItemType<WeedSeed>(), 1);
        }
    }
}
