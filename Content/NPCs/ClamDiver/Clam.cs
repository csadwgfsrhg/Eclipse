
using Eclipse.Content.Projectiles.Enemy;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;

using Terraria.ModLoader.Utilities;

namespace Eclipse.Content.NPCs.ClamDiver
{

    public class Clam : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 2;
        }

        public override void SetDefaults()
        {
            NPC.width = 28;
            NPC.height = 28;
            NPC.damage = 20;
            NPC.defense = 20;
            NPC.lifeMax = 40;
            NPC.HitSound = SoundID.NPCHit7;
            NPC.DeathSound = SoundID.NPCDeath11;
            NPC.value = 20f;
            NPC.knockBackResist = 0.1f;
            NPC.aiStyle = -1;




        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

            npcLoot.Add(ItemDropRule.Common(ItemID.Seashell, 10));
            npcLoot.Add(ItemDropRule.Common(ItemID.WhitePearl, 100));
            npcLoot.Add(ItemDropRule.Common(ItemID.BlackPearl, 700));
            npcLoot.Add(ItemDropRule.Common(ItemID.PinkPearl, 2000));
        }
        int charge;


        public override void AI()
        {
            NPC.spriteDirection = NPC.direction;
         
            NPC.rotation += (NPC.velocity.X / 20);


            charge++;
            Player player = Main.LocalPlayer;
            if (NPC.wet)
            {
                charge++;
                NPC.velocity *= .99f;
                NPC.velocity.Y += .2f;
            }
            else
            {
                NPC.velocity *= .95f;
                NPC.velocity.Y += .3f;


            }
            if (charge > 0)
            {
                NPC.frame.Y = 0;
                NPC.defense = 5;

            }
            if (charge > 30)
            {
                charge = -10;
               
                NPC.velocity = (Vector2.Normalize((player.Center ) - NPC.Center) * Main.rand.Next(1, 10) ) + new Vector2(Main.rand.Next(-6, 6), Main.rand.Next(-8, -2) )      ;

                NPC.frame.Y = 28;
                NPC.defense = 20;

            }

        }
    }
}