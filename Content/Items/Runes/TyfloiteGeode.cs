

namespace Eclipse.Content.Items.Runes
{

    public class TyfloiteGeode : ModItem

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
    public class ShinyItems : GlobalTile
    {

        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {


            Player player = Main.LocalPlayer;
            if (player.HeldItem.prefix == ModContent.PrefixType<Shiny>() && type == TileID.Stone)

            {
                Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.GemAmethyst, 0, 0, Main.rand.Next(255), Color.Purple, Main.rand.NextFloat(.5f, 1f));

                if (Main.rand.NextBool(5))
                {
                    if (Main.rand.NextBool(10))
                        Item.NewItem(null, new Vector2(i * 16, j * 16), ItemID.SilverCoin, Main.rand.Next(99));
                    else
                        Item.NewItem(null, new Vector2(i * 16, j * 16), ItemID.CopperCoin, Main.rand.Next(99));

                }


            }



        }
        public class Shiny : ModPrefix
        {


            public override bool CanRoll(Item item)
                   => true;

            public override PrefixCategory Category
                => PrefixCategory.AnyWeapon;

            public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
            {


                useTimeMult *= .9f;

            }

            public override void Apply(Item item)
            {
                //
            }


        }
    }
}