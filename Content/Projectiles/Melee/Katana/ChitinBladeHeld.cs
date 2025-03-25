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
    int range = 0;
    
    public override void SetStaticDefaults()
    {
        Main.projFrames[Projectile.type] = 7;
    }

    public sealed override void SetDefaults()
    {

        Projectile.DamageType = DamageClass.Melee;
  
        Projectile.friendly = false;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = false;
        Projectile.penetrate = -1;
        Projectile.width = 60;
        Projectile.height = 60;
        Projectile.usesLocalNPCImmunity = true;
        Projectile.localNPCHitCooldown = 20;


        Projectile.aiStyle = -1;
        SetStaticDefaults();

    }
    private float Timer
    {
        get => Projectile.ai[0];
        set => Projectile.ai[0] = value;
    }
    private float ChargeTime
    {
        get => Projectile.ai[1];
        set => Projectile.ai[1] = value;
    }
    public override void AI()
    {

    Projectile.damage = (int)(15 + (15 * ChargeTime / 60));
   




        Player player = Main.player[Projectile.owner];
        if ((!player.channel && ChargeTime < 1))
            {

            player.GetModPlayer<EclipseModPlayer>().attack = false;
        }
        if (player.channel && (player.GetModPlayer<EclipseModPlayer>().attack == false))
        {
            player.velocity.X /= 1.05f;
          ChargeTime++;
            Projectile.frame = 1;

        }
        if ((!player.channel && ChargeTime >= 1) || ChargeTime >= 120)
        {

            player.GetModPlayer<EclipseModPlayer>().attack = true;
        }
   
        player.itemAnimation = player.itemAnimationMax;
        player.itemTime = player.itemTimeMax;

        if (player.GetModPlayer<EclipseModPlayer>().ChitinBladeHeld == false)

        {
            player.GetModPlayer<EclipseModPlayer>().attack = false;
            Projectile.Kill();
        }
        

        player.heldProj = Projectile.whoAmI;
        Projectile.direction = player.direction;
        Projectile.position.Y = player.position.Y - 30 + 4;

        if (player.GetModPlayer<EclipseModPlayer>().attack == true)
        {

            Projectile.friendly = true;
            Projectile.position.X = player.position.X + ((50 * Projectile.direction) - 30);
          
            if (player.position.X > Main.MouseWorld.X)

            {
                player.direction = -1;
            }
            else
            { 
                player.direction = 1;
        }

            if (Projectile.ai[0] == 0)
            {
                player.velocity = Vector2.Normalize(Main.MouseWorld - player.Center) * (ChargeTime/6);
            }
              
            Projectile.ai[0] += 1f;
            if (++Projectile.frameCounter >= 6)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }
            if (Projectile.ai[0] >= 36)
            {
                player.GetModPlayer<EclipseModPlayer>().attack = false;
                ChargeTime = 0;
                Projectile.ai[0] = 0; 
                Projectile.frame = 0;
                Projectile.friendly = false;

            }

        }
    
        
}
    public override bool PreDraw(ref Color lightColor)
    {
        Player player = Main.player[Projectile.owner];
        SpriteEffects spriteEffects = SpriteEffects.None;
        if (player.direction <= 0)
        {
            spriteEffects = SpriteEffects.FlipHorizontally;
            Projectile.position.X = player.position.X + 24 - 30;
        }
          else
        {
            Projectile.position.X = player.position.X + 64 - 30;
        }
        Texture2D texture = TextureAssets.Projectile[Type].Value;
        int frameHeight = texture.Height / Main.projFrames[Type];
        int startY = frameHeight * Projectile.frame;
        Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
        Vector2 origin = sourceRectangle.Size() / 2f;
        float offsetX = 20f;
        origin.X = (float)(Projectile.spriteDirection == 1 ? sourceRectangle.Width - offsetX : offsetX);
        Color drawColor = Projectile.GetAlpha(lightColor);

        Main.EntitySpriteDraw(texture,
            Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),

            sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);

        return false;
    }
    }