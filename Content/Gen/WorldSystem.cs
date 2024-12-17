using Terraria.ModLoader;
using Terraria.WorldBuilding;
using System.Collections.Generic;
using Fgmod.Gen;

namespace Fgmod.Gen
{
    internal class WorldSystem : ModSystem
    {
    
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int FinalCleanup = tasks.FindIndex(t => t.Name.Equals("Final Cleanup"));
            if (FinalCleanup != -1)
            {
                tasks.Insert(FinalCleanup + 1, new HellGen("changing hell", 320f));
            }
        }
    }
}