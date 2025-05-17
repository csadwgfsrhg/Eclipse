


namespace Eclipse.Content.Items.Runes
{

    public class BouncyRune : ModItem

    {
        public override void SetDefaults()
        {

            Item.rare = 3;

            Item.width = 20;
            Item.height = 20;
            Item.consumable = true;
          
        }


        public class Bouncy : ModPrefix
        {


            public override bool CanRoll(Item item)
                   => true;

            public override PrefixCategory Category
                => PrefixCategory.Melee;

            public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
            {

                scaleMult *= 2f;
                       knockbackMult *= 2f;
           
            }

            public override void Apply(Item item)
            {
                //
            }


        }

    }
}




   