


using Eclipse.Utilities.Extensions;
using Terraria;
using Terraria.DataStructures;



namespace Eclipse.Common.Items
{
    public class MinionEquipment : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
          

           if (item.type == ItemID.SlimeStaff || item.type == ItemID.FlinxStaff || item.type == ItemID.BabyBirdStaff  || item.type == ItemID.AbigailsFlower)   
            {
                item.mana = 20;
            }
            if ( item.type == ItemID.HornetStaff || item.type == ItemID.ImpStaff || item.type == ItemID.VampireFrogStaff)
            {
                item.mana = 30;
            }
        }
     

    }
    public class MinionRework : GlobalProjectile

    {

        public override void AI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];

            {
                if (player.statMana < 1 && (projectile.type == ProjectileID.DD2LightningAuraT1 || projectile.type == ProjectileID.DD2LightningAuraT2 || projectile.type == ProjectileID.DD2LightningAuraT3 ||
                      projectile.type == ProjectileID.DD2FlameBurstTowerT1 || projectile.type == ProjectileID.DD2FlameBurstTowerT2 || projectile.type == ProjectileID.DD2FlameBurstTowerT3 ||
                      projectile.type == ProjectileID.DD2ExplosiveTrapT1 || projectile.type == ProjectileID.DD2ExplosiveTrapT2 || projectile.type == ProjectileID.DD2ExplosiveTrapT3 ||
                       projectile.type == ProjectileID.DD2BallistraTowerT1 || projectile.type == ProjectileID.DD2BallistraTowerT2 || projectile.type == ProjectileID.DD2BallistraTowerT3 ||
                       projectile.type == ProjectileID.BabySlime || projectile.type == ProjectileID.BabyHornet || projectile.type == ProjectileID.BabyImp ||
                  projectile.type == ProjectileID.FlinxMinion || projectile.type == ProjectileID.BabyBird || projectile.type == ProjectileID.VampireFrog ||
                   projectile.type == ProjectileID.HoundiusShootius || projectile.type == ProjectileID.AbigailMinion))
                {


                    player.maxTurrets = 0;
                    player.maxMinions = 0;
                    projectile.Kill();


                }
                if (projectile.type == ProjectileID.DD2LightningAuraT1 || projectile.type == ProjectileID.DD2LightningAuraT2 || projectile.type == ProjectileID.DD2LightningAuraT3 ||
                    projectile.type == ProjectileID.DD2FlameBurstTowerT1 || projectile.type == ProjectileID.DD2FlameBurstTowerT2 || projectile.type == ProjectileID.DD2FlameBurstTowerT3 ||
                    projectile.type == ProjectileID.DD2ExplosiveTrapT1 || projectile.type == ProjectileID.DD2ExplosiveTrapT2 || projectile.type == ProjectileID.DD2ExplosiveTrapT3 ||
                     projectile.type == ProjectileID.DD2BallistraTowerT1 || projectile.type == ProjectileID.DD2BallistraTowerT2 || projectile.type == ProjectileID.DD2BallistraTowerT3 ||
                     projectile.type == ProjectileID.HoundiusShootius)
                {
          player.slotsMinions += 1;
                }
            }

        }
    }
    public class ManaStar : GlobalItem
    {
        public override void OnSpawn(Item item, IEntitySource source)
        {
            if (item.type == ItemID.Star) {
            item.active = false;
            
            }
        }
        public override bool OnPickup(Item item, Player player)
        {

            if (item.type == ItemID.Star)
            {
                player.statMana += 10;
                player.ManaEffect(10);
           
            }
         
            return true;
        }


    }
        public class Boomerangs : GlobalItem
    {
        public override void SetDefaults(Item Item)
        {
           
            if (Item.type == ItemID.PossessedHatchet)
            {
                Item.damage = 90;

            }
                if (Item.type == ItemID.PaladinsHammer)
            {
               
                Item.damage = 65;
            }
            if (Item.type == ItemID.ThornChakram)
            {
                Item.shootSpeed = 9;
                Item.damage = 23;
            }
            if (Item.type == ItemID.Flamarang)
            {
             Item.shootSpeed = 10;
            Item.damage = 26;
            }
            if (Item.type == ItemID.EnchantedBoomerang)
            {
                Item.shootSpeed = 9;
                Item.damage = 14;

            }
            if (Item.type == ItemID.Shroomerang)
            {
                Item.shootSpeed = 9;

            }
            if (Item.type == ItemID.IceBoomerang)
            {
                Item.shootSpeed = 10;
            }

        }         

    }
        public class FishingRods : GlobalItem
    {
        public override void SetDefaults(Item Item)
        {
            if (
                Item.type == ItemID.WoodFishingPole || Item.type == ItemID.ReinforcedFishingPole || Item.type == ItemID.FisherofSouls ||
                Item.type == ItemID.Fleshcatcher || Item.type == ItemID.ScarabFishingRod || Item.type == ItemID.FiberglassFishingPole ||
                Item.type == ItemID.MechanicsRod || Item.type == ItemID.SittingDucksFishingRod || Item.type == ItemID.GoldenFishingRod ||
                Item.type == ItemID.HotlineFishingHook

                )
            {
                Item.noMelee = true;
                Item.DamageType = DamageClass.Summon;

            }
            if (Item.type == ItemID.WoodFishingPole)
            {
                Item.damage = 7;
            }
            if (Item.type == ItemID.ReinforcedFishingPole)
            {
                Item.damage = 12;
            }
            if (Item.type == ItemID.FisherofSouls)
            {
                Item.damage = 20;
            }
            if (Item.type == ItemID.Fleshcatcher)
            {
                Item.damage = 22;
            }
            if (Item.type == ItemID.ScarabFishingRod)
            {
                Item.damage = 16;
            }
            if (Item.type == ItemID.FiberglassFishingPole)
            {
                Item.damage = 24;
            }
            if (Item.type == ItemID.MechanicsRod)
            {
                Item.damage = 32;
            }
            if (Item.type == ItemID.SittingDucksFishingRod)
            {
                Item.damage = 36;
            }
            if (Item.type == ItemID.GoldenFishingRod)
            {
                Item.damage = 25;
            }
            if (Item.type == ItemID.HotlineFishingHook)
            {
                Item.damage = 48;
            }
        }



    }
    public class Potions : GlobalItem
    {
        public override bool CanUseItem(Item item, Player player)
        {
            if (item.type == ItemID.LesserManaPotion || item.type == ItemID.ManaPotion || item.type == ItemID.GreaterManaPotion || item.type == ItemID.SuperManaPotion)
            {
                if (player.HasBuff(BuffID.ManaSickness))
                {
                    return false;
                }
                else
                {
                    player.AddBuff(BuffID.ManaSickness, 700);
                    player.ManaEffect(item.healMana);
                    player.statMana += item.healMana;
                    return false;
                }

            }
            else
            {
                return true;
            }
        }
    }
    public class Swords : GlobalItem
    {
        public override void SetDefaults(Item Item)
        {
            if (Item.type == ItemID.TerraBlade)
            {
                
                Item.shootSpeed = 5;

            }
        }
    }

    public class Magic : GlobalItem
    {
        public override void SetDefaults(Item Item)
        {

            if (Item.type == ItemID.BookofSkulls)
            {
                Item.damage = 50;

            }
            if (Item.type == ItemID.DemonScythe)
            {
                Item.damage = 43;

            }
        }
    }
public class Ranged : GlobalItem
    {
        public override void SetDefaults(Item Item)
        {
         
            if (Item.type == ItemID.PalmWoodBow)
            {
                Item.damage = 8;
            }
            if (Item.type == ItemID.RichMahoganyBow)
            {
                Item.damage = 8;
            }
            if (Item.type == ItemID.PearlwoodBow)
            {
                Item.damage = 25;
            }
            if (Item.type == ItemID.EbonwoodBow)
            {
                Item.damage = 10;
            }
            if (Item.type == ItemID.ShadewoodBow)
            {
                Item.damage = 10;
            }
            if (Item.type == ItemID.AshWoodBow)
            {
                Item.damage = 16;
            }
            if (Item.type == ItemID.DemonBow)
            {
                Item.damage = 17;
            }
            if (Item.type == ItemID.TendonBow)
            {
                Item.damage = 20;
            }
            if (Item.type == ItemID.BorealWoodBow)
            {
                Item.damage = 7;
            }
            if (Item.type == ItemID.Minishark)
            {
                Item.damage = 9;
            }
          
            if (Item.type == ItemID.TheUndertaker)
            {
                Item.damage = 21;
            }
            if (Item.type == ItemID.FlintlockPistol)
            {
                Item.damage = 15;
            }
            if (Item.type == ItemID.Blowpipe)
            {
                Item.damage = 12;
            }
            if (Item.type == ItemID.Handgun)
            {
                Item.damage = 30;
            }
            if (Item.type == ItemID.PhoenixBlaster)
            {
                Item.damage = 35;
            }
        }
    }

    public class Ammo : GlobalItem
    {
        public override void SetDefaults(Item Item)
        {

            if (Item.type == ItemID.WoodenArrow || Item.type == ItemID.FlamingArrow || Item.type == ItemID.UnholyArrow || Item.type == ItemID.JestersArrow ||
            Item.type == ItemID.MusketBall || Item.type == ItemID.MeteorShot || Item.type == ItemID.HellfireArrow || Item.type == ItemID.Seed ||
             Item.type == ItemID.HolyArrow || Item.type == ItemID.CursedArrow || Item.type == ItemID.FrostburnArrow || Item.type == ItemID.ChlorophyteArrow ||
             Item.type == ItemID.ChlorophyteBullet || Item.type == ItemID.HighVelocityBullet || Item.type == ItemID.PoisonDart || Item.type == ItemID.IchorArrow ||
             Item.type == ItemID.IchorBullet || Item.type == ItemID.VenomArrow || Item.type == ItemID.VenomBullet || Item.type == ItemID.PartyBullet ||
             Item.type == ItemID.NanoBullet || Item.type == ItemID.ExplodingBullet || Item.type == ItemID.GoldenBullet || Item.type == ItemID.BoneArrow ||
             Item.type == ItemID.CrystalDart || Item.type == ItemID.IchorDart || Item.type == ItemID.EndlessQuiver || Item.type == ItemID.EndlessMusketPouch ||
             Item.type == ItemID.ShimmerArrow || Item.type == ItemID.CursedBullet || Item.type == ItemID.CrystalBullet || Item.type == ItemID.CursedDart)
            {
                Item.damage = 0;
            }
            if (Item.type == ItemID.SilverBullet || Item.type == ItemID.TungstenBullet)

            {
                Item.damage = 2;
            }
        }


    }
}



      



