
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Eclipse.Content.Items.Accessories;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

using System.Linq;
using Eclipse;

using Terraria.Audio;
using Microsoft.CodeAnalysis;
using Terraria.DataStructures;


namespace Eclipse.Content
{
    public static class GlobalExtensions
    {

        public static bool IsLance(this Projectile proj) => 
            (proj.type == ProjectileID.HallowJoustingLance || proj.type == ProjectileID.JoustingLance || proj.type == ProjectileID.ShadowJoustingLance );
    }


        public class MyPlayer : ModPlayer
    {
      
        public bool BouncyTip = false;
        public int cooldown = 0;


        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {


            
                    cooldown += 1;
          
             
              

            

        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {


            Player player = Main.player[proj.owner];


            if (BouncyTip & (proj.IsLance()))
            {
               

                player.velocity = - (player.velocity) ; 


            }

        BouncyTip = false;
       
        }
     
    }
}
  