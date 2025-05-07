using Eclipse.Content.Items.Runes;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Animations;
using Terraria.Utilities;

namespace Eclipse.Content.NPCs.SlimeSerpent
{
    public class SlimeSerpent : ModNPC
    {
        public override string Texture => "Eclipse/Content/NPCs/SlimeSerpent/SlimeSerpentHead";
        public static WeightedRandom<Item> ItemTable = new WeightedRandom<Item>();
        Item? item;
        int tier;
        public override void SetStaticDefaults()
        {
            if (ItemTable.elements.Count == 0)
            {

                switch (tier)
                {
                    case 3:
                        ItemTable.Add(new Item(ItemID.HermesBoots), 0.2);
                        ItemTable.Add(new Item(ItemID.CloudinaBottle), 0.2);
                        ItemTable.Add(new Item(ItemID.MagicMirror), 0.2);
                        ItemTable.Add(new Item(ItemID.BandofRegeneration), 0.2);
                        ItemTable.Add(new Item(ItemID.ClimbingClaws), 0.2);
                        ItemTable.Add(new Item(ItemID.ShoeSpikes), 0.2);
                        ItemTable.Add(new Item(ItemID.Aglet), 0.2);
                        ItemTable.Add(new Item(ItemID.LavaCharm), 0.05);
                        ItemTable.Add(new Item(ItemID.SlimeStaff), 0.01);
                        ItemTable.Add(new Item(ItemID.SuspiciousLookingEye), 0.21);
                        ItemTable.Add(new Item(ItemID.AngelStatue), 0.21);
                     
                    break;
                }
              
                ItemTable.Add(new Item(ItemID.Torch, Main.rand.Next(12, 34)), 1);
                ItemTable.Add(new Item(ItemID.Bomb, Main.rand.Next(10, 25)), 1);
                ItemTable.Add(new Item(ItemID.RegenerationPotion, Main.rand.Next(2, 6)), 1);
                ItemTable.Add(new Item(ItemID.ShinePotion, Main.rand.Next(2, 6)), 1);
                ItemTable.Add(new Item(ItemID.NightOwlPotion, Main.rand.Next(2, 6)), 1);
                ItemTable.Add(new Item(ItemID.SwiftnessPotion, Main.rand.Next(2, 6)), 1);
                ItemTable.Add(new Item(ItemID.ArcheryPotion, Main.rand.Next(2, 6)), 1);
                ItemTable.Add(new Item(ItemID.GillsPotion, Main.rand.Next(2, 6)), 1);
                ItemTable.Add(new Item(ItemID.HunterPotion, Main.rand.Next(2, 6)), 1);
                ItemTable.Add(new Item(ItemID.MiningPotion, Main.rand.Next(2, 6)), 1);
                ItemTable.Add(new Item(ItemID.WormholePotion, Main.rand.Next(2, 6)), 0.2);
                ItemTable.Add(new Item(ItemID.PotionOfReturn, Main.rand.Next(2, 6)), 0.2);
                ItemTable.Add(new Item(ItemID.RecallPotion, Main.rand.Next(2, 6)), 1);
                ItemTable.Add(new Item(ItemID.GravitationPotion, Main.rand.Next(2, 6)), 0.2);
                ItemTable.Add(new Item(ItemID.LesserHealingPotion, Main.rand.Next(2, 6)), 1);
                ItemTable.Add(new Item(ItemID.HealingPotion, Main.rand.Next(2, 6)), 1);


                ItemTable.Add(new Item(ModContent.ItemType<MutatedGenome>()), 1);
                ItemTable.Add(new Item(ItemID.Honeyfin), 0.2);
                ItemTable.Add(new Item(ItemID.VariegatedLardfish), 0.5);
                ItemTable.Add(new Item(ItemID.Tuna), 2);
                ItemTable.Add(new Item(ItemID.Trout), 2);
                ItemTable.Add(new Item(ItemID.Stinkfish), 0.5);
                ItemTable.Add(new Item(ItemID.SpecularFish), 0.5);
                ItemTable.Add(new Item(ItemID.Shrimp), 0.5);
                ItemTable.Add(new Item(ItemID.Salmon), 0.5);
                ItemTable.Add(new Item(ItemID.RockLobster), 0.5);
                ItemTable.Add(new Item(ItemID.RedSnapper), 0.5);
                ItemTable.Add(new Item(ItemID.Prismite), .2);
                ItemTable.Add(new Item(ItemID.PrincessFish), 0.5);
                ItemTable.Add(new Item(ItemID.Obsidifish), 0.5);
                ItemTable.Add(new Item(ItemID.ArmoredCavefish), 0.5);
                ItemTable.Add(new Item(ItemID.NeonTetra), 0.5);
                ItemTable.Add(new Item(ItemID.Hemopiranha), 0.5);
                ItemTable.Add(new Item(ItemID.GreenJellyfish), 0.5);
                ItemTable.Add(new Item(ItemID.GoldenCarp), 0.01);
                ItemTable.Add(new Item(ItemID.Fish), 0.05);
                ItemTable.Add(new Item(ItemID.ZephyrFish), 0.05);
                ItemTable.Add(new Item(ItemID.FrostMinnow), 0.5);
                ItemTable.Add(new Item(ItemID.Flounder), 0.5);
                ItemTable.Add(new Item(ItemID.FlarefinKoi), 0.5);
                ItemTable.Add(new Item(ItemID.Ebonkoi), 0.5);
                ItemTable.Add(new Item(ItemID.DoubleCod), 0.5);
                ItemTable.Add(new Item(ItemID.Damselfish), 0.5);
                ItemTable.Add(new Item(ItemID.CrimsonTigerfish), 0.5);
                ItemTable.Add(new Item(ItemID.ChaosFish), 0.5);
                ItemTable.Add(new Item(ItemID.BlueJellyfish), 0.5);
                ItemTable.Add(new Item(ItemID.Bass), 2);
                ItemTable.Add(new Item(ItemID.AtlanticCod), 0.5);
            }
        }
        public override void SetDefaults()
        {
            NPC.width = 54;
            NPC.height = 48;

            NPC.noTileCollide = true;
            NPC.noGravity = true;
            NPC.lavaImmune = true;
            NPC.lifeMax = 250;

            NPC.GravityIgnoresLiquid = true;
            NPC.GravityIgnoresSpace = true;

            NPC.friendly = false;
            NPC.aiStyle = -1;
            NPC.knockBackResist = 0f;


            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath11;

            NPC.waterMovementSpeed = 1f;

            item = null;
            if (Main.rand.NextBool(2))
                item = ItemTable.Get();
        }
        public static Texture2D tex;
        public static Texture2D bodytex;
        public int GetNumSegments(int Head)
        {
            Main.NewText("hi");
            int seg = 0;
            for (int i = 0; Main.npc.Length > i; i++)
            {
                if (Main.npc[i].ai[2] == Head && Main.npc[i].type == Type && Main.npc[i].active)
                    seg++;
            }
            return seg;
        }
        int? SegmentsInBody = null;
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            SegmentsInBody ??= GetNumSegments((int)NPC.ai[2]);
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
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, /*Eclipse.JigglePhysics.Value*/null, Main.GameViewMatrix.TransformationMatrix);
            Color lecolore =  Color.White;

            float TotalScale = MathHelper.Clamp(1f + (SegmentsInBody.Value - 5) * 0.25f, 1f, 5f);

            if (NPC.ai[3] == 0)
                spriteBatch.Draw(tex, NPC.position - screenPos + NPC.Size / 2, frame, lecolore, rot, NPC.Size / 2, TotalScale, NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            else
            {
                spriteBatch.Draw(bodytex, NPC.position - screenPos + NPC.Size / 2, null, lecolore, rot, NPC.Size / 2, TotalScale - NPC.ai[3] * 0.111f, NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);

                if (item is not null)
                {
                    Main.instance.LoadItem(item.type);
                    float ItemScale = TotalScale - NPC.ai[3] * 0.111f;
                    Vector2 ItemOffset = (item.Size / new Vector2(2, 2)) * ItemScale;
                    spriteBatch.Draw(TextureAssets.Item[item.type].Value, NPC.Center - screenPos, null, Color.White * 0.8f, rot, item.Size / 2, -ItemScale, SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically, 1f);
                }
            }
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone, null, Main.GameViewMatrix.TransformationMatrix);

            return false;
        }
        int Segments = 7;
        Vector2 DashTarget = Vector2.Zero;
        public void AdjustToDifficulty()
        {
            float DifficultyFactor = 1f;

            if (Main.expertMode)
                DifficultyFactor = 1.5f;
            if (Main.masterMode)
                DifficultyFactor = 2f;
            if (Main.getGoodWorld)
                DifficultyFactor *= 1.75f;

            NPC.lifeMax = (int)(NPC.life * DifficultyFactor);
            NPC.life = NPC.lifeMax;

            NPC.damage = (int)(NPC.damage * DifficultyFactor);
        }
        public void InitPhase()
        {
            Player target = Main.player[NPC.target];
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            // a little initilization of targeting n shit
            switch (NPC.ai[1])
            {
                // Looping
                case 1:
                    NPC.ai[0] = 600; // cant do random intervals not enuf ai :pensive:

                    break;


                // Charging
                case 2:
                    NPC.ai[0] = 450;
                    break;

                // BouncyBallz
                case 3:


                    NPC.ai[0] = 500;
                    NPC.noGravity = false;
                    NPC.noTileCollide = false;

                    if (NPC.collideX)
                    {
                        ChangePhaseRand();
                        return;
                    }

                    NPC.velocity = -Vector2.UnitY.RotatedByRandom(MathHelper.PiOver2) * 8;
                break;

                // Spawn Slimes
                case 4:
                    NPC.ai[0] = 120;
                    NPC.velocity = NPC.DirectionTo(target.position).RotatedByRandom(0.2f) * 5;

                    break;
            }


        }

        public void ChangePhaseRand()
        {
            int OldPhase = (int)NPC.ai[1];
            while (NPC.ai[1] == OldPhase)
                NPC.ai[1] = Main.rand.Next(1, 5);
            InitPhase();
        }
        public override void OnSpawn(IEntitySource source)
        {
            //CALLED ONLY FOR HEAD
            if (NPC.ai[3] <= 0)
            {
                if (NPC.ai[3] == 0)
                    tier = Main.rand.Next(1, 4);
                else
                    tier = (int)MathF.Abs(NPC.ai[3]);
                NPC.ai[3] = 0;

                switch (tier)
                {
                    case 1:
                        NPC.lifeMax = 500;
                        NPC.life = 500;
                        NPC.damage = 25;
                        NPC.defense = 0;
                        NPC.value = Item.buyPrice( silver: 50);
                        Segments = 5;
                    break;
                    
                    case 2:
                        NPC.lifeMax = 1000;
                        NPC.life = 1000;
                        NPC.damage = 35;
                        NPC.defense = 5;
                        NPC.value = Item.buyPrice(gold: 1);
                        Segments = 6;
                        break;
                    
                    case 3:
                        NPC.lifeMax = 2000;
                        NPC.life = 2000;
                        NPC.damage = 50;
                        NPC.defense = 10;
                        NPC.value = Item.buyPrice(gold: 2);
                        Segments = 7;
                        break;
                }

                ChangePhaseRand();
                //SEGMENTS INCLUDE THE HEAD
                for (int i = 1; Segments > i; i++)
                {
                    NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X, (int)NPC.position.Y, Type, ai0: NPC.ai[0], ai2: NPC.whoAmI, ai3: i);
                }
            }
            else
            {
                // BODY
                switch (tier)
                {
                    case 1:
                        NPC.lifeMax = 125;
                        NPC.life = 125;
                        NPC.defense = 0;
                        NPC.damage = 15;
                        NPC.value = Item.buyPrice(silver: 10);
                        break;

                    case 2:
                        NPC.lifeMax = 300;
                        NPC.life = 1000;
                        NPC.damage = 20;
                        NPC.defense = 5;
                        NPC.value = Item.buyPrice(silver: 25);
                        break;

                    case 3:
                        NPC.lifeMax = 750;
                        NPC.life = 750;
                        NPC.damage = 30;
                        NPC.defense = 10;
                        NPC.value = Item.buyPrice( silver: 50);
                        break;
                }
            }
            AdjustToDifficulty();
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
            if (item is not null)
                Item.NewItem(NPC.GetSource_DropAsItem(), NPC.Center, new Item(item.type));

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
        const float LerpSpeed = 140f;
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
                NPC.FaceTarget();
                NPC.spriteDirection = -NPC.direction;

                switch (NPC.ai[1])
                {
                    // Looping
                    case 1:
                        Vector2 Loop = GetLoop(-NPC.ai[0], ISHOWSPEED, LeSize);
                        Vector2 ToLErp = (target.Center + Loop - NPC.Size / 2);
                        NPC.velocity = Vector2.Zero;
                        NPC.position += (ToLErp - NPC.position) / LerpSpeed;

                        if (NPC.Center.Distance(target.Center) <= 200)
                            NPC.frameCounter = 0;
                        else
                            NPC.frameCounter = 1;

                        break;


                    // Charging
                    case 2:

                        if (NPC.ai[0] % 70 == 0)
                        {
                            DashTarget = NPC.DirectionTo(target.position).RotatedByRandom(0.2f);
                            NPC.velocity = DashTarget * 30;
                        }

                        if (NPC.ai[0] % 70 < 30)
                            NPC.frameCounter = 0;
                        else
                            NPC.frameCounter = 1;

                        NPC.velocity += (Vector2.Zero - NPC.velocity) / 30;

                    break;

                    // BouncyBallz
                    case 3:

                        NPC.frameCounter = 2;
                        if (NPC.collideY)
                        {
                            NPC.velocity = (Vector2.UnitY * -Main.rand.Next(10, 16)).RotatedByRandom(0.3f);
                            SoundEngine.PlaySound(Eclipse.BOING, NPC.Center);
                        }

                    break;

                    // Spawn Slimes
                    case 4:

                        if (NPC.ai[0] >= 60)
                        {
                            NPC.frameCounter = 1;

                            if (NPC.ai[0] == 60)
                            {
                                NPC.frameCounter = 0;

                                for (int i = 0; 2 + tier > i; i++)
                                {
                                    int[] slimes = { NPCID.BlueSlime, NPCID.GreenSlime, NPCID.PurpleSlime, NPCID.SlimeSpiked };
                                    int spawn = slimes[Main.rand.Next(slimes.Length)];

                                    if (Main.rand.NextBool(50))
                                        spawn = NPCID.Pinky;

                                    if (Main.rand.NextBool(512))
                                        spawn = NPCID.GoldenSlime;

                               

                                    Vector2 SpawnPos = Main.player[NPC.target].Center + new Vector2(Main.rand.Next(-500, 500), Main.rand.Next(-1200, -900));
                                    NPC.NewNPC(NPC.GetBossSpawnSource(target.whoAmI), (int)SpawnPos.X, (int)SpawnPos.Y, spawn);
                                }
                                SoundEngine.PlaySound(SoundID.DD2_BetsyScream, NPC.Center);

                            }
                        }
                            NPC.velocity += (Vector2.Zero - NPC.velocity) / 30;
                        break;
                }

                if (NPC.ai[0] > 0)
                    NPC.ai[0]--;
                else
                    ChangePhaseRand();

            }
            else
            {
                //BODY

                NPC TheHead = Main.npc[(int)NPC.ai[2]];
                NPC.ai[0] = TheHead.ai[0];
                NPC.ai[1] = TheHead.ai[1];

                if (NPC.ai[3] > 1)
                {
                    NPC? FollowingSegment = GetSegment((int)NPC.ai[2], (int)NPC.ai[3] - 1);
                    if (FollowingSegment == null)
                    {
                        NPC.ai[3] -= 1;
                    }
                    else
                    {
                        if (!FollowingSegment.active)
                        {
                            NPC.ai[3] -= 1;
                            Main.npc[FollowingSegment.whoAmI].type = -1;
                        }
                    }
                }

                Player target;
                if (TheHead.active)
                {
                    target = Main.player[TheHead.target];
                }
                else
                {
                    NPC.active = false;
                    return;
                }

                switch (NPC.ai[1])
                {
                    default:
                        NPC.noGravity = true;
                        NPC.noTileCollide = true;
                    break;

                    case 3:
                        if (NPC.noGravity && NPC.noTileCollide)
                        {
                            NPC.noGravity = false;
                            NPC.noTileCollide = false;
                            NPC.velocity = -Vector2.UnitY.RotatedByRandom(MathHelper.PiOver2) * 8;
                        }
                        break;

                }
                switch (NPC.ai[1])
                {
                    // Looping
                    case 1:
                        Vector2 Loop = GetLoop(-NPC.ai[0] - NPC.ai[3] * 8, ISHOWSPEED, LeSize);
                        Vector2 ToLErp = (target.Center + Loop - NPC.Size / 2);

                        NPC.velocity = Vector2.Zero;
                        NPC.position += (ToLErp - NPC.position) / LerpSpeed;
                    break;

                    // Charging and Spawn Slimes
                    case 2:
                    case 4:

                        int locallerpspeed = NPC.ai[1] == 2 ? 10 : 70;

                        if ((int)NPC.ai[3] - 1 != 0)
                        {
                            NPC FollowingSegment = GetSegment((int)NPC.ai[2], (int)NPC.ai[3] - 1);
                            NPC.position += (FollowingSegment.position - NPC.position) / locallerpspeed;
                        }
                        else
                            NPC.position += (TheHead.position - NPC.position) / locallerpspeed;

                    break;

                    // BouncyBallz
                    case 3:

                        if (NPC.collideY)
                        {
                            NPC.velocity = (Vector2.UnitY * -Main.rand.Next(10, 16)).RotatedByRandom(0.3f);
                            SoundEngine.PlaySound(Eclipse.BOING, NPC.Center);
                            /*if (NPC.ai[0] < 70)
                                NPC.velocity = (new Vector2(-Vector2.Normalize(TheHead.position - NPC.position).X, 1) * -Main.rand.Next(10, 16)).RotatedByRandom(0.3f);
                            else
                                NPC.velocity = (Vector2.UnitY * -Main.rand.Next(10, 16)).RotatedByRandom(0.3f);*/
                        }

                        if (NPC.ai[0] < 60)
                        {
                            NPC.noTileCollide = true;
                            NPC.noGravity = true;
                            Vector2 ResetPos = TheHead.position - (TheHead.DirectionTo(target.position) * 20 * NPC.ai[3]);
                            NPC.velocity = Vector2.Zero;
                            NPC.position += (ResetPos - NPC.position) / 20;
                        }
                    break;
                }
                
            }
        }
    }
}
