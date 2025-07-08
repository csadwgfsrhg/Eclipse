using Eclipse.Common.Items;
using Terraria;
using Terraria.DataStructures;


namespace Eclipse.Content.Items.Harvester.Scythes
{
    public class PlatinumObsidianScythe : ScytheAI
    {
        public override void SetStaticDefaults()
        {
            Item.width = 94;
            Item.damage = 27;
            Item.height = 84;
            Item.rare = 2;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.shoot = ModContent.ProjectileType<PlatinumObsidianScytheProjectile>();
            Item.autoReuse = false;
        }
     


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Obsidian, 40);
            recipe.AddIngredient(ItemID.Diamond, 10);
            recipe.AddIngredient(ItemID.PlatinumBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
    public class PlatinumObsidianScytheProjectile : ScytheProj
    {
        public override string Texture => "Eclipse/Content/Items/Harvester/Scythes/PlatinumObsidianScythe";
        public override void SetStaticDefaults()
        {

            Projectile.width = 94;
            Projectile.height = 84;
            Projectile.timeLeft = 30;
            
        }

    }
}