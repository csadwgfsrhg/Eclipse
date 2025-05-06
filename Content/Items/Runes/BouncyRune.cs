


namespace Eclipse.Content.Items.Runes
{

    public class BouncyRune : ModItem

    {
        public override bool CanRightClick() => true;
        public override void SetDefaults()
        {

            Item.rare = 3;

            Item.width = 20;
            Item.height = 20;
            Item.consumable = true;
          
        }




    }
}




   