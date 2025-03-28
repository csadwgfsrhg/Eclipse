using System.IO;


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
public sealed class BoomerangGlobalProjectile : GlobalProjectile
{
    public int dist;
    public int pierce;
    public int enemyhit;
    public bool returning = false;

    public override bool InstancePerEntity { get; } = true;



    
    public override void SetDefaults(Projectile projectile)
    {
      if (projectile.IsBoomerang())
        {

            projectile.aiStyle = -1;
            dist = 93;
            pierce = 1;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 15;

        }
        if (projectile.type == ProjectileID.BouncingShield)

        {
         
            dist = 95;

            pierce = 5;


        }
        
        if (projectile.type == ProjectileID.PossessedHatchet)

        {
            projectile.extraUpdates = 1;
            projectile.tileCollide = false;
            dist = 95;


        }
        if (projectile.type == ProjectileID.BloodyMachete)

        {
         
            pierce = 2;
            dist = 92;
        }
        if (projectile.type == ProjectileID.Flamarang)

        {
            projectile.extraUpdates = 1;
            pierce = 2;
            dist = 91;
        }
        if (projectile.type == ProjectileID.LightDisc)

        {
        
            dist = 87;
        }

        if (projectile.type == ProjectileID.EnchantedBoomerang)

        {
         
            pierce = 2;
        }
        if (projectile.type == ProjectileID.Trimarang)

        {
         
       
            dist = 91;
        }


        if (projectile.type == ProjectileID.ThornChakram)

        {
            dist = 85;
            pierce = 3;
         
        }
        if (projectile.type == ProjectileID.PaladinsHammerFriendly)

        {
            dist = 90;
            pierce = 5;
        }
    }


    public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
    {
        if (projectile.IsBoomerang())
        {
            projectile.tileCollide = false;
            projectile.velocity -= projectile.velocity;
            returning = true;

            return false;

        }
        else
        {
            return true;
        }
     
    }
    public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
    {
        if (projectile.type == ProjectileID.Shroomerang && enemyhit == 0)

        {

            Vector2 launchVelocity = new Vector2(Main.rand.NextFloat(4, -4), Main.rand.NextFloat(4, -4));

            Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, launchVelocity, ModContent.ProjectileType<MushroomOrb>(), projectile.damage / 2, projectile.knockBack, projectile.owner);


        }

        if (projectile.IsBoomerang())
        {
            enemyhit += 1;
            if (pierce <= enemyhit)
            {

                returning = true;
                projectile.velocity -= projectile.velocity;

            }
        }
        if (projectile.type == ProjectileID.ThornChakram)

        {
           
                Vector2 launchVelocity = new Vector2(Main.rand.NextFloat(2, -2), Main.rand.NextFloat(-2, -3));
             
                Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, launchVelocity, ModContent.ProjectileType<Thorn>(), projectile.damage / 2, projectile.knockBack, projectile.owner);
            

        }
     


    }


    public override void OnSpawn(Projectile projectile, IEntitySource source)
    {
        if (projectile.IsBoomerang())
        {

            projectile.velocity *= 2;

        }
    }

    public override void AI(Projectile projectile)
    {


        if (projectile.type == ProjectileID.Flamarang && Main.rand.NextBool(6))

        {

                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Torch);


             
            
        }
        if (projectile.type == ProjectileID.EnchantedBoomerang && Main.rand.NextBool(6))

        {

           
                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.MagicMirror);
       
        }
        if (projectile.type == ProjectileID.Trimarang && Main.rand.NextBool(4))

        {
           
                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.MagicMirror);
         

        }


        if (projectile.IsBoomerang())
        {

            if (projectile.type == ProjectileID.BouncingShield)
            {
                projectile.rotation = projectile.velocity.ToRotation();

            }
                projectile.ai[0] += 3;
            if (returning == false)
            {
                if (projectile.type == ProjectileID.Flamarang && Main.rand.NextBool(40))
                {

                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, projectile.velocity /3, ProjectileID.MolotovFire, projectile.damage / 3, projectile.knockBack, projectile.owner);
                }

                if (projectile.type == ProjectileID.BloodyMachete)

                {
            
                    projectile.velocity.Y += 1f;
                }
                if (!(projectile.type == ProjectileID.BouncingShield))
                {
                    projectile.rotation += .2f + ( dist / (projectile.ai[0] * 5));
                }



                projectile.velocity *= (dist / 100f);

                if (!(projectile.type == ProjectileID.BloodyMachete))

                {
                    if (projectile.ai[0] >= dist)
                    {
                        returning = true;

                    }
                }
            }


                if (returning == true)
                {

                projectile.tileCollide = false;
                if (!(projectile.type == ProjectileID.BouncingShield))
                    {
                    projectile.rotation -= .2f + ((projectile.ai[0] - dist) / (dist * 3));
                }

           

                var owner = Main.player[projectile.owner];



                    var direction = projectile.DirectionTo(owner.Center);
                if (projectile.ai[0] > 500)
                {
                    projectile.Kill();

                }
                    var velocity = direction * ((projectile.ai[0] - dist * .4f ) / 5);

                    projectile.velocity = Vector2.SmoothStep(projectile.velocity, velocity, 0.2f);

             
                    if (projectile.Hitbox.Intersects(owner.Hitbox))
                    {

                        projectile.Kill();
                      
                    }
                }
            }
           
        }



    }

