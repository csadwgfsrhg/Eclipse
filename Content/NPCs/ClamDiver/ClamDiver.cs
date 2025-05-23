
using Eclipse.Content.Projectiles.Enemy.Bubble;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;

using Terraria.ModLoader.Utilities;

namespace Eclipse.Content.NPCs.ClamDiver
{

    public class ClamDiver : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 7;
        }

        public override void SetDefaults()
        {
            NPC.width = 66;
            NPC.height = 76;
            NPC.damage = 20;
            NPC.defense = 18;
            NPC.lifeMax = 700;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath18;
            NPC.value = 10000f;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = 26;

           


        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.FishingSeaweed, 2, 0, 3));
            npcLoot.Add(ItemDropRule.Common(ItemID.OldShoe, 3, 0, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.TinCan, 4, 0, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.Coral, 1, 0, 3));
            npcLoot.Add(ItemDropRule.Common(ItemID.Seashell, 1, 2, 4));
            npcLoot.Add(ItemDropRule.Common(ItemID.WhitePearl, 10));
            npcLoot.Add(ItemDropRule.Common(ItemID.BlackPearl, 25));
            npcLoot.Add(ItemDropRule.Common(ItemID.PinkPearl, 50));
            npcLoot.Add(ItemDropRule.Common(ItemID.DivingHelmet, 5));
            npcLoot.Add(ItemDropRule.Common(ItemID.PirateMap, 3));
        }

        int startFrame = 0;
        int finalFrame = 3;
        int frameSpeed = 5;
        int frameHeight = 76;
        int charge = 0;
        int shoot = 0;
        int anime = 0;
        public override void AI()
        {


            Player player = Main.player[NPC.target];


       
            if (player.dead)
            {
              
                NPC.despawnEncouraged = true;
            }




      
        
            if (charge< 0)
            {
                NPC.velocity.X *= .9f;
                NPC.aiStyle = -1;
                OpenMouth(player);
                NPC.defense = 5;

            }
    else
            {
                NPC.velocity *= .98f;
                WalkAnim(player);
                NPC.aiStyle = 26;
                anime = 0;
                NPC.defense = 16;



            }

            if (charge > 100 - (NPC.lifeMax - NPC.life) / (NPC.lifeMax / 60))
            {
                if (Main.rand.NextBool(3))
                {
                
                    charge = -(Main.rand.Next(100, 150));
                }
                else
                {
                    charge = 0;

                }



            }
            else
            {
                charge += 1;
            }


        }
    

        private void OpenMouth(Player player)
            {
        
            Vector2 direction = (player.Center - NPC.Center).SafeNormalize(Vector2.UnitX) ;
          
            if (shoot >= 12 - (NPC.lifeMax - NPC.life) / (NPC.lifeMax / 6) ) {
                Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * Main.rand.NextFloat(.8f, 6f), ModContent.ProjectileType<ClamBubble>(), 5, 1, Main.myPlayer);
                shoot = 0;
            }

            if (anime <= 30)

            {
                shoot = 0;
                SoundEngine.PlaySound(SoundID.DD2_DrakinBreathIn, NPC.position);
            }
            else
            {
                shoot += Main.rand.Next(2);

            }
            anime += 1;


        
            if (anime < 10 || charge > -10)
            {
                NPC.frame.Y = 4 * frameHeight;
            
            }
            else
            {
                NPC.frameCounter += 1f;
                if (NPC.frameCounter > frameSpeed)
                {
                    NPC.frame.Y += frameHeight;
                    NPC.frameCounter = 0;
                }
                if (NPC.frame.Y > 6 * frameHeight)
                {
                    NPC.frame.Y = 5 * frameHeight;
                 
                }
            }




           



        }
     



        private void WalkAnim(Player player)
        {

         

            NPC.frameCounter += 0.4f;
            NPC.frameCounter += NPC.velocity.Length() / 15f;
            if (NPC.frameCounter > frameSpeed)
            {
                NPC.frameCounter = 0;
                NPC.frame.Y += frameHeight;
                if (NPC.frame.Y > finalFrame * frameHeight)
                {
                    NPC.frame.Y = startFrame * frameHeight;
                }
            }
            NPC.spriteDirection = NPC.direction;
        }

    }



}