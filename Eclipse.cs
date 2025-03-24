using System.Diagnostics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

namespace Eclipse;
public class Fgmod : Mod
{
    public override void Load()
    {
        On_Player.UpdateManaRegen += On_Player_UpdateManaRegen;
    }

    private void On_Player_UpdateManaRegen(On_Player.orig_UpdateManaRegen orig, Player self)
    {
        if(120 <= self.manaRegenCount && self.statManaMax2 > self.statMana)
        {
            self.ManaEffect(self.manaRegen + (int)(self.manaRegenBonus / 15f) + (int)(self.statManaMax2 / 100f));
            self.statMana += self.manaRegen + (int)(self.manaRegenBonus / 15f) + (int)(self.statManaMax2 / 100f);
            self.manaRegenCount = 0;
        }

        self.manaRegenCount += 1;
    
      //  Main.NewText(self.manaRegenBonus);
    }
}