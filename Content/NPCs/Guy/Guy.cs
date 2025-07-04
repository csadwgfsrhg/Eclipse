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
using Terraria.GameContent.Bestiary;
using Terraria.Utilities;


namespace Eclipse.Content.NPCs.Guy
{
    
    public class Guy : ModNPC
    {
        public override string Name => "Beast Fisher";
        public override string Texture => "Eclipse/Content/NPCs/Guy/Guy";
        public static Texture2D glow;
        bool GlowmaskNeeded = false;
        const int Idle = 0, Walking = 1, Attacking = 14, Emote = 7;
        float OldAi;
        public override string GetChat()
        {
            WeightedRandom<string> poggerschat = new WeightedRandom<string>();
            poggerschat.Add("I hate my bitch wife, she took my kid and ruined him");
            poggerschat.Add("People never want to be around me, they say that derplings make up 13% of the jungle population and commit 52% of all murders. ");
            poggerschat.Add("Who the fuck listens to \"THE WEEKEND\"." );
            poggerschat.Add("My son keeps trying to use me as bait...");
            poggerschat.Add("Got any weed?");
            poggerschat.Add("Sometimes I think my curse is a blessing, fish love me now! ");
            poggerschat.Add("My son needs to stop watching porn , he can't even talk to girls normally. ");
            poggerschat.Add("I regret not being around that much for my son, but my bitch wife took him as soon as I got cursed.");
            //   poggerschat.Add("Fun fact: Derplings pee out of our belly buttons.");
            //    poggerschat.Add("Derp derp derpaty derp.", 0.1);  
            //    poggerschat.Add("DO THE DISHES", 0.1);
            //  poggerschat.Add("PORN IS FOR LOOSERS.", 0.1);
            //  poggerschat.Add("Back in my fishing prime in '87 they used to call me the master baiter.");
            //   poggerschat.Add("🅱0I", 0.001);
            return poggerschat;
        }
        public override List<string> SetNPCNameList()
        {
            return new List<string> {
                "Yharim",
                "Lillhult",
                "Solhetta",
                "Duracell",
                "Salton",
                "Ralph Lauren",
                "WiiU",
                "Vitomix",
                "Cordless",
            };
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            NPC.rarity = 3;
            bestiaryEntry.Info.AddRange([
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,
				// Sets your NPC's flavor text in the bestiary. (use localization keys)
				new FlavorTextBestiaryInfoElement("He lives in his makeshift fishing hut, seeking peace and quiet from his bitch wife through fishing."),
            ]);

        }
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 14;

            NPCID.Sets.AttackFrameCount[Type] = 3;
            NPCID.Sets.ExtraFramesCount[Type] = 1;
            NPCID.Sets.AttackType[Type] = 2;
            NPCID.Sets.HatOffsetY[Type] = -4;
            NPCID.Sets.ExtraTextureCount[Type] = 1;
            NPCID.Sets.AttackTime[Type] = 53;
            NPCID.Sets.AttackAverageChance[Type] = 3;


            //NPC happiness, beastiary. (emots/shimmer maybe)
        }
        public override void SetDefaults()
        {
            NPC.lifeMax = 300;
            NPC.width = 48;
            NPC.height = 48;
            NPC.townNPC = true;
            NPC.aiStyle = 7;
            NPC.friendly = true;
            OldAi = -69f;
            
            //AnimationType = NPCID.Guide;


        }
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
        public override void FindFrame(int frameHeight)
        {
            GlowmaskNeeded = false;
            switch (NPC.ai[0])
            {
                case Idle:
                    NPC.frameCounter = 0;
                    break;

                case Walking:

                    if (NPC.ai[1] % 6 == 0)
                        NPC.frameCounter = (NPC.frameCounter + 1) % 6;
                    break;

                case Attacking:


                    GlowmaskNeeded = true;
                    if (NPC.ai[1] == NPCID.Sets.AttackTime[Type])
                        NPC.frameCounter = 9;
                    if (NPC.ai[1] % 12 == 0)
                        NPC.frameCounter = MathHelper.Clamp((int)(NPC.frameCounter + 1) % 9, 6, 8);

                    //if (NPC.frameCounter != 6 && NPC.frameCounter != 7 && NPC.frameCounter != 8)
                    //Main.NewText(NPC.frameCounter);
                    break;
            }
            Rectangle frame = new Rectangle(0, (int)NPC.frameCounter * /*(56 + 2)*/frameHeight, 58, 56);
            NPC.frame = frame;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
/*            Main.NewText(NPC.ai[0]);
            Main.NewText(NPC.ai[1]);*/

            glow ??= (Texture2D)ModContent.Request<Texture2D>(Texture + "_Glow");

            Vector2 NeededOffset = new Vector2(NPC.direction == 1 ? -18 : -10, -6);
            
            SpriteEffects DrawDir = NPC.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            spriteBatch.Draw(TextureAssets.Npc[Type].Value, NPC.position - screenPos + NeededOffset, NPC.frame, drawColor, 0f, Vector2.Zero, 1f, DrawDir, 1f);
            if (GlowmaskNeeded)
                spriteBatch.Draw(glow, NPC.position - screenPos + NeededOffset, NPC.frame, drawColor, 0f, Vector2.Zero, 1f, DrawDir, 1f);
            return false;
        }


    }
}
