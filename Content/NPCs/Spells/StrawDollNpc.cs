
using Eclipse.Content.Buffs;
using Eclipse.Content.Dusts;
using Eclipse.Content.Projectiles.Enemy;
using System.Diagnostics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;

using Terraria.ModLoader.Utilities;

namespace Eclipse.Content.NPCs.Spells
{

    public class StrawDollNpc : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 4;
        }

        public override void SetDefaults()
        {
          
          //  NPC.buffImmune[Type] = true;
            NPC.width = 30;
            NPC.height = 34;
            NPC.damage = 0;
            NPC.chaseable = false;

            NPC.defense = 0;
            NPC.lifeMax = 100;
      NPC.HitSound = SoundID.NPCHit11;
            NPC.DeathSound = SoundID.NPCDeath15;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 1f;
            NPC.aiStyle = -1;
            NPC.noGravity = true;
   


        }
        int range = 250;
        public override void OnSpawn(IEntitySource source)
        {
            NPC.velocity = new Vector2(0 , -1 );
            range = 250;
        }
      
        public override void OnHitByProjectile(Projectile projectile, NPC.HitInfo hit, int damageDone)
        {

        
                foreach (var npc in Main.ActiveNPCs )
            {
                if (npc.type != ModContent.NPCType<StrawDollNpc>() && npc.friendly == false && npc.position.X >= NPC.position.X - range && npc.position.X <= NPC.position.X + range
           && npc.position.Y >= NPC.position.Y - range && npc.position.Y <= NPC.position.Y + range)
                    npc.AddBuff(ModContent.BuffType<Hurt>(),(int) (1+ damageDone / 5f));


            }
            base.OnHitByProjectile(projectile, hit, damageDone);
        }
        public override void OnHitByItem(Player player, Item item, NPC.HitInfo hit, int damageDone)
        {
            foreach (var npc in Main.ActiveNPCs)
            {
                if (npc.type != ModContent.NPCType<StrawDollNpc>()    && npc.friendly == false && npc.position.X >= NPC.position.X - range && npc.position.X <= NPC.position.X + range
                     && npc.position.Y >= NPC.position.Y - range && npc.position.Y <= NPC.position.Y + range)
                    npc.AddBuff(ModContent.BuffType<Hurt>(), (int)(1 + damageDone / 5f));

            }
            base.OnHitByItem(player, item, hit, damageDone);
        }
        public override void AI()
        {
          
            foreach (var npc in Main.ActiveNPCs)
            {
                
                if (npc.type != ModContent.NPCType<StrawDollNpc>() && npc.friendly == false && npc.position.X >= NPC.position.X - range && npc.position.X <= NPC.position.X + range
            && npc.position.Y >= NPC.position.Y - range && npc.position.Y <= NPC.position.Y + range)
                    if (  Main.rand.NextBool(5))
                Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Voodoo>());

            }
            NPC.velocity += (Main.MouseWorld - NPC.position) / 2000;
                NPC.velocity *= .96f;
            NPC.frameCounter += 0.4f;
            NPC.frameCounter += NPC.velocity.Length() / 15f;
            if (NPC.frameCounter > 6)
            {
                NPC.frameCounter = 0;
                NPC.frame.Y += 34;
                if (NPC.frame.Y > 3 * 34)
                {
                    NPC.frame.Y = 0 * 34;
                }
            }
            NPC.spriteDirection = NPC.direction;
        }

    }

}
