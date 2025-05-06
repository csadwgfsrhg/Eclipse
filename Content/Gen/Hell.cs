using Terraria;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.WorldBuilding;
using Terraria.ID;
using Eclipse.Content.Tiles;
using Terraria.Graphics.Shaders;


namespace Eclipse.Content.Gen
{
    internal class HellGen : GenPass
    {
        public HellGen(string name, float weight) : base(name, weight) { }
        int x = 0;
        int y = 0;
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Altering Hell";
 
            Tile tile = Main.tile[x, y];
            Point point = new Point(x, y);

            //






            ShapeData shapeData = new ShapeData();
            WorldUtils.Gen(point, new Shapes.Circle(Main.rand.Next(10), Main.rand.Next(20)), new Actions.Blank().Output(shapeData));
            {
          



            };




           // WorldGen.(i, j, WorldGen.genRand.Next(4, 10), WorldGen.genRand.Next(9, 15), ModContent.TileType<Basalt>());
                   //     WorldGen.TileRunner(i, j, WorldGen.genRand.Next(4, 10), WorldGen.genRand.Next(9, 15), TileID.Ash);
         
               


                }
             }
          }
    




    