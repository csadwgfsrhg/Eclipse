

using Eclipse.Common;
using Eclipse.Content.Items.Harvester.Scythes;
using Eclipse.Content.Projectiles.Magic;
using Terraria.DataStructures;
using Terraria.GameContent;

namespace Eclipse.Content.Items.Magic
{
    public class VileMushroomScepter : ModItem
              
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
            Item.damage = 1;
            Item.DamageType = DamageClass.Magic;
            Item.shoot = ModContent.ProjectileType<VileDust>();
            Item.UseSound = SoundID.Item34;
            Item.autoReuse = true;
            Item.useTime = 4;
            Item.useAnimation = 36;
            Item.mana = 6;
            Item.useStyle = 5;
            Item.noMelee = true;



        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
             int shoot = 0;
            for (int i = 0; i < 1 + Main.rand.Next(2); i++)
            {
                shoot = 5 + Main.rand.Next(5);
                Item.shootSpeed = shoot;
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(8));
                Projectile.NewProjectileDirect(source, position + newVelocity * 10, newVelocity, type, damage, knockback, player.whoAmI);
           
            }
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(position + velocity * 10, 0, 0, DustID.CorruptSpray, velocity.X , velocity.Y , 255, default, 1f);
            }
          

            return false;
        }


        public override void AddRecipes()
        {

            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.VileMushroom, 5);
            recipe.AddIngredient(ModContent.ItemType<MushroomWand>(), 1);
            recipe.AddIngredient(ItemID.Ebonwood, 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}



   