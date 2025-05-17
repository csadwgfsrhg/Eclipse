


using System.Collections.Generic;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace Eclipse.Content.Items.Runes
{

    public class SimpleRune : ModItem

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

    public class Simple : ModPrefix
    {


        public override bool CanRoll(Item item)
               => true;

        public override PrefixCategory Category
            => PrefixCategory.AnyWeapon;

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
       
            damageMult *= 1.1f;
           knockbackMult *= 1.1f;
            useTimeMult *= .95f;
            shootSpeedMult *= 1.05f;

            critBonus += 3;
        }

        public override void Apply(Item item)
        {
            //
        }


    }
}    
    


