using Eclipse.Content.Items.Harvester.Trowels;
using Eclipse.Content.Projectiles.Melee.Katana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;

namespace Eclipse.Common
{
    class EclipseModPlayer : ModPlayer
    {
       public bool attack ;
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




        public bool ChitinBladeHeld = false; 
        public override void Initialize()
        {
            base.Initialize();
            Player.manaRegen = 1;
        }
        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            ;
            if (ChitinBladeHeld == true &&  Player.ownedProjectileCounts[ModContent.ProjectileType<ChitinBladeHeld>()] < 1) {
            
                Projectile.NewProjectile(Player.GetSource_FromThis() , Player.Center, Vector2.Zero, ModContent.ProjectileType<ChitinBladeHeld>(), 15, 0f, Player.whoAmI, Player.whoAmI);
     
                    }
         
            ChitinBladeHeld = false;
        }


        public override void GetHealMana(Item item, bool quickHeal, ref int healValue)
        {
            base.GetHealMana(item, quickHeal, ref healValue);
        }
    }
}
