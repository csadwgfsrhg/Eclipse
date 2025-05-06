


namespace Eclipse.Content.Items.Runes
{

    public class StoneScalingRune : ModItem

    {
        public override bool CanRightClick() => true;
        public override void SetDefaults()
        {
            Item.rare = 2;

            Item.width = 20;
            Item.height = 20;
            Item.consumable = true;
       
        }




    }
}




   