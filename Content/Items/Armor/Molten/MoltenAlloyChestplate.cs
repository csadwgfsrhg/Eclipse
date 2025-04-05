namespace Eclipse.Content.Items.Armor.Molten;

[AutoloadEquip(EquipType.Body)]
public class MoltenAlloyChestplate : ModItem
{
    public override void SetDefaults() {
        Item.width = 30;
        Item.height = 20;

        Item.defense = 7;

        Item.rare = ItemRarityID.Orange;
        Item.value = Item.sellPrice(silver: 1);
    }

  
}
