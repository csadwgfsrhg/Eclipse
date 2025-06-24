
using System.Collections.Generic;

using Terraria.IO;

using Terraria.WorldBuilding;

using Terraria.Utilities;
using Eclipse.Content.Items.Placeable.Weed;
namespace Eclipse.Common
{
    public class WeedSystem : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int plantindex = tasks.FindIndex(genpass => genpass.Name.Equals("Flowers"));
            if (plantindex != -1)
            {
                tasks.Insert(plantindex + 1, new WeedPass("WEED", 1000f));
            }
        }
    }
    public class WeedPass : GenPass
    {
        public WeedPass(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "LET THERE BE WEED";

            //int[] tileTypes = [ModContent.TileType<WeedTile>()];

            // To not be annoying, we'll only spawn 15 Example Rubble near the spawn point.
            // This example uses the Try Until Success approach: https://github.com/tModLoader/tModLoader/wiki/World-Generation#try-until-success

            GenWeed();
        }
        public static void GenWeed()
        {
            int Type2Place = ModContent.TileType<WeedTile>();

            int numweed = 200;

            if (Main.maxTilesX > 4200)
                numweed = 550;

            if (Main.maxTilesX > 6400)
                numweed = 700;

            for (int k = 0; k < 200; k++)
            {
                bool success = false;
                int attempts = 0;

                while (!success)
                {
                    attempts++;
                    if (attempts > 10000)
                    {
                        break;
                    }

                    Dictionary<int, short> WeedGrowTiles = new Dictionary<int, short>();
                    WeedGrowTiles.Add(TileID.Grass, 16 * 12);
                    WeedGrowTiles.Add(TileID.CrimsonGrass, 16 * 4);
                    WeedGrowTiles.Add(TileID.CorruptGrass, 0);
                    WeedGrowTiles.Add(TileID.MushroomGrass, 16 * 8);

                    int x = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
                    int y = WorldGen.genRand.Next(200, Main.maxTilesY - 200);

                    var shit = Framing.GetTileSafely(x, y);
                    var piss = Framing.GetTileSafely(x, y - 1);
                    
                    if (WeedGrowTiles.ContainsKey(shit.TileType) && !WorldGen.SolidTile(x,y-1))
                    {
                        WeightedRandom<short> ran = new WeightedRandom<short>();
                        ran.Add(0, 0.75);
                        ran.Add(48, 0.2);
                        ran.Add(96, 0.05);
                        WorldGen.PlaceTile(x, y - 1, Type2Place, true, true);
                        piss.TileFrameX = ran.Get();
                        piss.TileFrameY = WeedGrowTiles[shit.TileType];
                        success = Main.tile[x, y - 1].TileType == Type2Place;
                    }

                }
            }
        }
    }
}
