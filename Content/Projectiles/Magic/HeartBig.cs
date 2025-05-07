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

    public override void SetStaticDefaults()
    {
        Main.projFrames[Projectile.type] = 11;
    }


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
        Projectile.rotation = Main.rand.Next(360);
        Projectile.aiStyle = -1;


    }

     private bool stopped = false;

    private float ChargeTime
    {
        get => Projectile.ai[2];
        set => Projectile.ai[2] = value;
    }
    public override void OnKill(int timeLeft)
    {

        {
          
            for (int i = 0; i < ChargeTime / 15; i++)
            {

                Vector2 launchVelocity = new Vector2(Main.rand.NextFloat(ChargeTime/6, -ChargeTime / 6), Main.rand.NextFloat(ChargeTime / 6, -ChargeTime / 6));

                Dust.NewDust(Projectile.position, 32, 32, DustID.CrimsonSpray, 0, 0, 255, newColor: (default), 1f);
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ModContent.ProjectileType<HeartShard>(), 0, Projectile.knockBack, Projectile.owner);
            }

            SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
        }
    }
    public override void AI()
    {
        if (Main.rand.NextBool(30)) {
            Dust.NewDust(Projectile.position, 32, 32, DustID.CrimsonSpray, 0, 0, 255, newColor: (default), 1f);

        }
      
        if (Projectile.ai[1] % 6 == 0)
            Projectile.frame = (int)(  Projectile.frame + 1) % 11;

        Projectile.ai[1]++;
    
    Player player = Main.player[Projectile.owner];
        if (stopped == true)
        {

            Projectile.tileCollide = true;
            Projectile.aiStyle = 0;
            Projectile.velocity.Y += .5f;
               Projectile.rotation += (Projectile.velocity.X / 20);
            Projectile.velocity *= .99f;
        }
        else
        {
          
            Projectile.position = player.Center;
            Projectile.position.X -= 18;
            Projectile.position.Y -= 22;
            Projectile.velocity = Vector2.Normalize(Main.MouseWorld - player.Center) * 100;
            Projectile.scale = .5f + (ChargeTime / 120);
           
            Projectile.Resize((int)(32 * Projectile.scale), (int)(32 * Projectile.scale));


        }


        if (!Charge(player))
        {
            return; // timer doesn't update while charging, freezing the animation at the start.
        }

    }

    private bool Charge(Player owner)
    {
      
      
        if (stopped == false && (!owner.channel || owner.statMana < 1))
        {
        
                Projectile.velocity = Vector2.Normalize(Main.MouseWorld - owner.Center) * (10 + (ChargeTime / 10)) ;
            Projectile.damage = (int)(Projectile.damage * ((25 + ChargeTime) / 25));
            stopped = true;
            Projectile.friendly = true;
            return true; // finished charging
        }
       if (stopped == false && owner.channel)
        {
            Projectile.rotation += (10f / ChargeTime);
            Projectile.rotation = ((float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X)) + 500 / (10 + ChargeTime) + 1f;
            if (ChargeTime >= 120)
            {

                Projectile.rotation += .1f;

            }
            else
            {

                ChargeTime++;
                Projectile.ai[0] += 1;
                if (Projectile.ai[0] >= 5)
                {
                    SoundEngine.PlaySound(SoundID.Item43 with { Pitch = 1 - (ChargeTime / 90), Volume = (ChargeTime / 30) },
                    Projectile.Center);
                    owner.statMana -= 3;
                    Projectile.ai[0] = 0;
                }
            }
           
          
         
        }
            
        
       

     
        return true;

    }
 
}
