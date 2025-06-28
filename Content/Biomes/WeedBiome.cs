
using Eclipse.Content.Items.Placeable.Weed;
using System.Security.Cryptography.X509Certificates;
using Terraria.Graphics.Capture;

namespace Eclipse.Content.Biomes
{
    // Shows setting up two basic biomes. For a more complicated example, please request.
    public class TileCount : ModSystem
    {
        public int WeedTileCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            WeedTileCount = tileCounts[ModContent.TileType<WeedTile>()];
        }
   
    }
    public class WeedBiome : ModBiome
    {
      
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/WeedSong");
       
        public override bool IsBiomeActive(Player player)
        {
        
            // First, we will use the exampleBlockCount from our added ModSystem for our first custom condition
            bool b1 = ModContent.GetInstance<TileCount>().WeedTileCount >= 15;



            return b1 ;
        }

        // Declare biome priority. The default is BiomeLow so this is only necessary if it needs a higher priority.
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;
    }
}