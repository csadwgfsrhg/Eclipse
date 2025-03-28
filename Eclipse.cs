using System.Diagnostics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

using Eclipse.Common;
using Terraria;
using Terraria.DataStructures;

namespace Eclipse;
public class Fgmod : Mod
{

    public override void Load()
    {
        On_Player.UpdateManaRegen += On_Player_UpdateManaRegen;
    }

    private void On_Player_UpdateManaRegen(On_Player.orig_UpdateManaRegen orig, Player self)
    {
        if (self.statMana < 0)
        {
            self.statMana = 0;
        }
        var poo = self.manaRegen + (int)(self.manaRegenBonus / 10f) + (int)(self.statManaMax2 / 60f) - (int)((self.slotsMinions) * 2);
        if (120 <= self.manaRegenCount && (self.statMana < self.statManaMax2 || poo < 0))
        {
            self.ManaEffect(poo);
            self.statMana += poo;
            self.manaRegenCount = 0;
          
    
        }
        self.manaRegenCount += 1;

    }
}
