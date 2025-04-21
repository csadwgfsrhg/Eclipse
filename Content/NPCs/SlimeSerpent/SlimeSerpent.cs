using Terraria.DataStructures;

namespace Eclipse.Content.NPCs.SlimeSerpent
{
    public class SlimeSerpent : ModNPC
    {
        public override string Texture => "Eclipse/Content/NPCs/SlimeSerpent/SlimeSerpentHead";
        public override void SetStaticDefaults()
        {
            
        }
        public override void SetDefaults()
        {
            NPC.width = 54;
            NPC.height = 48;

            NPC.noTileCollide = true;
            NPC.noGravity = true;
            NPC.lavaImmune = true;
            NPC.lifeMax = 250;

            NPC.friendly = false;
            NPC.aiStyle = -1;
            NPC.knockBackResist = 0f;

            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath11;


        }
        public static Texture2D tex;
        public static Texture2D bodytex;
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {

            Player target = Main.player[NPC.target];
            float rot = new Vector2(MathF.Abs(target.position.X - NPC.position.X), target.position.Y - NPC.position.Y).ToRotation();
            rot = MathHelper.Clamp(rot * NPC.direction, MathHelper.ToRadians(-30), MathHelper.ToRadians(30));

            Rectangle frame = new Rectangle(0, (NPC.height + 2) * (int)NPC.frameCounter, NPC.width, NPC.height);


            tex ??= ModContent.Request<Texture2D>("Eclipse/Content/NPCs/SlimeSerpent/SlimeSerpentHead", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
            bodytex ??= ModContent.Request<Texture2D>("Eclipse/Content/NPCs/SlimeSerpent/SlimeSerpentBody", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;

            if (NPC.ai[3] == 0)
            {
                Eclipse.JigglePhysics.Value.Parameters["uImage1"].SetValue(Eclipse.THENOISEPIZZATOWER);
                Eclipse.JigglePhysics.Value.Parameters["time"].SetValue(NPC.ai[0]);
            }

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone, Eclipse.JigglePhysics.Value, Main.GameViewMatrix.TransformationMatrix);

            if (NPC.ai[3] == 0)
                spriteBatch.Draw(tex, NPC.position - screenPos + NPC.Size / 2, frame, Color.White, rot, NPC.Size / 2, 1f, NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            else
                spriteBatch.Draw(bodytex, NPC.position - screenPos + NPC.Size / 2, null, Color.White, rot, NPC.Size / 2, 1f - NPC.ai[3] * 0.111f, NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone, null, Main.GameViewMatrix.TransformationMatrix);

            return false;
        }
        public int Segments = 7;
        Vector2 DashTarget = Vector2.Zero;
        public void InitPhase()
        {
            Player target = Main.player[NPC.target];
            // a little initilization of targeting n shit
            switch (NPC.ai[1])
            {
                // Looping
                case 1:
                    NPC.ai[0] = 1000; // cant do random intervals not enuf ai :pensive:

                    break;


                // Charging
                case 2:
                    NPC.ai[0] = 1200;
                    DashTarget = NPC.DirectionTo(target.Center) * 20;
                    break;
            }
        }
        public void ChangePhaseRand()
        {
            NPC.ai[1] = Main.rand.Next(1, 3);
            InitPhase();
        }
        public override void OnSpawn(IEntitySource source)
        {
            //CALL ONLY FOR HEAD
            if (NPC.ai[3] == 0)
            {
                ChangePhaseRand();

                for (int i = 1; Segments > i; i++)
                {
                    NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X, (int)NPC.position.Y, Type, ai0: NPC.ai[0], ai2: NPC.whoAmI, ai3: i);
                }
            }
        }
        public Vector2 OldPos;
        public Vector2 GetLoop(float ai0, float speed, Vector2 size) => new Vector2(MathF.Sin(ai0 / speed) * size.X, MathF.Cos(ai0 / speed) * size.Y);
        public NPC? GetSegment(int Head, int SegmentNo)
        {
            for (int i = 0; Main.npc.Length > i; i++)
            {
                if (Main.npc[i].ai[2] == Head && Main.npc[i].ai[3] == SegmentNo && Main.npc[i].type == Type)
                    return Main.npc[i];
            }
            return null;
        }
        public override void OnKill()
        {
            if (NPC.ai[3] == 0)
            {
                for (int i = 1; Segments > i; i++)
                {
                    NPC? tokill = GetSegment(NPC.whoAmI, i);
                    if (tokill is not null && tokill.active)
                        Main.npc[tokill.whoAmI].StrikeInstantKill();
                }
            }
            for (int i = 0; Main.rand.Next(4, 8) > i; i++)
                Dust.NewDust(NPC.Center, NPC.width, NPC.height, DustID.t_Slime, 1, 1, 157, new Color(43, 109, 138), 0.8f);
        }
        public override void AI()
        {
            float ISHOWSPEED = 30f;
            Vector2 LeSize = new Vector2(420, 210) * 3.46f;
            LeSize = LeSize.RotatedBy((NPC.ai[0] / (MathHelper.Pi / 2f) / 200));

            if (NPC.ai[3] == 0)
            {
                //HEAD
                NPC.TargetClosest();
                Player target = Main.player[NPC.target];
                NPC.spriteDirection = -NPC.direction;

                switch (NPC.ai[1])
                {
                    // Looping
                    case 1:
                        Vector2 Loop = GetLoop(-NPC.ai[0], ISHOWSPEED, LeSize);
                        Vector2 ToLErp = (target.Center + Loop - NPC.Size / 2);

                        NPC.position += (ToLErp - NPC.position) / 140f;
                    break;


                    // Charging
                    case 2:

                    break;
                }

                if (NPC.ai[0] > 0)
                    NPC.ai[0]--;
            }
            else
            {
                //BODY

                NPC TheHead = Main.npc[(int)NPC.ai[2]];
                NPC.ai[0] = TheHead.ai[0];
                NPC.ai[1] = TheHead.ai[1];

                if (NPC.ai[3] > 1)
                {
                    NPC? PreviousSegment = GetSegment((int)NPC.ai[2], (int)NPC.ai[3] - 1);
                    if (PreviousSegment == null)
                    {
                        NPC.ai[3] -= 1;
                    }
                    else
                    {
                        if (!PreviousSegment.active)
                        {
                            NPC.ai[3] -= 1;
                            Main.npc[PreviousSegment.whoAmI].type = -1;
                        }
                    }
                }
                

                Player target = Main.player[TheHead.target];

                switch (NPC.ai[1])
                {
                    // Looping
                    case 1:
                        Vector2 Loop = GetLoop(-NPC.ai[0] - NPC.ai[3] * 8, ISHOWSPEED, LeSize);
                        Vector2 ToLErp = (target.Center + Loop - NPC.Size / 2);

                        NPC.position += (ToLErp - NPC.position) / 140f;
                    break;
                }
                
            }
        }
    }
}
