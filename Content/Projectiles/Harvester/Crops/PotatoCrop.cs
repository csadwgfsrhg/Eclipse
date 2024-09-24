﻿using Microsoft.Xna.Framework;

using Terraria;

using Terraria.ModLoader;


namespace Eclipse.Content.Projectiles.Harvester.Crops
{
	public class PotatoCrop : ModProjectile
	{

        public override void SetDefaults() {
			Projectile.width = 38;
			Projectile.height = 36;
            Projectile.sentry = true;
            Projectile.friendly = false;
            Projectile.timeLeft = 1000;
            Projectile.penetrate = -1;
            Projectile.aiStyle = -1;
            Projectile.tileCollide = true;
			Projectile.usesLocalNPCImmunity = true;

			}
        int cropgrowth = 0;
       


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
        public override void AI()   
        {
            cropgrowth += 1;

           
            }
        }
	}
