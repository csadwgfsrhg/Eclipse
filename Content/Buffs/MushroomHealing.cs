using Eclipse.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipse.Content.Buffs
{

    public class MushroomHealing : ModBuff
    {
        int cooldown = 0;
        public override void Update(Player player, ref int buffIndex)
        {
            cooldown++;
            if (cooldown > 15)
            {
                player.statLife += 1;
                player.HealEffect(1);

                cooldown = 0;
            }

        }

    }
}