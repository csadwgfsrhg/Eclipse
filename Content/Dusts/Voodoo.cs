

using Eclipse.Content.NPCs.Spells;
using Terraria;

namespace Eclipse.Content.Dusts
{
    public class Voodoo : ModDust
    {
        public override bool Update(Terraria.Dust dust)
        {
            dust.position += dust.velocity;
            dust.alpha += 2;
            
            foreach (var npc in Main.ActiveNPCs)
            {
                if (npc.type == ModContent.NPCType<StrawDollNpc>() && npc.position.X >= dust.position.X - 250 && npc.position.X <= dust.position.X + 250
           && npc.position.Y >= dust.position.Y - 250 && npc.position.Y <= dust.position.Y + 250)
                {
                  
                        dust.velocity = new Vector2(npc.position.X - dust.position.X, npc.position.Y - dust.position.Y) / 80;
                }
            }

            if (dust.alpha > 240)
            {
                dust.active = false;
            }
            return false;
        }

        public override void OnSpawn(Terraria.Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
       //     dust.scale = 1f;
            dust.alpha = 30;
        }
        public override bool PreDraw(Terraria.Dust dust)
        {
            Vector2 DrawPos = dust.position + new Vector2(20f, 20f);
            float DrawRot = (float)(Main.gameTimeCache.TotalGameTime.TotalSeconds * 0.25f) % MathHelper.TwoPi;

            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.Additive, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.TransformationMatrix);
            //Main.spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.TransformationMatrix);
            Main.spriteBatch.Draw(Texture2D.Value, DrawPos + (Vector2.UnitX * 20).RotatedBy(DrawRot) - Main.screenPosition, new Rectangle(0, 0, 24, 20), dust.color, dust.rotation, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.Additive, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.TransformationMatrix);
            return true;
         
        }
    } 
}
