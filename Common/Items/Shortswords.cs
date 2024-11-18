


using Eclipse.Content.Classes;
using Eclipse.Utilities.Extensions;
using Microsoft.Build.Framework;
using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;



namespace Eclipse.Common.Items
{
    public class Shortswords : GlobalItem
    {
        public override void SetDefaults(Item Item)
        {
            if (Item.type == ItemID.Ruler)
            {
                Item.crit = 10;

            }

        }

    }
    
        public class ShortswordProj : GlobalProjectile
    {
        public override void SetDefaults(Projectile projectile)
        {
            if (projectile.type == ProjectileID.GladiusStab)
            {
                projectile.penetrate = -1;

                projectile.usesLocalNPCImmunity = true;
            }
            if (projectile.type == ProjectileID.RulerStab)
            {
      
                projectile.penetrate = -1;
                projectile.usesLocalNPCImmunity = true;
            }
        }
       
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (projectile.type == ProjectileID.GladiusStab || projectile.type == ProjectileID.CopperShortswordStab ||
                projectile.type == ProjectileID.TungstenShortswordStab || projectile.type == ProjectileID.GoldShortswordStab ||
                projectile.type == ProjectileID.IronShortswordStab || projectile.type == ProjectileID.LeadShortswordStab ||
                projectile.type == ProjectileID.PlatinumShortswordStab || projectile.type == ProjectileID.SilverShortswordStab ||
                projectile.type == ProjectileID.TinShortswordStab || projectile.type == ProjectileID.RulerStab)
            { 
                target.GetGlobalNPC<Dot>().DotAmnt += 1;
                for (int i = 0; i < Main.rand.Next(1, 5); i++)
                {
                    Dust.NewDust(target.position, target.width, target.height, DustID.Blood);
                }
                if (hit.Crit && projectile.type == ProjectileID.RulerStab)
                {
                    target.GetGlobalNPC<Dot>().DotAmnt += 2;

                    SoundEngine.PlaySound(SoundID.NPCHit9, target.position);
                    for (int i = 0; i < Main.rand.Next(5, 10); i++)
                    {
                        Dust.NewDust(target.position, target.width, target.height, DustID.Blood);
                    }

                }


            }
            

        }
    }


    }


    public class Dot : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        int charge = 0;
    int diminishing = 0;
       public int DotAmnt = 0;
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
        charge += 1;
        if (charge >= 320 - DotAmnt * 16)
            {
         
                npc.lifeRegen -= DotAmnt * 120;
                damage = DotAmnt;
            for (int i = 0; i < DotAmnt; i++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood);
            }
            charge = 0;

            if (DotAmnt >= 1 )
                {
                    DotAmnt -= 1 ;

               

            }
        
           

        }
      

    }
}