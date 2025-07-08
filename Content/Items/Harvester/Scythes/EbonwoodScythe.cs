
using Eclipse.Common.Items;
using Terraria.DataStructures;

namespace Eclipse.Content.Items.Harvester.Scythes
{
    public class EbonwoodScythe : ScytheAI
    {
        public override void SetStaticDefaults()
        {
            Item.width = 62;
            Item.damage = 20;
            Item.height = 56;
            Item.rare = 0;
            Item.shoot = ModContent.ProjectileType<EbonwoodScytheProj>();
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.autoReuse = false;
        }


       

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Ebonwood, 25);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
    public class EbonwoodScytheProj : ScytheProj
    {
        public override string Texture => "Eclipse/Content/Items/Harvester/Scythes/EbonwoodScythe";
        public override void SetStaticDefaults()
        {
           

            Projectile.width = 62;
            Projectile.height = 56;
            Projectile.timeLeft = 40;


        }

    }
}