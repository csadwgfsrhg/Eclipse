﻿


using System.Collections.Generic;
using Terraria.Localization;
using Terraria.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace Eclipse.Content.Items.Runes
{

    public class MutatedGenome : ModItem

    {
        //       public override bool CanRightClick() => true;


      


        public override void SetDefaults()
        {
            Item.rare = 2;
        
            Item.width = 20;
            Item.height = 20;
            Item.consumable = true;
       
        }
       



    }
    
    public class Mutated : ModPrefix 
    {
 

        public override PrefixCategory Category => PrefixCategory.AnyWeapon;

        public override bool CanRoll(Item item)
        {
            return true;
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult *= 1f ;
        }

        public override void Apply(Item item)
        {
            //
        }


    }


}




