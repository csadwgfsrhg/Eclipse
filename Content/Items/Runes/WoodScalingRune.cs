


using System.Collections.Generic;
using Terraria.GameContent.UI;
using static Eclipse.Content.Items.Runes.ShinyItems;

namespace Eclipse.Content.Items.Runes
{

    public class WoodScalingRune : ModItem

    {

        public override void SetDefaults()
        {
            Item.rare = 1;

            Item.width = 20;
            Item.height = 20;
            Item.consumable = true;

        }

    }
    public class ScalingStats : GlobalItem
    {
       
       
        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
            if (item.prefix == ModContent.PrefixType<Scaling>())
            {
                
                item.damage = (int)(item.OriginalDamage * (float)((1 + (item.rare  - item.OriginalRarity ) / 2.2f ) ));


            }
        }
     
    }
        public class Scaling : ModPrefix
        {


            public override bool CanRoll(Item item)
                   => true;

            public override PrefixCategory Category
                => PrefixCategory.AnyWeapon;

            public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
            {
            
           
        }
        public override void ModifyValue(ref float valueMult)
        {
          
        }
        public override void Apply(Item item)
            {
                
            }


        }
    }

    

    





   