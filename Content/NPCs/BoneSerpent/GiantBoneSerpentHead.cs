

using Terraria.DataStructures;
using Terraria.GameContent.Animations;

namespace Eclipse.Content.NPCs.BoneSerpent
{

    public class GiantBoneSerpentHead : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 3;
        }
        public override void SetDefaults()
        {
            NPC.width = 132;
            NPC.height = 104;
            NPC.damage = 20;
            NPC.defense = 20;
            NPC.behindTiles = true;
            NPC.lifeMax = 1000;
            NPC.HitSound = SoundID.NPCHit7;
            NPC.DeathSound = SoundID.NPCDeath11;
            NPC.value = 20f;
            NPC.knockBackResist = 1f;
            NPC.aiStyle = -1;
            NPC.noTileCollide = true;
            NPC.noGravity = true;


        }

        public override void OnSpawn(IEntitySource source)
        {
            for (int i = 1; 20 > i; i++)
            {

                NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<GiantBoneSerpentBody1>(), ai2: NPC.whoAmI, ai3: i);
                NPC.position.X += 50;

            }
        }

        int Attack = 0;
   
        int AttackFrames = 0;

      
        public override void AI()
        {


            

            Player player = Main.LocalPlayer;


            if (Attack > 200)
            {
                AttackFrames++;
            }
            else
            {

                NPC.velocity += Vector2.Normalize(player.Center - NPC.Center) / 8;
                //     Attack++;
                NPC.velocity.X *= .999f;
                NPC.velocity.Y *= .96f;
            }
            if (AttackFrames > 50)
            {
                AttackFrames = 0;
                Attack = 0;

                NPC.velocity.X *= .92f;
                NPC.velocity.Y *= .90f;
            }







            rotation(player);

        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {

            return true;
        }
        private void rotation(Player player)
        {

            if (NPC.velocity.X > 0 && NPC.velocity.X > 1)
            {
                NPC.frame.Y = 0;
                NPC.spriteDirection = -1;
                NPC.rotation = NPC.velocity.ToRotation();
            }

            if (NPC.velocity.X > -4 && NPC.velocity.X < 4)
            {

                if (NPC.velocity.X > -1 && NPC.velocity.X < 1)
                    NPC.frame.Y = 104;
                else
                    NPC.frame.Y = 208;
            }

            if (NPC.velocity.X < 0 && NPC.velocity.X < -1)
            {
                NPC.frame.Y = 0;
                NPC.spriteDirection = 1;
                NPC.rotation = (NPC.velocity.ToRotation() - 3);
            }

        }
    }
        public class GiantBoneSerpentBody1 : ModNPC
        {
            public override void SetDefaults()
            {
                NPC.width = 62;
                NPC.height = 132;
                NPC.damage = 20;
                NPC.behindTiles = true;
                NPC.immortal = true;
                NPC.HitSound = SoundID.NPCHit7;
                NPC.DeathSound = SoundID.NPCDeath11;
                NPC.value = 20f;
                NPC.knockBackResist = 2f;
                NPC.aiStyle = -1;
                NPC.noTileCollide = true;
                NPC.noGravity = true;


            }
            public override void AI()
            {
                NPC TheHead = Main.npc[(int)NPC.ai[2]];
                NPC.position = TheHead.position;



                if (NPC.velocity.X > 0)
                {
                    NPC.spriteDirection = -1;
                    NPC.rotation = NPC.velocity.ToRotation();
                }
                else
                {
                    NPC.spriteDirection = 1;
                    NPC.rotation = (NPC.velocity.ToRotation() - 3);

                }
            }
        }
    }
