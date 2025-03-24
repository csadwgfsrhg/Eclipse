using System.IO;
using Eclipse.Common;
using Eclipse.Content.Classes;
using Eclipse.Utilities.Extensions;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Graphics;


namespace Eclipse.Content.Projectiles.Melee.Katana;

public class ChitinBladeHeld : ModProjectile
{

    public override void SetStaticDefaults()
    {
        Main.projFrames[Projectile.type] = 6;
    }

    public sealed override void SetDefaults()
    {
        Projectile.friendly = false;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = false;
        Projectile.width = 0;
        Projectile.height = 0;



        Projectile.aiStyle = -1;
        SetStaticDefaults();

    }

    public override void AI()
    {

        Player player = Main.player[Projectile.owner];
        if (player.GetModPlayer<EclipseModPlayer>().ChitinBladeHeld == false)

        {
            Projectile.Kill();
        }

    
        Projectile.position.X = player.position.X + 56;
        Projectile.position.Y = player.position.Y + 10;
        player.heldProj = Projectile.whoAmI;
    }

    public override bool PreDraw(ref Color lightColor)
    {

        SpriteEffects spriteEffects = SpriteEffects.None;
        if (Projectile.spriteDirection == -1)
            spriteEffects = SpriteEffects.FlipHorizontally;

        // Getting texture of projectile
        Texture2D texture = TextureAssets.Projectile[Type].Value;

        // Calculating frameHeight and current Y pos dependence of frame
        // If texture without animation frameHeight is always texture.Height and startY is always 0
        int frameHeight = texture.Height / Main.projFrames[Type];
        int startY = frameHeight * Projectile.frame;

        // Get this frame on texture
        Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);

        // Alternatively, you can skip defining frameHeight and startY and use this:
        // Rectangle sourceRectangle = texture.Frame(1, Main.projFrames[Type], frameY: Projectile.frame);

        Vector2 origin = sourceRectangle.Size() / 2f;

        // If image isn't centered or symmetrical you can specify origin of the sprite
        // (0,0) for the upper-left corner
        float offsetX = 20f;
        origin.X = (float)(Projectile.spriteDirection == 1 ? sourceRectangle.Width - offsetX : offsetX);
        Color drawColor = Projectile.GetAlpha(lightColor);

        Main.EntitySpriteDraw(texture,
            Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),

            sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);

        return false;
    }
    }