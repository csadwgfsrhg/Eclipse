using Terraria.ModLoader;
using Terraria.WorldBuilding;
using System.Collections.Generic;
using Eclipse.Content.Gen;

namespace Eclipse.Content.Gen
{
    internal class WorldSystem : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int Corruption = tasks.FindIndex(t => t.Name.Equals("Corruption"));
            int SmoothWorld = tasks.FindIndex(t => t.Name.Equals("Smooth World"));
            if (SmoothWorld != -1)
            {
   
                tasks.Insert(SmoothWorld + 3, new HellGen("Penis", 320f));
            }
        }
    }
}