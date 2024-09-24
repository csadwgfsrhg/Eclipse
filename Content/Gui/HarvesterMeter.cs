
using System;

using Terraria;
using Terraria.ID;

using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

using Terraria.GameContent;
using System.Collections.Generic;



namespace Eclipse.Content.Gui
{

    public class HarvestVar : ModPlayer
    {

        public int HungerMax = 50;
        public int Cropgrowth = 100;
        public int Hunger = 0;


        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {

            if (Hunger > HungerMax)
            {
                Hunger = HungerMax;
            }
           //draw meter under player when harvesting weapon is held


        }

    }

    public class HarvestDamage : DamageClass
    {
        public override bool UseStandardCritCalcs => true;

        public override void SetStaticDefaults()
        {
        }

        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            if (damageClass == Generic) return StatInheritanceData.Full;
            return StatInheritanceData.None;
        }

        public override bool GetEffectInheritance(DamageClass damageClass) => false;

        public override void SetDefaultStats(Player player)
        {
        }

    }
}