namespace Eclipse.Content.Items.Armor.Chitin;

[AutoloadEquip(EquipType.Body)]
public class ChitinChestpeice : ModItem
{
    public override void SetDefaults() {
        Item.width = 30;
        Item.height = 20;

        Item.defense = 4;

        Item.rare = ItemRarityID.Green;
        Item.value = Item.sellPrice(silver: 1);
    }

  
}
