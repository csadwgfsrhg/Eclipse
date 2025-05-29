

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

            NPC.lifeMax = 1000;
            NPC.HitSound = SoundID.NPCHit7;
            NPC.DeathSound = SoundID.NPCDeath11;
            NPC.value = 20f;
            NPC.knockBackResist = 1f;
            NPC.aiStyle = -1;
            NPC.noTileCollide = true;
            NPC.noGravity = true;


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
        public override Color? GetAlpha(Color drawColor) => Color.White;

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

}
