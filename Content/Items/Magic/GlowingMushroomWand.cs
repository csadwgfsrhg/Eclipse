

using Eclipse.Common;
using Eclipse.Content.Items.Harvester.Scythes;
using Eclipse.Content.Projectiles.Magic;
using Terraria.DataStructures;
using Terraria.GameContent;

namespace Eclipse.Content.Items.Magic
{
    public class GlowingMushroomWand : ModItem

    {
        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 48;
            Item.rare = 2;
            Item.damage = 20;
            Item.DamageType = DamageClass.Magic;
            Item.shoot = ModContent.ProjectileType<MyceliumClump>();
            Item.shootSpeed = 4f;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.mana = 18;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item1;


        }




        public override void AddRecipes()
        {

            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GlowingMushroom, 25);
            recipe.AddIngredient(ModContent.ItemType<MushroomWand>(), 1);
            recipe.AddIngredient(ItemID.ManaCrystal, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}



   