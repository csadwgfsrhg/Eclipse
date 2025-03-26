using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;


namespace Eclipse.Content.NPCs.Guy
{
    
    public class Guy : ModNPC
    {

        public static Texture2D glow;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 10;

            NPCID.Sets.AttackFrameCount[Type] = 3;
            NPCID.Sets.ExtraFramesCount[Type] = 1;
            NPCID.Sets.AttackType[Type] = 2;
            NPCID.Sets.AttackTime[Type] = 160;
            NPCID.Sets.HatOffsetY[Type] = -4;
            NPCID.Sets.ExtraTextureCount[Type] = 1;
            NPCID.Sets.AttackTime[Type] = 53;

            


            //NPC happiness, beastiary. (emots/shimmer maybe)
        }
        float OldAi;
        public override void SetDefaults()
        {
            NPC.lifeMax = 300;
            NPC.width = 50;
            NPC.height = 56;
            NPC.townNPC = true;
            NPC.aiStyle = 7;
            NPC.friendly = true;
            OldAi = -69f;
            
            //AnimationType = NPCID.Guide;


        }
        const int Idle = 0, Walking = 1, Attacking = 14, Emote = 7;
        public override void PostAI()
        {
            if (NPC.ai[0] != OldAi)
                OldAi = NPC.ai[0];
        }
        public override void AI()
        {
            if (NPC.ai[0] == Attacking)
            {
                if (NPC.ai[1] == 17)
                {
                    for(int i = 0; Main.npc.Length > i; i++)
                    {
                        NPC npeec = Main.npc[i];
                        if (npeec.active)
                        {
                            double Distance = Math.Pow(npeec.position.X - NPC.position.X, 2) + Math.Pow(npeec.position.Y - NPC.position.Y, 2);
                            Distance = Math.Sqrt(Distance);
                            if (Distance < Math.Pow(20, 2) && !npeec.friendly && !npeec.immortal)
                            {
                                Projectile.NewProjectile(NPC.GetSource_FromThis(), npeec.position, Vector2.Zero, 918, 100, 0f);
                            }
                        }
                    }
                }

            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
/*            Main.NewText(NPC.ai[0]);
            Main.NewText(NPC.ai[1]);*/

            glow ??= (Texture2D)ModContent.Request<Texture2D>(Texture + "_Glow");

            Vector2 NeededOffset = new Vector2(NPC.direction == 1 ? -18 : -10, 0);
            bool GlowmaskNeeded = false;
            switch(NPC.ai[0])
            {
                case Idle:
                    NPC.frameCounter = 0;
                    break;

                case Walking:

                    if (NPC.ai[1] % 6 == 0)
                        NPC.frameCounter = (NPC.frameCounter + 1) % 5;
                    break;

                case Attacking:



                    GlowmaskNeeded = true;
                    if (NPC.ai[1] == NPCID.Sets.AttackTime[Type])
                        NPC.frameCounter = 6;
                    if (NPC.ai[1] % 12 == 0)
                        NPC.frameCounter = MathHelper.Clamp((int)(NPC.frameCounter + 1) % 9, 6, 8);

                    //if (NPC.frameCounter != 6 && NPC.frameCounter != 7 && NPC.frameCounter != 8)
                    //Main.NewText(NPC.frameCounter);
                    break;
            }

            Rectangle frame = new Rectangle(0, (int)NPC.frameCounter * (56 + 2), 76, 56);

            NPC.frame = frame;
            SpriteEffects DrawDir = NPC.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            spriteBatch.Draw(TextureAssets.Npc[Type].Value, NPC.position - screenPos + NeededOffset, frame, drawColor, 0f, Vector2.Zero, 1f, DrawDir, 1f);
            if (GlowmaskNeeded)
                spriteBatch.Draw(glow, NPC.position - screenPos + NeededOffset, frame, drawColor, 0f, Vector2.Zero, 1f, DrawDir, 1f);
            return false;
        }


    }
}
