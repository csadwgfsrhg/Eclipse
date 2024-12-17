using Terraria;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.WorldBuilding;
using Terraria.ID;


namespace Fgmod.Gen
{
    internal class HellGen : GenPass
    {
        public HellGen(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Altering Hell";


            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = Main.maxTilesY - 200; j < Main.maxTilesY; j++)
                {
         
                    WorldGen.digTunnel(i, j, 0, 0, 1, 1, false);
            

                }
            }

            }
        }
    }





    