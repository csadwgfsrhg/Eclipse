
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Eclipse.Content.Items.Placeable;
using Terraria.Localization;
using Terraria.ObjectData;
namespace Eclipse.Content.Tiles
{


    public class MortarAndPestle : ModTile
    {
    
           public override void SetStaticDefaults()
        {
            // Properties
   
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.IgnoredByNpcStepUp[Type] = true; // This line makes NPCs not try to step up this tile during their movement. Only use this for furniture with solid tops.



            // Placement
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = [16, 18];
            TileObjectData.addTile(Type);

       

            // Etc
       
        }

      
    }

    }


          