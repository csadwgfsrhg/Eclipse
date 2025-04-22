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




internal class staves : GlobalItem
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

    }
    public override bool Shoot(Item Item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        if (Item.type == ItemID.DiamondStaff)
        {
        
                
                position += Vector2.Normalize(velocity) * 45f;
             //   velocity = velocity.RotateRandom(1);
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
        if (Projectile.type == ProjectileID.DiamondBolt)

        {

             Projectile.extraUpdates = 5;
     
            Projectile.timeLeft = 500;
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
    }
    public override void OnKill(Projectile Projectile, int timeLeft)
    {
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
        if (Projectile.type == ProjectileID.SapphireBolt)
        {
            Projectile.velocity = oldVelocity;
            Projectile.ai[1] += 1;
            return false;
        }





        if ((Projectile.type == ProjectileID.EmeraldBolt && Projectile.ai[2] == 1))
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
        else return true;
    }
   
    public override void AI(Projectile Projectile)
    {
      
        if (Projectile.type == ProjectileID.DiamondBolt)

        {

           
            Projectile.velocity = Vector2.Normalize(Main.MouseWorld - Projectile.Center) / (1000 / Projectile.timeLeft * 2) + Projectile.oldVelocity * 1.005f;
           
          


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
   


    


   
