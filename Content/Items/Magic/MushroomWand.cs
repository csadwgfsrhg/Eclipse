

using Eclipse.Common;
using Eclipse.Content.Items.Harvester.Scythes;
using Eclipse.Content.Projectiles.Magic;
using Terraria.DataStructures;
using Terraria.GameContent;

namespace Eclipse.Content.Items.Magic
{
    public class MushroomWand : ModItem

    {
        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 38;
            Item.rare = 1;
            Item.damage = 16;
            Item.DamageType = DamageClass.Magic;
            Item.shoot = ModContent.ProjectileType<MyceliumClump>();
            Item.shootSpeed = 4f;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.mana = 16;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item1;


        }




        public override void AddRecipes()
        {

            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("Wood", 10);
            recipe.AddIngredient(ItemID.Mushroom, 3);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}



   