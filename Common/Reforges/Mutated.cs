

using Eclipse.Content.Items.Magic;
using Eclipse.Content.Items.Runes;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Utilities;

namespace Eclipse.Common.Reforges;
public class Mutated : ModPrefix
{

    public override PrefixCategory Category => PrefixCategory.Custom;
    public override bool CanRoll(Item item)
    {
        return false;
    }

    public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
    {
        damageMult *= 1f + 0.20f;
    }

    // Modify the cost of items with this modifier with this function.
    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1f + 0.05f;
    }

    // This is used to modify most other stats of items which have this modifier.
    public override void Apply(Item item)
    {
        //
    }
    public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
    {
  
        yield return new TooltipLine(Mod, "PrefixWeaponAwesome", "s")
        {
            IsModifier = true, 
        };
      
        yield return new TooltipLine(Mod, "PrefixWeaponAwesomeDescription", "s")
        {
            IsModifier = true,
        };
    }

  
}

