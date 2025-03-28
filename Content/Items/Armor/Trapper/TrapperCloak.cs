namespace Eclipse.Content.Items.Armor.Trapper;

[AutoloadEquip(EquipType.Body)]
public class TrapperCloak : ModItem
{
    public override void SetDefaults() {
        Item.width = 30;
        Item.height = 20;

        Item.defense = 2;

        Item.rare = ItemRarityID.Blue;
        Item.value = Item.sellPrice(silver: 1);
    }

   
}
