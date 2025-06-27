

using Eclipse.Common;
using Eclipse.Content.Dusts;
using Humanizer;
using System.Threading;

using Terraria.Audio;
using Terraria;

namespace Eclipse.Content.Buffs
{
    public class Stoned : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;


        }




        int timer = 0;
        int smoke = 0;



        public override void Update(Player player, ref int buffIndex)
        {
            if (player.GetModPlayer<LungCancerPlayer>().stonedintensity >= 1200)
            {
                player.GetModPlayer<LungCancerPlayer>().lifeRegenDebuff = true;
                smoke -= 1;
                timer++;

                if (smoke > 0)
                {
                    for (int i = 0; 10 > i; i++)
                        Dust.NewDustPerfect(player.position + new Vector2(0, 20), ModContent.DustType<Smoke>(), new Vector2(Main.rand.NextFloat(5, 7) * player.direction, Main.rand.NextFloat(0, 2)), Alpha: (int)180);

                }






                if (Main.rand.NextBool(80 - player.GetModPlayer<LungCancerPlayer>().stonedintensity / 200) && timer > 30)
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
               



            player.GetModPlayer<EclipseModPlayer>().ManaCooldown = 5 + player.GetModPlayer<LungCancerPlayer>().stonedintensity / 40;
            player.manaRegenBonus += 1 + player.GetModPlayer<LungCancerPlayer>().stonedintensity / 40;
       
        }
    }
    public class LungCancerPlayer : ModPlayer
    {
        public int stonedintensity = 0;
        public bool lifeRegenDebuff;

        public override void ResetEffects()
        {
            lifeRegenDebuff = false;
        }

        public override void UpdateBadLifeRegen()
        {
            if (lifeRegenDebuff)
            {
                stonedintensity -= 1;
                Player.lifeRegen = 0;

                Player.lifeRegenTime = 0;

                if (stonedintensity >= 1200)
                Player.lifeRegen -= (stonedintensity - 1200) / 70 ;

            }
        }

    }
}
