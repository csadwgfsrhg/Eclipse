namespace Eclipse.Content.Items.Armor.Chitin;

[AutoloadEquip(EquipType.Head)]
public class ChitinMask : ModItem
{
    public override void SetStaticDefaults() {
        ArmorIDs.Head.Sets.IsTallHat[Item.headSlot] = true;
    }

    public override void SetDefaults() {
        Item.width = 26;
        Item.height = 28;

        Item.defense = 3;

        Item.rare = ItemRarityID.Green;
        Item.value = Item.sellPrice(silver: 1);
    }

    
}
