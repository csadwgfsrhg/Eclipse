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

public class HeartBig : ModProjectile
{




    public sealed override void SetDefaults()
    {

 


        Projectile.ignoreWater = true;
        Projectile.tileCollide = false;
        Projectile.penetrate = 1;
        Projectile.width = 32;
        Projectile.height = 32;
        Projectile.usesLocalNPCImmunity = true;
        Projectile.localNPCHitCooldown = -1;
        Projectile.friendly = false;

        Projectile.aiStyle = -1;


    }

     private bool stopped = false;

    private float ChargeTime
    {
        get => Projectile.ai[1];
        set => Projectile.ai[1] = value;
    }
    public override void OnKill(int timeLeft)
    {

        {
          
            for (int i = 0; i < ChargeTime / 15; i++)
            {

                Vector2 launchVelocity = new Vector2(Main.rand.NextFloat(ChargeTime/6, -ChargeTime / 6), Main.rand.NextFloat(ChargeTime / 6, -ChargeTime / 6));


                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ModContent.ProjectileType<HeartShard>(), 0, Projectile.knockBack, Projectile.owner);
            }

            SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
        }
    }
    public override void AI()
    {
        Player player = Main.player[Projectile.owner];
        if (stopped == true)
        {

            Projectile.tileCollide = true;
            Projectile.aiStyle = 25;
            Projectile.velocity *= .99f;
        }
        else
        {
          
            Projectile.position = player.Center;
            Projectile.position.X -= 20;
            Projectile.position.Y -= 10;
            Projectile.velocity = Vector2.Normalize(Main.MouseWorld - player.Center) * 100;
            Projectile.scale = .5f + (ChargeTime / 120);
            Projectile.Size = new Vector2(32, 32) * Projectile.scale;

            Projectile.rotation = ((float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X)) + 500 / (10+ ChargeTime);
        }


        if (!Charge(player))
        {
            return; // timer doesn't update while charging, freezing the animation at the start.
        }

    }

    private bool Charge(Player owner)
    {
        // Like other whips, this whip updates twice per frame (Projectile.extraUpdates = 1), so 120 is equal to 1 second.
        if (stopped == false && (!owner.channel || ChargeTime >= 120 || owner.statMana < 1))
        {
            Projectile.velocity = Vector2.Normalize(Main.MouseWorld - owner.Center) * (10 + (ChargeTime / 10)) ;
            Projectile.damage = (int)(Projectile.damage * ((25 + ChargeTime) / 25));
            stopped = true;
            Projectile.friendly = true;
            return true; // finished charging
        }
       if (stopped == false && owner.channel)
        {
            ChargeTime++;
            Projectile.ai[0] += 1;
            if  (Projectile.ai[0] >= 5)
            {
                SoundEngine.PlaySound(SoundID.Item43 with { Pitch = 1 - (ChargeTime / 90), Volume = (ChargeTime / 30) },
                Projectile.Center);
                owner.statMana -= 3;
                Projectile.ai[0] = 0;
            }
         
        }
            
        
       

     
        return true;

    }
    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(1f, 1f, 1f, 1f);

    }
}
