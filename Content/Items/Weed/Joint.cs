
using Terraria.Audio;
using Terraria.DataStructures;
using Eclipse.Common;
using Eclipse.Content.Buffs;
using Eclipse.Content.Dusts;
using Eclipse.Content.Tiles;
using System.Collections.Generic;

namespace Eclipse.Content.Items.Weed

{
    public class Joint : ModItem
    {
      
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(ModContent.ItemType<Paper>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Marijauna>(), 2);
          
            recipe.Register();

        }
        int channeltime = 0;
        public override void SetStaticDefaults()
        {
            //Main.RegisterItemAnimation(Type, new DrawAnimationVertical(60, 2));
            //ItemID.Sets.IsFood[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 12;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.consumable = true;
            Item.useTime = 17;
            Item.useAnimation= 17;
            Item.reuseDelay = 20;
            //Item.holdStyle = ItemHoldStyleID.HoldLamp;
            Item.holdStyle = ItemHoldStyleID.HoldHeavy;
            Item.UseSound = SoundID.Unlock;
            Item.channel = true;
            Item.useTurn = true;
            Item.maxStack = 999;
            //Item.value = Item.buyPrice(platinum: 2);
            Item.rare = ItemRarityID.Green;
        }
        
        public override void UseAnimation(Player player)
        {
            /*Main.spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, *//*Eclipse.JigglePhysics.Value*//*null, Main.GameViewMatrix.TransformationMatrix);
            Main.spriteBatch.Draw(WEEDMOD.JointGlow.Value, Main.MouseScreen, null, Color.White, player.itemRotation, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            Main.spriteBatch.End();*/
            //spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone, null, Main.GameViewMatrix.TransformationMatrix);
            base.UseAnimation(player);
        }
        public override bool CanUseItem(Player player)
        {
            if (player.HasBuff(ModContent.BuffType<Stoned>()))
                return false;
            else
            return true;
        }
        public override bool? UseItem(Player player)
        {
          
     
            /*var mp = player.GetModPlayer<WeedModPlayer>();

            if (mp.WeedTime < 1f)
                mp.WeedTime += 0.15f;*/

            return true;
        }
        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {

            if (player.itemTime > 0 || player.channel)
            {

                player.itemAnimation = 20;
            }

            else
            {

                player.itemAnimation = 0;
                if (channeltime > 0)
                {
               
                    if (Main.rand.NextBool(20))
                        player.AddBuff(BuffID.Stinky, channeltime * 10);
                }


                SoundEngine.PlaySound(new SoundStyle($"{nameof(Eclipse)}/Sounds/blowjob{Main.rand.Next(2)}")
                {
                    Volume = 0.5f,
                    PitchVariance = 0.4f,
                    MaxInstances = 2,
                });

            }

        }
        int timer = 0;
        public override void HoldItem(Player player)
        {
          
            if (player.channel)
            {
                channeltime++;
                player.AddBuff(ModContent.BuffType<Stoned>(), channeltime * 10);

            }
              
            if (channeltime >= 140 )
            {
                player.AddBuff(ModContent.BuffType<LungCancer>(), (channeltime - 140) * 4);
              
            
            }
              


            
            if (player.itemTime > 0 && !player.channel)
            {
                channeltime = 0;
                for (int i = 0; 5 > i; i++)
                    Dust.NewDustPerfect(player.itemLocation + new Vector2(20 * player.direction, player.channel ? -12 : -4), ModContent.DustType<Smoke>(), new Vector2(player.direction * Main.rand.NextFloat(7, 10), Main.rand.NextFloat(-0.1f, 0.1f)), Alpha: (int)180);
            }
        }
              
        public override void HoldStyle(Player player, Rectangle heldItemFrame)
        {
            player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, -1.4f * player.direction);

            player.itemLocation.X += 8 * player.direction;
            player.itemLocation.Y += 12;
            player.itemRotation += MathHelper.ToRadians(12.5f) * player.direction;
            
        }
       
    }
   // public override void ModifyTooltips(List<TooltipLine> tooltips)
  //  {

        //  TooltipLine tooltip = new TooltipLine(Mod, " Potency: ", $" Potency: {Potency} / 100 ");
        // tooltips.Add(tooltip);
        // TooltipLine tooltip2 = new TooltipLine(Mod, " Useage: ", $" Quality: {Useage} / Useage ");
        //tooltips.Add(tooltip2);

    //}

    public class JointDrawLayer : PlayerDrawLayer
    {
        public override bool IsHeadLayer => true;
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo) => drawInfo.drawPlayer.HeldItem?.type == ModContent.ItemType<Joint>() && drawInfo.drawPlayer.GetModPlayer<WeedModPlayer>().WeedTime > 0f;
        public override Position GetDefaultPosition() => new BeforeParent(PlayerDrawLayers.ArmOverItem);

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            //var tex = TextureAssets.Item[ModContent.ItemType<Joint>()];
            var mp = drawInfo.drawPlayer.GetModPlayer<WeedModPlayer>();
            var tex = Eclipse.JointGlow.Value;

            Vector2 poos = drawInfo.drawPlayer.itemLocation - Main.screenPosition;
            if (drawInfo.drawPlayer.direction == -1)
                poos.X -= 26;
            poos.Y -= 12;
            Vector2 offset = drawInfo.drawPlayer.MountedCenter - Main.screenPosition;
            var fx = (drawInfo.drawPlayer.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
            poos = new Vector2((int)poos.X, (int)poos.Y);

            drawInfo.DrawDataCache.Add(new DrawData(
                tex, // The texture to render.
                poos, // Position to render at.
                null, // Source rectangle.
                Color.White * mp.WeedTime, // Color.
                0f, // Rotation.
                Vector2.Zero, // Origin. Uses the texture's center.
                1f, // Scale.
                fx, // SpriteEffects.
                1 // 'Layer'. This is always 0 in Terraria.
            ));

        }
    }

}
