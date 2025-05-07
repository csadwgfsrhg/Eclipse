
using Eclipse.Content.Projectiles.Enemy;
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
            NPC.defense = 11;
            NPC.lifeMax = 700;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 60f;
            NPC.knockBackResist = 0.1f;
            NPC.aiStyle = 26;




        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

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


       





      
        
            if (charge< 0)
            {
                NPC.velocity *= .9f;
                NPC.aiStyle = -1;
                OpenMouth(player);


    }
    else
            {

                WalkAnim(player);
                NPC.aiStyle = 26;
                anime = 0;




            }

            if (charge > 80)
            {
                if (Main.rand.NextBool(3))
                {
                
                    charge = -(Main.rand.Next(80, 120));
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
          
            if (shoot >= 10) {
                Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * Main.rand.NextFloat(.8f, 3f), ModContent.ProjectileType<ClamBubble>(), 5, 1, Main.myPlayer);
                shoot = 0;
            }

            if (anime <= 2)

            {
                SoundEngine.PlaySound(SoundID.DD2_DrakinBreathIn, NPC.position);
            }

                anime += 1;


            shoot += Main.rand.Next(2);

            if (anime < 10 || anime > 90)
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

         

            NPC.frameCounter += 0.5f;
            NPC.frameCounter += NPC.velocity.Length() / 10f;
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