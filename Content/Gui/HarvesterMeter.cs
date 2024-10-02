using Terraria.DataStructures;

namespace Eclipse.Content.Gui;

public class HarvestVar : ModPlayer
{
    public int Cropgrowth = 100;
    public int Hunger;

    public int HungerMax = 50;


    public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright) {
        if (Hunger > HungerMax) {
            Hunger = HungerMax;
        }
        //draw meter under player when harvesting weapon is held
    }
}

public class HarvestDamage : DamageClass
{
    public override bool UseStandardCritCalcs => true;

    public override void SetStaticDefaults() { }

    public override StatInheritanceData GetModifierInheritance(DamageClass damageClass) {
        if (damageClass == Generic) {
            return StatInheritanceData.Full;
        }

        return StatInheritanceData.None;
    }

    public override bool GetEffectInheritance(DamageClass damageClass) {
        return false;
    }

    public override void SetDefaultStats(Player player) { }
}
