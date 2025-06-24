

using Eclipse.Content.Dusts;
using Terraria.Audio;

namespace Eclipse.Content.Buffs
{

    public class LungCancer : ModBuff
    {

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = false;

        }


        int timer = 0;
        int smoke = 0;
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<LungCancerPlayer>().lifeRegenDebuff = true;
            smoke -= 1;
            timer++;

            if ( smoke > 0 )
            {
                for (int i = 0; 10 > i; i++)
                    Dust.NewDustPerfect(player.position + new Vector2(0, 20), ModContent.DustType<Smoke>(), new Vector2(Main.rand.NextFloat(5, 7) * player.direction, Main.rand.NextFloat(0, 2)), Alpha: (int)180);

            }
          
          
         



            if (Main.rand.NextBool(80) && timer > 30)
            {
                smoke = 10;
                    timer = 0;
                SoundEngine.PlaySound(new SoundStyle($"{nameof(Eclipse)}/Sounds/Cough")
                {

                    Volume = .5f,
                    PitchVariance = 0.6f,
                    MaxInstances = 3,
                });
            }
        }





        public class LungCancerPlayer : ModPlayer
        {

            public bool lifeRegenDebuff;

            public override void ResetEffects()
            {
                lifeRegenDebuff = false;
            }

            public override void UpdateBadLifeRegen()
            {
                if (lifeRegenDebuff)
                {

                    Player.lifeRegen = 0;

                    Player.lifeRegenTime = 0;

                    Player.lifeRegen -= 30;
                }
            }

        }
    }
}