
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Eclipse.Content.Items.Placeable;
namespace Eclipse.Content.Tiles.IceStructure
{


    public class ThermalPlatingWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
        


            AddMapEntry(new Color(88, 61, 52));
        }

    }

}
          