using ReLogic.Content;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

using Eclipse.Common;
using Terraria;
using Terraria.DataStructures;

namespace Eclipse;
public class Eclipse : Mod
{
    public static Filter SpaceWarp => Filters.Scene["Eclipse:SpaceWarp"];
    public static Texture2D SpiralNoise;

    public override void Load()
    {
        if (Main.netMode != NetmodeID.Server)
        {
            On_Player.UpdateManaRegen += On_Player_UpdateManaRegen;

            /*Effect sw = ModContent.Request<Effect>("Common/Effects/SpaceWarp").Value;
            GameShaders.Misc["EclipseMod:SpaceWarp"] = new MiscShaderData(specialShader, "PassName");*/
            var SpaceWarp = Assets.Request<Effect>("Common/Effects/SpaceWarp", AssetRequestMode.ImmediateLoad);
            SpiralNoise = ModContent.Request<Texture2D>("Eclipse/Common/Effects/SpiralMap", AssetRequestMode.ImmediateLoad).Value;
            Filters.Scene["Eclipse:SpaceWarp"] = new Filter(new ScreenShaderData(SpaceWarp, "Fard").UseColor(Color.White).UseImage(SpiralNoise, 1), EffectPriority.VeryHigh);
            //Filters.Scene["Eclipse:SpaceWarp"].Load();
        }
    }

    private void On_Player_UpdateManaRegen(On_Player.orig_UpdateManaRegen orig, Player self)
    {
        if (self.statMana < 0)
        {
            self.statMana = 0;
        }
        var poo = (1 + self.manaRegen + (int)(self.manaRegenBonus / 10f) + (int)(self.statManaMax2 / 75f)) / ((int)(1+ (self.slotsMinions / self.maxMinions) *3 ));
        if (120 <= self.manaRegenCount && (self.statMana < self.statManaMax2 || poo < 0))
        {
            self.ManaEffect(poo);
            self.statMana += poo;
            self.manaRegenCount = 0;
          
    
        }
        self.manaRegenCount += 1;

    }
}
