﻿
using Eclipse.Common.Items;
using Eclipse.Content.Projectiles.Magic;
using Eclipse.Content.Projectiles.Melee.Katana;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Effects;

namespace Eclipse.Common
{
    public class EclipseModPlayer : ModPlayer
    {
        public float BlahHole;
        public Vector2 HolePos;
        public bool DerplingPheromones;

       public bool attack ;

        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            return [
                new Item(ItemID.ManaCrystal, 3)
             	];

           
        }

      
        public int MinionDrain;


        public override bool ImmuneTo(PlayerDeathReason damageSource, int cooldownCounter, bool dodgeable)
        {
            if (attack == true)
            {

                return true;

            }
            else
            {
                return false;
            }
        }

        public int ManaCooldown = 0;
   
        public bool ChitinBladeHeld = false;
        public bool LifeCrystalStaffHeld = false;

        public override void Initialize()
        {
            BlahHole = 0f;
            HolePos = Vector2.Zero;
            base.Initialize();
        }
        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
          //  Filters.Scene.Activate("Eclipse:PixelPerfect");
          //  Filters.Scene["Eclipse:PixelPerfect"].GetShader().Update(Main.gameTimeCache);


            if (ChitinBladeHeld == true &&  Player.ownedProjectileCounts[ModContent.ProjectileType<ChitinBladeHeld>()] < 1) {

            
                Projectile.NewProjectile(Player.GetSource_FromThis() , Player.Center, Vector2.Zero, ModContent.ProjectileType<ChitinBladeHeld>(), Main.LocalPlayer.HeldItem.damage, 0f, Player.whoAmI, Player.whoAmI);
     
                    }
            if (LifeCrystalStaffHeld == true && Player.ownedProjectileCounts[ModContent.ProjectileType<LifeCrystalStaffHeld>()] < 1)
            {


                Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, Vector2.Zero, ModContent.ProjectileType<LifeCrystalStaffHeld>(), 15, 0f, Player.whoAmI, Player.whoAmI);

            }

          

            LifeCrystalStaffHeld = false;
            DerplingPheromones = false;
        }


        public override void GetHealMana(Item item, bool quickHeal, ref int healValue)
        {
            base.GetHealMana(item, quickHeal, ref healValue);
        }
    }
}
