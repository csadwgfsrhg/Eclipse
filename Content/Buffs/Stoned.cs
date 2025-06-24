

namespace Eclipse.Content.Buffs
{
    public class Stoned : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.manaRegenBonus += 40;
        }
    }
}
