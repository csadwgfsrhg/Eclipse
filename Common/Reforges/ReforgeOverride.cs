


using Eclipse.Common.Items;
using Eclipse.Content.Items.Runes;
using System.Collections.Generic;
using System.Threading;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.WorldBuilding;
using static Eclipse.Content.Items.Runes.BouncyRune;
using static Eclipse.Content.Items.Runes.ShinyItems;
using static System.Net.Mime.MediaTypeNames;

namespace Eclipse.Common.Reforges;






public class ReforgeOverride : GlobalItem
{
    public override int ChoosePrefix(Item item, UnifiedRandom rand)
    {
        //ModContent.PrefixType<Mutated>(),
        //   List<int> UniversalPrefixesIDs = [ ModContent.PrefixType<Simple>()];
        // List<int> UniversalPrefixesIDs = [36, 37, 38, 39, 40, 41, 53, 54, 55, 56, 57, 59, 60, 61];


        //return UniversalPrefixesIDs[Main.rand.Next(UniversalPrefixesIDs.Count)];
        return  -1;
   }

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
        if (item.prefix == 0 && (item.pick >= 1 || item.axe >= 1 || item.hammer >= 1) && (Main.mouseItem.ModItem is TyfloiteGeode))
        {

            Main.mouseItem.TurnToAir();
            item.Prefix(0);
            item.Prefix(ModContent.PrefixType<Shiny>());


        }
        if (item.prefix == 0 &&  (item.DamageType == DamageClass.Melee ) && (Main.mouseItem.ModItem is BouncyRune))
        {

            Main.mouseItem.TurnToAir();
            item.Prefix(0);
            item.Prefix(ModContent.PrefixType<Bouncy>());


        }
        //item.accessory
        if (item.rare < 1 && item.prefix == 0 && (item.damage >= 0) && (Main.mouseItem.ModItem is WoodScalingRune))
        {
            Main.mouseItem.TurnToAir();
            item.rare = 1;
            item.Prefix(0);
            item.Prefix(ModContent.PrefixType<Scaling>());
        }
        if (item.rare < 2 && item.prefix == 0 && (item.damage >= 0) && (Main.mouseItem.ModItem is StoneScalingRune))
        {
            Main.mouseItem.TurnToAir();
            item.rare = 2;
            item.Prefix(0);
            item.Prefix(ModContent.PrefixType<Scaling>());
        }
        if (item.rare < 3 && item.prefix == 0 && (item.damage >= 0) && (Main.mouseItem.ModItem is CopperScalingRune))
        {
            Main.mouseItem.TurnToAir();
            item.rare = 3;
            item.Prefix(0);
            item.Prefix(ModContent.PrefixType<Scaling>());
        }
        if (item.rare < 4 && item.prefix == 0 && (item.damage >= 0) && (Main.mouseItem.ModItem is SilverScalingRune))
        {
            Main.mouseItem.TurnToAir();
            item.rare = 4;
            item.Prefix(0);
            item.Prefix(ModContent.PrefixType<Scaling>());
        }
        if (item.rare < 5 && item.prefix == 0 && (item.damage >= 0) && (Main.mouseItem.ModItem is GoldScalingRune))
        {
            Main.mouseItem.TurnToAir();
            item.rare = 5;
            item.Prefix(0);
            item.Prefix(ModContent.PrefixType<Scaling>());
        }

        if (item.prefix == 0 && (item.damage >= 0 ) && (Main.mouseItem.ModItem is SimpleRune))
        {
            Main.mouseItem.TurnToAir();
            item.Prefix(0);
            item.Prefix(ModContent.PrefixType<Simple>());
        }
        if ((item.prefix == 0 && //item.type == ItemID.SlimeGun ||
         item.type == ItemID.SlimeStaff
        //|| item.type == ItemID.StickyGrenade
        //  || item.type == ItemID.BouncyGrenade
     //   || item.type == ItemID.HealingPotion
      //  || item.type == ItemID.SlimeHook
       // || item.type == ItemID.LesserHealingPotion
        ) && (Main.mouseItem.ModItem is MutatedGenome))
        {

            Main.mouseItem.TurnToAir();
            item.Prefix(0);
            item.Prefix(ModContent.PrefixType<Mutated>());


        }

        return base.CanRightClick(item);
    }

}

