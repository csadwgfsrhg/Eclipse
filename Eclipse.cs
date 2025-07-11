using ReLogic.Content;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

using Eclipse.Common;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Audio;
using Eclipse.Content.Buffs;

namespace Eclipse;
public class Eclipse : Mod
{

    public static Asset<Texture2D> JointGlow;
    public static bool StonedDebuff;

        private void TextureOverride()
    {
        //npcs
    //    TextureAssets.Npc[NPCID.DungeonGuardian] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/NPCs/DungeonGuardian");


        //tiles
        TextureAssets.Tile[TileID.Ash] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Tiles/Ash");
        TextureAssets.Tile[TileID.AshGrass] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Tiles/AshGrass");
        TextureAssets.Tile[TileID.Hellstone] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Tiles/Hellstone");
        TextureAssets.Tile[TileID.ClayPot] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Tiles/ClayPot");
        //  TextureAssets.Tile[TileID.Stone] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Tiles/Stone");
        //  TextureAssets.Tile[TileID.ActiveStoneBlock] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Tiles/Stone");
        //   TextureAssets.Tile[TileID.Dirt] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Tiles/Dirt");
        //   TextureAssets.Tile[TileID.ClayBlock] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Tiles/Clay");
        //   TextureAssets.Tile[TileID.Grass] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Tiles/ForestGrass");
        //   TextureAssets.Tile[TileID.Mud] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Tiles/Mud");
        TextureAssets.Tile[TileID.Heart] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Tiles/LifeCrystal");
        TextureAssets.Tile[TileID.LifeCrystalBoulder] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Tiles/LifeCrystal");
     //   TextureAssets.Tile[TileID.Lead] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Tiles/Lead");
     //   TextureAssets.Tile[TileID.Iron] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Tiles/Iron");


        //liquds
     //   TextureAssets.Liquid[LiquidID.Lava] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Tiles/Lava");

        //weapons
        TextureAssets.Item[ItemID.IceBlade] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Items/Weapons/Melee/IceBlade");
        TextureAssets.Item[ItemID.Starfury] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Items/Weapons/Melee/Starfury");
        TextureAssets.Item[ItemID.EnchantedSword] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Items/Weapons/EnchantedWeapons/EnchantedSword");
        TextureAssets.Item[ItemID.ClayPot] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Tiles/ClayPot");


        //consumables
        TextureAssets.Item[ItemID.LifeCrystal] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Items/Consumables/LifeCrystal");
        //TextureAssets.Item[ItemID.Bottle] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Items/Consumables/Bottle");
      //  TextureAssets.Item[ItemID.BottledWater] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Items/Consumables/BottledWater");
      //  TextureAssets.Item[ItemID.BottledHoney] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Items/Consumables/BottledHoney");

        //accessories
      //  TextureAssets.Item[ItemID.CloudinaBottle] = ModContent.Request<Texture2D>("Eclipse/Common/Textures/Items/Accessories/CloudInABottle");
    }




    public override void PostSetupContent()
    {
        TextureOverride();
    }

    
    public static Filter SpaceWarp => Filters.Scene["Eclipse:SpaceWarp"];
    public static Filter PixelPerfect => Filters.Scene["Eclipse:PixelPerfect"];
    public static Asset<Effect> JigglePhysics;
    public static Texture2D SpiralNoise;
    public static Texture2D THENOISEPIZZATOWER;
    public static SoundStyle BOING;

    public override void Load()
    {
   
        if (Main.netMode != NetmodeID.Server)
        {

            JointGlow = ModContent.Request<Texture2D>("Eclipse/Content/Items/Weed/JointLit");
            On_Player.UpdateManaRegen += On_Player_UpdateManaRegen;

            /*Effect sw = ModContent.Request<Effect>("Common/Effects/SpaceWarp").Value;
            GameShaders.Misc["EclipseMod:SpaceWarp"] = new MiscShaderData(specialShader, "PassName");*/
            var SpaceWarp = Assets.Request<Effect>("Common/Effects/SpaceWarp", AssetRequestMode.ImmediateLoad);
            SpiralNoise = ModContent.Request<Texture2D>("Eclipse/Common/Effects/4SpiralMap", AssetRequestMode.ImmediateLoad).Value;
            Filters.Scene["Eclipse:SpaceWarp"] = new Filter(new ScreenShaderData(SpaceWarp, "Fard").UseImage(SpiralNoise, 1), EffectPriority.High);
            
            var PixelPerfect = Assets.Request<Effect>("Common/Effects/PixelPerfect", AssetRequestMode.ImmediateLoad);
            Filters.Scene["Eclipse:PixelPerfect"] = new Filter(new ScreenShaderData(PixelPerfect, "Fard").UseImage(SpiralNoise, 1), EffectPriority.VeryHigh);
            
            
            JigglePhysics = ModContent.Request<Effect>("Eclipse/Common/Effects/JigglePhysics", AssetRequestMode.AsyncLoad);
            THENOISEPIZZATOWER = ModContent.Request<Texture2D>("Eclipse/Common/Effects/THENOISEPIZZATOWER", AssetRequestMode.ImmediateLoad).Value;
         //   Filters.Scene["Eclipse:SpaceWarp"].Load();

            BOING = new SoundStyle($"{nameof(Eclipse)}/Sounds/BOING") { Volume = 1f, PitchVariance = 0.5f };
        }
    }
   
    private void On_Player_UpdateManaRegen(On_Player.orig_UpdateManaRegen orig, Player self)
    {

        int ManaCooldown = self.GetModPlayer<EclipseModPlayer>().ManaCooldown;
        if (self.statMana < 0)
        {
            self.statMana = 0;
        }
        var poo =  (  1+ self.manaRegen + (int)(self.manaRegenBonus / 10f) + (int)(self.statManaMax2 / 75f)) / ((int)(1+ (self.slotsMinions / self.maxMinions) *3 ));
        if (120 - ManaCooldown <= self.manaRegenCount && (self.statMana < self.statManaMax2 || poo < 0))
        {
            self.ManaEffect(poo);
            self.statMana += poo;
            self.manaRegenCount = 0;
          
    
        }
        self.manaRegenCount += 1;

    }
}
