namespace Eclipse.Content.Items.Armor.Molten;

[AutoloadEquip(EquipType.Head)]
public class MoltenAlloyHelmet : ModItem
{
    public override void SetStaticDefaults()
    {
        ArmorIDs.Head.Sets.IsTallHat[Item.headSlot] = true;
    }

    public override void SetDefaults()
    {
        Item.width = 26;
        Item.height = 28;

        Item.defense = 6;

        Item.rare = ItemRarityID.Orange;
        Item.value = Item.sellPrice(silver: 1);
    }

}
