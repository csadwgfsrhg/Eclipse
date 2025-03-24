
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Eclipse.Content.Items.Placeable;
namespace Eclipse.Content.Tiles
{


    public class Basalt : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            HitSound = SoundID.Tink;

            Main.tileBlendAll[Type] = true;


            AddMapEntry(new Color(88, 61, 52));
        }

    }

}
          