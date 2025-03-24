using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipse.Common
{
    class EclipseModPlayer : ModPlayer
    {
        public override void Initialize()
        {
            base.Initialize();
            Player.manaRegen = 1;
        }
        public override void GetHealMana(Item item, bool quickHeal, ref int healValue)
        {
            base.GetHealMana(item, quickHeal, ref healValue);
        }
    }
}
