
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Eclipse.Content.Items.Placeable;
namespace Eclipse.Content.Tiles
{


    public class RubblePlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            //  Main.tile
            //       TileID.MagicalIceBlock
            AddMapEntry(new Color(88, 61, 52));
        }




        public override void RandomUpdate(int i, int j)
        {
            WorldGen.KillTile(i, j);
        }

    }
}


          