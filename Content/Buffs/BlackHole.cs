using Eclipse.Common;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace Eclipse.Content.Buffs
{

    public class BlackHole : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            Update(npc, ref buffIndex);
        }
        public override void Update(Player player, ref int buffIndex)
        {
            Update(player, ref buffIndex);
        }
        public void Update(Entity e, ref int buffIndex)
        {
            var mp = Main.LocalPlayer.GetModPlayer<EclipseModPlayer>();

            e.velocity += (mp.HolePos - e.position) / 30f;
        }
    }
}
