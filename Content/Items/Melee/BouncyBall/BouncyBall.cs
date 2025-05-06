using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.Localization;

namespace Eclipse.Content.Items.Melee.BouncyBall
{
    public class BouncyBall : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToGolfBall(ModContent.ProjectileType<BouncyBallProjectile>());
            Item.damage = 10;
            Item.crit = 7;
            Item.shootSpeed = 35f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback);
            return false;
        }
    }
    public class BouncyBallProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //ProjectileID.Sets.IsAGolfBall[Type] = true;
            ProjectileID.Sets.TrailingMode[Type] = 0; 
            ProjectileID.Sets.TrailCacheLength[Type] = 20;
            
        }
        public override void SetDefaults()
        {
            Projectile.netImportant = true; // Indicates that this projectile will be synced to a joining player (by default, any projectiles active before the player joins (besides pets) are not synced over).
            Projectile.width = 7; // The width of the projectile's hitbox.
            Projectile.height = 7; // The height of the projectile's hitbox.
            Projectile.friendly = true; // Setting this to anything other than true causes an index out of bounds error.
            Projectile.penetrate = -1; // Number of times the projectile can penetrate enemies. -1 sets it to infinite penetration.
            Projectile.aiStyle = -1; // 149 is the golf ball AI.
            Projectile.tileCollide = false; // Tile Collision is set to false, as it's handled in the AI.
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.ai[0]++;
            Main.NewText(Projectile.velocity);
            return false;
        }
        public override void AI()
        {
            Projectile.velocity.Y += 0.05f;
        }
        public override void PostAI()
        {
            Main.NewText(Projectile.tileCollide);

        }
    }
}
