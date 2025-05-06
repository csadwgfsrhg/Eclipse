


using System.Collections.Generic;
using Terraria.Localization;
using Terraria.Utilities;

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
        public override int ChoosePrefix(UnifiedRandom rand)
        {
            return ModContent.PrefixType<Mutated>();
        }



    }
    
    public class Mutated : ModPrefix 
    {

        public override PrefixCategory Category => PrefixCategory.Custom;

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




