using Eclipse.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipse.Content.Buffs
{

    public class GlowingMushroomHealing : ModBuff
    {
        int cooldown = 0;
        public override void Update(Player player, ref int buffIndex)
        {
            cooldown++;
            if (cooldown > 15)
            {
                player.statMana += 1;
                player.ManaEffect(1);

                cooldown = 0;
            }

        }

    }
}