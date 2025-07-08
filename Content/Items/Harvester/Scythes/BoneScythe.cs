
using Eclipse.Content.Projectiles.Harvester.Scythe;

using Terraria.DataStructures;
using Eclipse.Common.Items;

namespace Eclipse.Content.Items.Harvester.Scythes
{
    public class BoneScythe : ScytheAI
    {
        public override void SetStaticDefaults()
        {
            Item.width = 116;
            Item.damage = 70;
            Item.height = 106;
            Item.rare = 4;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.shoot = ModContent.ProjectileType<BoneScytheProjectile>();
            Item.autoReuse = false;
        }


        

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 120);
            recipe.AddTile(TileID.BoneWelder);
            recipe.Register();
        }
    }
    public class BoneScytheProjectile : ScytheProj
    {
        public override string Texture => "Eclipse/Content/Items/Harvester/Scythes/BoneScythe";
        public override void SetStaticDefaults()
        {
     
            Projectile.width = 116;
            Projectile.height = 106;
            Projectile.timeLeft = 50;
        }

    }
}