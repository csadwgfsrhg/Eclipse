


namespace Eclipse.Content.Items.Ranged.Ammo.Blunderbuss
{
    public class Cobweb : GlobalItem

    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.Cobweb)
            {
                item.damage = 2;
                item.DamageType = DamageClass.Ranged;
                item.width = 8;
                item.height = 8;
                item.maxStack = Item.CommonMaxStack;
                item.consumable = true;
                item.knockBack = 0f;
                item.value = 1;
                item.rare = 0;
                item.shoot = ModContent.ProjectileType<WebBall>();
                item.shootSpeed = 1f;
                item.ammo = AmmoID.Sand;

            }

        }

    }
    public class WebBall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            Projectile.localNPCHitCooldown = -1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.penetrate = 1;
            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.timeLeft = 60;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
        }


        public override void OnKill(int timeLeft)
        {
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center , Vector2.Zero, ModContent.ProjectileType<Web>(), 0, Projectile.knockBack, Projectile.owner);

        }






        public override void AI()
        {


            Projectile.velocity *= .99f;
            if (Main.rand.NextBool(5))
                Dust.NewDust(Projectile.position, 2, 2, DustID.Web);
        }
    }
        public class Web : ModProjectile
        {
         
            public override void SetDefaults()
            {
            Projectile.rotation = Main.rand.Next(8);
                Projectile.localNPCHitCooldown = -1;
                Projectile.usesLocalNPCImmunity = true;
                Projectile.penetrate = -1;
            Projectile.scale = Main.rand.NextFloat(.8f, 1.2f);
            Projectile.Opacity = 0;
                Projectile.width = 60;
                Projectile.height = 60;
                Projectile.timeLeft = 275;
                Projectile.aiStyle = -1;
                Projectile.friendly = true;
            Projectile.tileCollide = false;
            }






        bool fadein = false;
        public override void AI()
        {
            if (Projectile.Opacity < 1  && fadein == false)
            {
                Projectile.Opacity += .08f;
              
            }
            else
            {
                fadein = true;
                Projectile.Opacity -= .004f;
            }

            foreach (var npc in Main.ActiveNPCs)
            {
                if (npc.Hitbox.Intersects(Projectile.Hitbox))
                {
                    if (npc.boss)
                        npc.velocity *= .995f;
                    else
                     npc.velocity *= .96f;

                }
            }
            foreach (var player in Main.ActivePlayers)
            {
                if (player.Hitbox.Intersects(Projectile.Hitbox))
                {
                    player.velocity *= .96f;
                    player.AddBuff(BuffID.Featherfall, 1);
                }
            }
          

        }
        }
    }
