


namespace Eclipse.Content.Items.Ranged.RubbleLaunchers
{
    public class Slingshot : ModItem

    {
     
        public override void SetDefaults()   
        {
            Item.width = 14;
            Item.height = 26;
            Item.rare = 0;
            Item.damage = 7;
            Item.DamageType = DamageClass.Ranged;
            Item.useAmmo = AmmoID.Sand;
            Item.knockBack = 1;
            Item.shoot = 10;
            Item.shootSpeed = 10f;
            Item.useTime = 34;
            Item.useAnimation = 34;
 
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item152;


        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, -8);
          
        }
  
        public override void AddRecipes()
        {

            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("Wood", 10);
            recipe.AddTile(TileID.WorkBenches);
               recipe.Register();
        }
    }
}



   