

using Eclipse.Common;
using Eclipse.Utilities.Extensions;
using Eclipse.Content.Items.Harvester.Scythes;
using Eclipse.Content.Projectiles.Magic;
using Eclipse.Content.Projectiles.Ranged;
using Terraria.DataStructures;
using Terraria.GameContent;

namespace Eclipse.Content.Items.Ranged.Guns.blunderbuss
{
    public class Blunderbuss : ModItem

    {
     
        public override void SetDefaults()   
        {
            Item.width = 54;
            Item.height = 18;
            Item.rare = 1;
            Item.damage = 16;
            Item.DamageType = DamageClass.Ranged;
            Item.useAmmo = AmmoID.Sand;

            Item.shoot = 10;
            Item.shootSpeed = 11f;
            Item.useTime = 40;
            Item.useAnimation = 40;
 
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item89;


        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12, 0);
          
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 3; i++)
            {

                velocity = velocity.RotatedByRandom(.3f);

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



   