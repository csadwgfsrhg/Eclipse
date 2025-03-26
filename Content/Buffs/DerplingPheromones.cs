using Eclipse.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipse.Content.Buffs
{

        public class DerplingPheromones : ModBuff
        {
            public override void Update(Player player, ref int buffIndex)
            {
                // Use a ModPlayer to keep track of the buff being active
                player.GetModPlayer<EclipseModPlayer>().DerplingPheromones = true;
            }
        }
}
