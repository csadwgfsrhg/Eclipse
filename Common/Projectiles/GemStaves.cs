using System.IO;
using System.Threading.Channels;
using System.Transactions;
using Eclipse.Content.Projectiles.Melee.Boomerang;
using Eclipse.Utilities.Extensions;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;

namespace Eclipse.Common.Projectiles;

/// <summary>
///     Handles the behavior of fishing rod bobbers, which should latch onto enemies and spawn phantom
///     fishes accordingly.
/// </summary>
/// 




internal class Staves : GlobalItem
{
    public override void SetDefaults(Item Item)
    {
        if (Item.type == ItemID.EmeraldStaff)
        {
            Item.damage = 17;
        }
        if (Item.type == ItemID.DiamondStaff)
        {
            Item.shootSpeed = 5;
         
        }
        if (Item.type == ItemID.SapphireStaff)
        {
            Item.mana = 6;

        }
        if (Item.type == ItemID.AmberStaff)
        {
            Item.mana = 8;

        }
        if (Item.type == ItemID.AmethystStaff)
        {
            Item.mana = 5;
            Item.shootSpeed = 8;

        }


    }
    public override bool Shoot(Item Item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        if (Item.type == ItemID.AmethystStaff)
        {
     
            for (int i = 0; i < 2; i++)
            {

                velocity = velocity.RotatedByRandom(.2f) ;
                
                Projectile.NewProjectile(source, position, velocity * Main.rand.NextFloat(.5f, 1.2f), type, damage, knockback, player.whoAmI);
             


            }
            return false;

        }



        if (Item.type == ItemID.DiamondStaff)
        {
        
                
                position += Vector2.Normalize(velocity) * 45f;
                velocity = velocity.RotateRandom(1);
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
        
            return false;
        }
        return true;
    }
}


public sealed class GemStaves : GlobalProjectile
{

    public override void SetDefaults(Projectile Projectile)
    {
        if (Projectile.type == ProjectileID.TopazBolt)
        {
            Projectile.penetrate = 3;

          

        }
        if (Projectile.type == ProjectileID.AmethystBolt)
        {
            Projectile.timeLeft = 60;


        }
        if (Projectile.type == ProjectileID.DiamondBolt)

        {

             Projectile.extraUpdates = 1;

            Projectile.timeLeft = 100;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 30;
        }



        if (Projectile.type == ProjectileID.EmeraldBolt)
        {
            Projectile.penetrate = 2;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 30;
            Projectile.timeLeft = 23;
        }
        if (Projectile.type == ProjectileID.RubyBolt)
        {
            Projectile.penetrate = 5;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 3;
        
        }
        if (Projectile.type == ProjectileID.AmberBolt)
        {
            Projectile.extraUpdates = 5;
            Projectile.timeLeft = 15;
            Projectile.penetrate = 2;
            Projectile.friendly = true;
        

        }
    }
    public override void OnSpawn(Projectile Projectile, IEntitySource source)
    {
       

            if (Projectile.type == ProjectileID.RubyBolt)
        {
            Projectile.ai[1] = 0;
        }
    }
    public override void OnHitNPC(Projectile Projectile, NPC target, NPC.HitInfo hit, int damageDone)
    {
        
        if (Projectile.type == ProjectileID.SapphireBolt)
        {
            Player player = Main.player[Projectile.owner];
            player.statMana += 6;
            player.ManaEffect(6);
        }
        if (Projectile.type == ProjectileID.RubyBolt && Projectile.ai[2] ==0)
        {
            Projectile.ai[2] += 1;
            Projectile.timeLeft = 2;
            Projectile.width = 60;
            Projectile.height = 60;
            Projectile.position.X -= 30;
            Projectile.position.Y -= 30;
         

            for (int i = 0; i < 12; i++)
            {
                Dust.NewDust(Projectile.position, 60, 60, DustID.GemRuby, Projectile.velocity.X / 4, Projectile.velocity.Y / 4, 255, newColor: (default), 1f);
                
            }
           
        }
    }
    public override void OnKill(Projectile Projectile, int timeLeft)
    {
      

       


            if (Projectile.type == ProjectileID.AmberBolt && Projectile.ai[2] != 2 )
            {
             
                for (int i = 0; i < 2; i++)
                {

                    Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Projectile.velocity.RotateRandom(1), ProjectileID.AmberBolt, Projectile.damage , Projectile.knockBack, Projectile.owner, ai2: 1 +
            Projectile.ai[2]);

                }

            
            
        }




        if (Projectile.type == ProjectileID.EmeraldBolt && Projectile.ai[2] != 1)
        {

            Vector2 launchVelocity = Projectile.velocity;
            for (int i = 0; i < 3; i++)
            {

                launchVelocity = Projectile.velocity.RotatedBy((-10 + i * 10) / 30f);


                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ProjectileID.EmeraldBolt, Projectile.damage, Projectile.knockBack, Projectile.owner, ai2: 1);
            }
        }

    }
    public override bool OnTileCollide(Projectile Projectile, Vector2 oldVelocity)
    {
      

        if (Projectile.type == ProjectileID.RubyBolt && Projectile.ai[2] == 0)
        {
            Projectile.ai[2] += 1;
            Projectile.timeLeft = 2;
            Projectile.width = 60;
            Projectile.height = 60;
            Projectile.position.X -= 30;
            Projectile.position.Y -= 30;
             
            for (int i = 0; i < 12; i++)
            {
                Dust.NewDust(Projectile.position, 60, 60, DustID.GemRuby, Projectile.velocity.X / 4, Projectile.velocity.Y /4, 255, newColor: (default), 1f);

            }
       
            return false;
        }



        if ((Projectile.type == ProjectileID.EmeraldBolt && Projectile.ai[2] == 1) || Projectile.type == ProjectileID.AmberBolt)
        {
            if (Projectile.velocity.X == 0)
            {
                Projectile.velocity.X = -Projectile.oldVelocity.X;
            }
            if (Projectile.velocity.Y == 0)
            {
                Projectile.velocity.Y = -Projectile.oldVelocity.Y;
            }
            return false;
        }
         return true;
    }
   
    public override void AI(Projectile Projectile)
    {
    
        if (Projectile.type == ProjectileID.DiamondBolt)

        {

           
            Projectile.velocity = Vector2.Normalize(Main.MouseWorld - Projectile.Center)  + Projectile.oldVelocity * .99f;
           
          


        }
        if (Projectile.type == ProjectileID.SapphireBolt)
        {
            if (Projectile.ai[1] >= 15)
            {
                Projectile.Kill();
            }

        }
        if (Projectile.type == ProjectileID.EmeraldBolt)
        {
            if (Projectile.ai[2] == 1)
            {

                Projectile.ai[1] += 1
;



                if (Projectile.ai[1] >= 8)
                {
                    Projectile.friendly = true;
                }
                else
                {
                    Projectile.friendly = false;
                }

            }

        }

    }
}
   


    


   
