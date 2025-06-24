
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Eclipse.Content.Items.Placeable;
namespace Eclipse.Content.Tiles.IceStructure
{


    public class ThermalScaffolding : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = false;
            HitSound = SoundID.Tink;



            AddMapEntry(new Color(88, 61, 52));
        }

    }

}
          