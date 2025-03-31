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

public class HeartShard : ModProjectile
{

    public override void SetStaticDefaults()
    {
        Main.projFrames[Projectile.type] = 3;
    }


    public override void SetDefaults()
    {
        Projectile.width = 16;
        Projectile.height = 16;
        Projectile.friendly = false;
        Projectile.timeLeft = 2000;
        Projectile.penetrate = 1;
        Projectile.tileCollide = true;
        Projectile.aiStyle = -1;
        
    }
   
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        return false;
    }
    public override void OnSpawn(IEntitySource source)
    {
        SpriteEffects spriteEffects = SpriteEffects.None;
        Projectile.frame = Main.rand.Next(0, 2);
        if (Main.rand.NextBool(2))
        {
            spriteEffects = SpriteEffects.FlipHorizontally;
        }
    }
    public override void AI()
    {
        Player player = Main.player[Projectile.owner];

        Projectile.velocity.X *= .9f;

      Projectile.velocity.Y *= .95f;
        Projectile.velocity.Y += .1f;

        if (player.Hitbox.Intersects(Projectile.Hitbox))
        {
            player.statLife += 3;
            player.HealEffect(3);
            Projectile.Kill();
            SoundEngine.PlaySound(SoundID.Item4 with { Pitch = .5f, PitchVariance = .5f, Volume = .4f },Projectile.Center);
        }

    }





    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(1f, 1f, 1f, 1f);

    }
}
