


namespace Eclipse.Content.Items.Runes
{

    public class WoodScalingRune : ModItem

    {
        public override bool CanRightClick() => true;
        public override void SetDefaults()
        {
            Item.rare = 1;

            Item.width = 20;
            Item.height = 20;
            Item.consumable = true;

        }




    }
}




   