using System.IO;
using Eclipse.Common;

using Eclipse.Content.Items.Melee.Katana;
using Eclipse.Dusts;
using Eclipse.Utilities.Extensions;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Graphics;


namespace Eclipse.Content.Projectiles.Ranged.Ammo;

public class TendonShot : ModProjectile
{


    int heal;

    public sealed override void SetDefaults()
    {

 


        Projectile.ignoreWater = true;
        Projectile.tileCollide = true;
        Projectile.penetrate = 1;
        Projectile.width = 8;
        Projectile.height = 8;
        Projectile.extraUpdates = 2;
        Projectile.friendly = true;
        Projectile.timeLeft = 120;
        Projectile.aiStyle = 1;
        Projectile.DamageType = DamageClass.Ranged;

    }
    public override void OnSpawn(IEntitySource source)
    {
        heal = Projectile.damage;
    }
    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        Player player = Main.player[Projectile.owner];

        player.statLife += (heal);
        player.HealEffect(heal);

    }
    public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
    {
        target.lifeRegen = -60;
        Projectile.damage = 1;
    }
   




    public override void AI()
    {
        if ((int)Projectile.ai[2] == ProjectileID.JestersArrow)
        {
            Projectile.aiStyle = -1;
        
        }
        if (Main.rand.NextBool(2))
        {
            Dust.NewDust(Projectile.position, 0, 0, DustID.Blood, 0, 0, 255 - Projectile.timeLeft * 2, newColor: (default), 1f);
        }
    }
}