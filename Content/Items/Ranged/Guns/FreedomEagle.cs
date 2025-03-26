

using Eclipse.Content.Projectiles.Harvester.Hunger;
using Eclipse.Content.Projectiles.Melee.Boomerang;
using Eclipse.Content.Projectiles.Ranged.Bullets;
using Eclipse.Utilities.Extensions;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;

namespace Eclipse.Content.Items.Ranged.Guns
{
    public class FreedomEagle : ModItem

    {

        public override void SetDefaults()
        {
            Item.damage = 100;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 44;
            Item.height = 28;
            Item.useTime = 1;
            Item.useAnimation = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 0f;
            Item.value = 10;
            Item.rare = 5;
            Item.knockBack = 5f;
            Item.shootSpeed = 10f;
            Item.noMelee = true;
            Item.shoot = 0; // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 16f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = 0;
           

        }
        int canshoot = 0;

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            if (type == ProjectileID.Bullet)
            { 
                type = ModContent.ProjectileType<EagleBullet>();
        }
            
        }
        public override Vector2? HoldoutOffset() => new Vector2(-8f, 0f);
        public override bool? UseItem(Player player)
        {
            if (canshoot >= 1)
            {
                Item.useTime = 15;
                Item.useAnimation = 15;
                Item.useAmmo = AmmoID.Bullet;
                canshoot -= 1;
                Item.shoot = ProjectileID.PurificationPowder;
                Item.UseSound = new SoundStyle($"{nameof(Eclipse)}/Sounds/Gunshot1")
                {
                    Volume = 0.9f,
                    PitchVariance = 0.2f,
                    MaxInstances = 3,
                };
            }

            else
            {
                Item.useAmmo = 0;
                canshoot = 5;
                Item.shoot = 0;
                Item.useTime = 100;
                Item.useAnimation = 100;
                Item.UseSound = new SoundStyle($"{nameof(Eclipse)}/Sounds/Reload1")
                {
                    Volume = 0.9f,
                    PitchVariance = 0.2f,
                    MaxInstances = 3,
                };
               
             


            }
            return true;
        }


      
      
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.PhoenixBlaster, 1);
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }


    }
}