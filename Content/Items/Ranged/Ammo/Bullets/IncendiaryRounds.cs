

using Eclipse.Content.Projectiles.Harvester.Hunger;
using Eclipse.Utilities.Extensions;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;

namespace Eclipse.Content.Items.Ranged.Ammo.Bullets
{
    public class IncendiaryRounds : ModItem

    {
        public override void SetDefaults()
        {
            Item.damage = 0;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.knockBack = 0f;
            Item.value = 10;
            Item.rare = 2;
            Item.shoot = ModContent.ProjectileType<IncendiaryRoundsProj>();
            Item.shootSpeed = 1f;
            Item.ammo = AmmoID.Bullet;

        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(ItemID.HellstoneBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }


    }
    public class IncendiaryRoundsProj : ModProjectile
    {
      
        public override void SetDefaults()
        {
            Projectile.localNPCHitCooldown = 0;
            Projectile.extraUpdates = 4;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.penetrate = -1;
            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.timeLeft = 2000;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.velocity *= .9f;
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Torch);
            SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, Projectile.Center);
        }
        public override void OnSpawn(IEntitySource source)
        {
        
            Projectile.penetrate = Projectile.damage;
 
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
           Projectile.damage = 1;
            if (Main.rand.NextBool(10))
            {
                target.AddBuff(BuffID.OnFire, 60);


            }
            if (Main.rand.NextBool(50))
            {
                target.AddBuff(BuffID.OnFire3, 100);

             
            }
        }


      
          
           
        
        
        public override void AI()
        {
            Dust.NewDust(Projectile.position, 2, 2, DustID.Torch);
        }
      
    }
}
