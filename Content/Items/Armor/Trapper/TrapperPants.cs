namespace Eclipse.Content.Items.Armor.Trapper;

[AutoloadEquip(EquipType.Legs)]
public class TrapperPants : ModItem
{
   

    public override void SetDefaults() {
        Item.width = 20;
        Item.height = 14;

        Item.defense = 2;

        Item.rare = ItemRarityID.Blue;
        Item.value = Item.sellPrice(silver: 1);
    }

 
}
