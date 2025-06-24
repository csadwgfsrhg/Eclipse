using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Localization;
using Terraria.ID;

namespace Eclipse.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class PanicShield : ModItem
    {
        public override LocalizedText Tooltip => base.Tooltip;
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 30;
            Item.accessory = true;
            Item.SetShopValues(Terraria.Enums.ItemRarityColor.Green2, 50000);
        }

        public override void UpdateEquip(Player player)
        {
            player.panic = true;
            if (player.statLife == player.statLifeMax2 && !player.HasBuff(BuffID.Panic))
                player.AddBuff(BuffID.Panic, 60);
                
        }
     
    }
}
