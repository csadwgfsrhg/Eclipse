using System;
using System.Collections.Generic;
using System.Linq;

using Terraria.DataStructures;

using Eclipse.Content.Dusts;

using Eclipse.Content.Items.Weed;

namespace Eclipse.Common
{
    public class WeedModPlayer : ModPlayer
    {
        public float WeedTime = 0;

        public override void ResetEffects()
        {
            if (Player.HeldItem.type == ModContent.ItemType<Joint>())
            {
                if (Player.channel)
                {
                    if (WeedTime < 1)
                        WeedTime += 0.01f;
                }
                else
                {
                    if (WeedTime > 0)
                        WeedTime -= 0.15f;
                }
            }
            base.ResetEffects();
        }

        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            float GameMS = (float)Main.gameTimeCache.TotalGameTime.TotalSeconds;
            float WeedTime = (180 + (Player.GetModPlayer<WeedModPlayer>().WeedTime) * 75); // 180 - 75
            Vector2 SmokeVel = new Vector2(0, (MathF.Sin(GameMS * 4) * 0.5f) - 0.5f);
            if (drawInfo.drawPlayer.velocity == Vector2.Zero)
                WeedTime = (200 + (Player.GetModPlayer<WeedModPlayer>().WeedTime) * 55); // 180 - 75
            else
                SmokeVel.X += Player.velocity.X;

            if (Player.HeldItem.type == ModContent.ItemType<Joint>() && Player.itemTime == 0)
            {
                Dust.NewDustPerfect(Player.itemLocation + new Vector2(24 * Player.direction, Player.channel ? -12 : -4), ModContent.DustType<Smoke>(), SmokeVel, Alpha: (int)WeedTime);
            }
        }



    }
}
