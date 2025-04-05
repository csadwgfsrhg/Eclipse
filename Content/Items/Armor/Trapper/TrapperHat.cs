namespace Eclipse.Content.Items.Armor.Trapper;

[AutoloadEquip(EquipType.Head)]
public class TrapperHat : ModItem
{
    public override void SetStaticDefaults() {
        ArmorIDs.Head.Sets.IsTallHat[Item.headSlot] = true;
    }

    public override void SetDefaults() {
        Item.width = 26;
        Item.height = 28;

        Item.defense = 1;

        Item.rare = ItemRarityID.Blue;
        Item.value = Item.sellPrice(silver: 1);
    }

   
}
