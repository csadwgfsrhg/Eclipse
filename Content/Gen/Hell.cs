using Terraria;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.WorldBuilding;
using Terraria.ID;
using Eclipse.Content.Tiles;


namespace Eclipse.Content.Gen
{
    internal class HellGen : GenPass
    {
        public HellGen(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Altering Hell";

         


            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = Main.maxTilesY - 250; j < Main.maxTilesY; j++)
                {
                    if (j <= Main.maxTilesY - 200)
                    {
                        WorldGen.TileRunner(i, j, WorldGen.genRand.Next(4, 10), WorldGen.genRand.Next(9, 15), ModContent.TileType<Basalt>());
                    }

                    if (j >= Main.maxTilesY - 60)
                    {
                        WorldGen.TileRunner(i, j, WorldGen.genRand.Next(4, 10), WorldGen.genRand.Next(9, 15), TileID.Ash);
                    }
               


                }
             }
          }
       }
    }





    