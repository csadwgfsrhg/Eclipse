


namespace Eclipse.Content.Items.Runes
{

    public class GoldScalingRune : ModItem

    {
        public override bool CanRightClick() => true;
        public override void SetDefaults()
        {
            Item.rare = 5;

            Item.width = 20;
            Item.height = 20;
            Item.consumable = true;
      
        }




    }
}




   