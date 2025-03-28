namespace Eclipse.Content.Items.Armor.Chitin;

[AutoloadEquip(EquipType.Legs)]
public class ChitinLeggings : ModItem
{
   

    public override void SetDefaults() {
        Item.width = 20;
        Item.height = 14;

        Item.defense = 3;

        Item.rare = ItemRarityID.Green;
        Item.value = Item.sellPrice(silver: 1);
    }

   
}
