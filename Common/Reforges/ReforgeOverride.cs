

using Eclipse.Content.Items.Magic;
using Eclipse.Content.Items.Runes;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Utilities;

namespace Eclipse.Common.Reforges;
public class ReforgeOverride : GlobalItem
{

    public override bool? PrefixChance(Item item, int pre, UnifiedRandom rand)
    {
        return false;
    }



    public override void RightClick(Item item, Player player)
    {
        base.RightClick(item, player);
        if ((item.type == ItemID.SlimeGun
            || item.type == ItemID.SlimeStaff
            || item.type == ItemID.StickyGrenade
            || item.type == ItemID.BouncyGrenade
            || item.type == ItemID.HealingPotion
            || item.type == ItemID.SlimeHook
            || item.type == ItemID.LesserHealingPotion
            ))// && (player.HeldItem = ModContent.ItemType<MutatedGenome>()))
        {
            //      item.prefix(ModContent.PrefixType<Mutated>);
            SoundEngine.PlaySound(SoundID.Item);




        }
    }

  
}

