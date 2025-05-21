


using Eclipse.Content.Tiles;
using Eclipse.Utilities.Extensions;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;

namespace Eclipse.Content.Items.Ranged.Ammo.Blunderbuss
{
    public class GrowingCrystalShard : ModItem

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
            Item.shoot = ModContent.ProjectileType<GrowingCrystal>();
            Item.shootSpeed = 1f;
            Item.ammo = AmmoID.Sand;

        }


      
    }
    public class GrowingCrystal : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 3;
        }

        public sealed override void SetDefaults()
        {


            Projectile.Opacity = 0;
            Projectile.scale = .2f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = -1;
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.localNPCHitCooldown = 50;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = false;
            Projectile.timeLeft = 600;
            Projectile.aiStyle = -1;
            Projectile.DamageType = DamageClass.Ranged;

        }


        bool grounded = false;
        int falloff = 0;
        public override void OnSpawn(IEntitySource source)
        {

            Projectile.frame = Main.rand.Next(0, 2);

            Projectile.rotation = Main.rand.NextFloat(-1f, 1f);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {


            Projectile.velocity = Vector2.Zero;
            grounded = true;
            Projectile.tileCollide = false;
            Projectile.height = 40;
            Projectile.width = 20;
            Projectile.position.Y -= 20;


            return false;

        }

        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {
            behindNPCsAndTiles.Add(index);


            base.DrawBehind(index, behindNPCsAndTiles, behindNPCs, behindProjectiles, overPlayers, overWiresUI);
        }
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Shatter, Projectile.position);
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(Projectile.position, 20, 40, DustID.GemAmethyst, 0, 0, 255 - Projectile.timeLeft * 2, newColor: (default), 1f);

            }

        }
        public override void AI()
        {





            if (grounded == true)
            {
                Projectile.Opacity += .004f;

                if (Projectile.scale < 1.5f)
                {

                    Projectile.scale *= 1.017f;
                }
                else
                {
                    Projectile.hostile = true;
                    Projectile.friendly = true;
                }

            }
            else
            {
                falloff++;
                if (falloff >= 15)
                {
                    Projectile.velocity.Y += .3f;
                    Projectile.velocity *= .96f;

                }

                if (Main.rand.NextBool(2))
                {
                    Dust.NewDust(Projectile.position, 0, 0, DustID.GemAmethyst, 0, 0, 255 - Projectile.timeLeft * 2, newColor: (default), 1f);
                }
            }




        }
    }

        }
    