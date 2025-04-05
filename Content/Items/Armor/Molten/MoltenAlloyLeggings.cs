namespace Eclipse.Content.Items.Armor.Molten;

[AutoloadEquip(EquipType.Legs)]
public class MoltenAlloyLeggings : ModItem
{
   

    public override void SetDefaults() {
        Item.width = 20;
        Item.height = 14;

        Item.defense = 5;

        Item.rare = ItemRarityID.Orange;
        Item.value = Item.sellPrice(silver: 1);
    }

  
}
