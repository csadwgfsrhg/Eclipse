using System.IO;
using Eclipse.Common;

using Eclipse.Content.Items.Melee.Katana;
using Eclipse.Utilities.Extensions;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Graphics;


namespace Eclipse.Content.Projectiles.Magic;

public class LifeCrystalStaffHeld : ModProjectile
{




    public override void SetDefaults()
    {
        Projectile.width = 50;
        Projectile.height = 50;
        Projectile.friendly = false;
        Projectile.tileCollide = false;
        Projectile.penetrate = -1;
    
        Projectile.aiStyle = -1; 
        Projectile.hide = true; 
    }

   
    public override void AI()
    {
        Player player = Main.player[Projectile.owner];

        Projectile.timeLeft = 60;


        Vector2 playerCenter = player.RotatedRelativePoint(player.MountedCenter);
        if (Main.myPlayer == Projectile.owner)
        {
       
            if (player.channel)
            {
                float holdoutDistance = player.HeldItem.shootSpeed * Projectile.scale;
              
                Vector2 holdoutOffset = holdoutDistance * Vector2.Normalize(Main.MouseWorld - playerCenter);
                if (holdoutOffset.X != Projectile.velocity.X || holdoutOffset.Y != Projectile.velocity.Y)
                {
            
                    Projectile.netUpdate = true;
                }

              
                Projectile.velocity = holdoutOffset;
            }
            else
            {
                Projectile.Kill();
            }
        }

        if (Projectile.velocity.X > 0f)
        {
            player.ChangeDir(1);
        }
        else if (Projectile.velocity.X < 0f)
        {
            player.ChangeDir(-1);
        }

        Projectile.spriteDirection = Projectile.direction;
        player.ChangeDir(Projectile.direction); // Change the player's direction based on the projectile's own
        player.heldProj = Projectile.whoAmI; // We tell the player that the drill is the held projectile, so it will draw in their hand
        player.SetDummyItemTime(2); // Make sure the player's item time does not change while the projectile is out
        Projectile.Center = playerCenter; // Centers the projectile on the player. Projectile.velocity will be added to this in later Terraria code causing the projectile to be held away from the player at a set distance.
        Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        player.itemRotation = (Projectile.velocity * Projectile.direction).ToRotation();

  

    }
}
