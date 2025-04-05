using Eclipse.Common.Items;


namespace Eclipse.Content.Items.Harvester.Scythes
{
    public class ObsidianScythe : ScytheAI
    {
        public override void SetStaticDefaults()
        {
            Item.width = 54;
            Item.damage = 20;
            Item.height = 42;
            Item.rare = 1;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.shoot = ModContent.ProjectileType<ObsidianScytheProjectile>();

        }




        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Obsidian, 100);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
    public class ObsidianScytheProjectile : ScytheProj
    {
        public override string Texture => "Eclipse/Content/Items/Harvester/Scythes/ObsidianScythe";
        public override void SetStaticDefaults()
        {

            Projectile.width = 54;
            Projectile.height = 42;
            Projectile.timeLeft = 30;
        }

    }
}