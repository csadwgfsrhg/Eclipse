

using Terraria.DataStructures;


namespace Eclipse.Content.Items.Ranged.RubbleLaunchers
{
    public class Mawbuss : ModItem

    {
     
        public override void SetDefaults()   
        {
            Item.width = 78;
            Item.height = 36;
            Item.rare = 3;
            Item.damage = 25;
            Item.DamageType = DamageClass.Ranged;
            Item.useAmmo = AmmoID.Sand;
            Item.knockBack = 6;
            Item.shoot = 10;
            Item.shootSpeed = 15f;
            Item.useTime = 20;
            Item.useAnimation = 20;
 
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item89;


        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-18, 0);
          
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 2; i++)
            {

                velocity = velocity.RotatedByRandom(.2f);

                Projectile.NewProjectile(source, position, velocity * Main.rand.NextFloat(.8f, 1.5f), type, damage, knockback, player.whoAmI);



            }


            return false;
        }


        public override void AddRecipes()
        {

       //     Recipe recipe = CreateRecipe();
         //   recipe.AddRecipeGroup("Wood", 10);
          //  recipe.AddRecipeGroup("GoldBarRecipeGroup", 10);
         //   recipe.AddTile(TileID.Anvils);
         //      recipe.Register();
        }
    }
}



   