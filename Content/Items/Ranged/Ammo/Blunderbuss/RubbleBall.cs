


using Eclipse.Content.Tiles;
using Eclipse.Utilities.Extensions;
using System.Diagnostics.Eventing.Reader;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;

namespace Eclipse.Content.Items.Ranged.Ammo.Blunderbuss
{
    public class Rubble : ModItem

    {
        public override void SetDefaults()
        {
            Item.damage = 5;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.knockBack = 0f;
            Item.value = 10;
            Item.rare = 0;
            Item.shoot = ModContent.ProjectileType<RubbleBall>();
            Item.shootSpeed = 1f;
            Item.ammo = AmmoID.Sand;

        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddIngredient(ItemID.StoneBlock, 1);
            recipe.AddIngredient(ItemID.SiltBlock, 1);
            recipe.AddIngredient(ItemID.ClayBlock, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }


    }
    public class RubbleBall : ModProjectile
    {
      
        public override void SetDefaults()
        {
            Projectile.localNPCHitCooldown = -1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.penetrate = -1;
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.timeLeft = 1000;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
        }

        bool placedtile = false;
        int falloff = 0;
        public override void OnKill(int timeLeft)
        {
            Tile tile = Main.tile[(int)(Projectile.position.X / 16), (int)(Projectile.position.Y / 16)];
            if (tile.TileType == ModContent.TileType<RubblePlaced>() && placedtile == true) 
            {

                WorldGen.KillTile((int)(Projectile.position.X / 16), (int)(Projectile.position.Y / 16));

            }

        }
      
        
      


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            spawnrubble();



            return false;
        }
        private void spawnrubble()
        {
            Projectile.velocity = Vector2.Zero;
            Projectile.friendly = false;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.Opacity = 0;
            Projectile.position = new Vector2((int)(Projectile.position.X / 16), (int)(Projectile.position.Y / 16)) * 16;




            Tile tile = Main.tile[(int)(Projectile.position.X / 16), (int)(Projectile.position.Y / 16)];
            if (tile.HasTile == false)
            {

                placedtile = true;
                WorldGen.PlaceTile((int)(Projectile.position.X / 16), (int)(Projectile.position.Y / 16), ModContent.TileType<RubblePlaced>());

            }
            else
            {
                Projectile.Kill();


            }

        }
        public override void AI()
        {
            falloff++;
            if (falloff >= 15 && placedtile == false)
                Projectile.velocity.Y += .5f;


            if (falloff >= 50 && placedtile == false)
                spawnrubble();

            Projectile.rotation += (Projectile.velocity.X / 20);

            

            if (Main.rand.NextBool(12) && placedtile == false)
            Dust.NewDust(Projectile.position, 2, 2, DustID.Dirt);
        }
      
    }
}
