


using Eclipse.Utilities.Extensions;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;



namespace Eclipse.Common.Gun
{
    public class GlobalGun : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.Handgun || item.type == ItemID.PhoenixBlaster)
            {
               // SoundEngine.PlaySound(new SoundStyle("Eclipse.Sounds.Gunshot1.mp3"));
            }


        }




    }

}



