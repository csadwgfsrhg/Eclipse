

namespace Eclipse.Content.Dusts
{
    public class Smoke : ModDust
    {
        public override bool Update(Terraria.Dust dust)
        {
            dust.position += dust.velocity;
            dust.alpha += 1;
            dust.scale += 0.02f;
            //dust.rotation += 0.05f;

            if (dust.alpha >= 255)
                dust.active = false;

            dust.velocity.X -= dust.velocity.X / 30;

            if (dust.alpha > 200)
                dust.velocity.Y -= 0.1f;

            return false;
        }

        public override void OnSpawn(Terraria.Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale = 1f;
            //dust.alpha = 180;
        }
        public override bool PreDraw(Terraria.Dust dust)
        {
            Vector2 DrawPos = dust.position + new Vector2(20f, 20f);
            float DrawRot = (float)(Main.gameTimeCache.TotalGameTime.TotalSeconds * 0.25f) % MathHelper.TwoPi;

            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.TransformationMatrix);
            //Main.spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.TransformationMatrix);
            Main.spriteBatch.Draw(Texture2D.Value, DrawPos + (Vector2.UnitX * 20).RotatedBy(DrawRot) - Main.screenPosition, new Rectangle(0, 0, 24, 20), dust.color, dust.rotation, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.TransformationMatrix);
            return true;
        }
    }
}
