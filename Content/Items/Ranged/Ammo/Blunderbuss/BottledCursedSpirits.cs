


namespace Eclipse.Content.Items.Ranged.Ammo.Blunderbuss
{
    public class BottledCursedSpirits : ModItem

    {
        public override void SetDefaults()
        {
            Item.damage = 6;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.knockBack = 0f;
            Item.value = 10;  
            Item.rare = 2;
            Item.shoot = ModContent.ProjectileType<RubbleBall>();
            Item.shootSpeed = 1f;
            Item.ammo = AmmoID.Sand;

        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);

            recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.Register();
        }


    }
}
   