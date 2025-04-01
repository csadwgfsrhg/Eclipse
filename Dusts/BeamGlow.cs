using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Eclipse.Dusts 
{
	public class BeamGlow : ModDust
	{
        public override void OnSpawn(Dust dust) {
			dust.noGravity = true;
		//	dust.scale *= .5f; 
			dust.noLight = true;
            dust.velocity *= 1f;


		}
			public override bool Update(Dust dust) { 
			dust.scale *= 0.5f;

            //Lighting.AddLight(dust.position, .3f, .3f, .0f);

            if (dust.scale < 0.5f) {
				dust.active = false;
			}

			return false; 
		}

     
       // public override Color? GetAlpha(Dust dust, Color lightColor)
      //  {
          
          //  return new Color(1f, 1f, 1f, 1f);
      //  }

        }
}
