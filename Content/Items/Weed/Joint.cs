
using Terraria.Audio;
using Terraria.DataStructures;
using Eclipse.Common;
using Eclipse.Content.Buffs;
using Eclipse.Content.Dusts;
using Eclipse.Content.Tiles;

namespace Eclipse.Content.Items.Weed

{
    public class Joint : ModItem
    {
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
            Item.consumable = false;
            Item.useTime = 17;
            Item.useAnimation= 17;
            Item.reuseDelay = 20;
            //Item.holdStyle = ItemHoldStyleID.HoldLamp;
            Item.holdStyle = ItemHoldStyleID.HoldHeavy;
            Item.UseSound = SoundID.Unlock;
            Item.channel = true;
            Item.useTurn = true;

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
        public override bool? UseItem(Player player)
        {
            /*var mp = player.GetModPlayer<WeedModPlayer>();

            if (mp.WeedTime < 1f)
                mp.WeedTime += 0.15f;*/

            return true;
        }
        public override void HoldItem(Player player)
        {
            if (player.itemTime > 0 && !player.channel)
                for (int i = 0; 10 > i; i++)
                    Dust.NewDustPerfect(player.itemLocation + new Vector2(20 * player.direction, player.channel ? -12 : -4), ModContent.DustType<Smoke>(), new Vector2(player.direction * Main.rand.NextFloat(7, 10), Main.rand.NextFloat(-0.1f, 0.1f)), Alpha: (int)180);
        }
        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.itemTime > 0 || player.channel)
                player.itemAnimation = 20;
            else
            {
                player.itemAnimation = 0;
                player.AddBuff(ModContent.BuffType<Stoned>(), 1800);
                if (Main.rand.NextBool(20))
                    player.AddBuff(BuffID.Stinky, 1800);
                SoundEngine.PlaySound(new SoundStyle($"{nameof(Eclipse)}/Assets/Sounds/blowjob{Main.rand.Next(2)}")
                {
                    Volume = 0.5f,
                    PitchVariance = 0.4f,
                    MaxInstances = 2,
                });

            }

        }
        public override void HoldStyle(Player player, Rectangle heldItemFrame)
        {
            player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, -1.4f * player.direction);

            player.itemLocation.X += 8 * player.direction;
            player.itemLocation.Y += 12;
            player.itemRotation += MathHelper.ToRadians(12.5f) * player.direction;
            
        }
        public override void AddRecipes()
        {
            Recipe pee = Recipe.Create(Type, 1);
            pee.AddIngredient(ModContent.ItemType<Marijauna>(), 7);
            pee.AddIngredient(ModContent.ItemType<RollingPaper>(), 1);
            pee.Register();

        }
    }

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
