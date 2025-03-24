using Eclipse.Content.Items.Harvester.Trowels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;

namespace Eclipse.Common
{
    class EclipseModPlayer : ModPlayer
    {

        public bool ChitinBladeHeld = false; 
        public override void Initialize()
        {
            base.Initialize();
            Player.manaRegen = 1;
        }
        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
       
            ChitinBladeHeld = false;
        }


        public override void GetHealMana(Item item, bool quickHeal, ref int healValue)
        {
            base.GetHealMana(item, quickHeal, ref healValue);
        }
    }
}
