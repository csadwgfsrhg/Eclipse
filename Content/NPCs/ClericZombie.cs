
using Eclipse.Content.Projectiles.Enemy;

using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;

using Terraria.ModLoader.Utilities;

namespace Eclipse.Content.NPCs
{

    public class ClericZombie : ModNPC
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            NPC.width = 34;
            NPC.height = 86;
            NPC.damage = 20;
            NPC.defense = 6;
            NPC.lifeMax = 400;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 60f;
            NPC.knockBackResist = 0.1f;
            NPC.aiStyle = 3;




        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

        }

        //   public override float SpawnChance(NPCSpawnInfo spawnInfo)
        // {
        //     return SpawnCondition.OverworldNightMonster.Chance * 0.2f; 
        //  }
        int charge = 0;
        public override void AI()
        {

            charge += 1;
            Player player = Main.player[NPC.target];
            Visuals(player);
            if (charge >= 0)
            {
                NPC.aiStyle = 3;

            }
            else
            { NPC.aiStyle = -1;
                NPC.velocity *= .9f;
            }




            if (charge >= 200)
            {


                if (Main.rand.Next(0, 8) == 8)
                {
                    SummonZombies(player);
                    charge = -100;
                }
                else
                {
                    if (Main.rand.Next(0, 6) == 6)
                    {
                        OrbProjectile(player);
                        charge = -100;
                    }
                    else
                    {
                        Heal(player);
                        charge = 0;
                    }

                }

            }



        }
    

        private void SummonZombies(Player player)
            {

          Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<ZombiePortal>(), 5, 0, Main.myPlayer);

        }
        private void OrbProjectile(Player player)
        {



        }
        private void Heal(Player player)
        {



        }
        private void Teleport(Player player)
        {



        }



        private void Visuals(Player player)
        {


            NPC.spriteDirection = NPC.direction;
        }

    }



}