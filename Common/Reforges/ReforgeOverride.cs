

using Eclipse.Content.Items.Magic;
using Eclipse.Content.Items.Runes;
using System.Collections.Generic;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Eclipse.Common.Reforges;
public class ReforgeOverride : GlobalItem
{


   

    public override bool? PrefixChance(Item item, int pre, UnifiedRandom rand)
    {
        if (pre == -3 || pre == -1)
        {
            return false;
        }
      else
            return true;
    }
  


    public override bool CanRightClick(Item item)
    {

        bool canreforge = true;
        if ((item.type == ItemID.SlimeGun
            || item.type == ItemID.SlimeStaff
            || item.type == ItemID.StickyGrenade
            || item.type == ItemID.BouncyGrenade
            || item.type == ItemID.HealingPotion
            || item.type == ItemID.SlimeHook
            || item.type == ItemID.LesserHealingPotion
            ) && (Main.mouseItem.ModItem is MutatedGenome))
        {
       
            canreforge = true;



        }
        else
        {
            canreforge = false;
        }

        if (canreforge)
        {
          
            item.Prefix(0);
            item.Prefix(Main.mouseItem.prefix);
            Main.mouseItem.TurnToAir();


        }
        return base.CanRightClick(item);
    }

    }

