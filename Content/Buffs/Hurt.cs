

using Eclipse.Common;
using Eclipse.Content.Dusts;
using Humanizer;
using System.Threading;

using Terraria.Audio;
using Terraria;

namespace Eclipse.Content.Buffs
{ 
    public class Hurt : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
        

        }






        bool playsound = true;
        public override void Update(NPC npc, ref int buffIndex)
        {
            if (playsound)
            {
                SoundEngine.PlaySound(npc.HitSound, npc.position);
                playsound = false;
           }

                       npc.lifeRegen -= 600;
        }


    }
}
