using Eclipse.Common;
using Eclipse.Content.Buffs;
using Eclipse.Content.Projectiles.Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.Graphics.Effects;
using Terraria.ID;
using static tModPorter.ProgressUpdate;

namespace Eclipse.Content.Items.Magic
{
    public class Nadir : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[Type] = false;
        }
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
            Item.DamageType = DamageClass.Magic;
            Item.damage = 200;
            Item.crit = 30;
            Item.value = Item.buyPrice(platinum: 1);
            Item.rare = ItemRarityID.Purple;
            Item.noMelee = true;

            Item.shoot = ModContent.ProjectileType<NadirStar>();
            Item.shootSpeed = 25f;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 2;
            Item.useAnimation = 20;
            Item.reuseDelay = 5;
            Item.autoReuse = true;
            Item.mana = 20;

            Item.UseSound = SoundID.Item9;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
                return false;



            player.AddBuff(ModContent.BuffType<BlackHole>(), 300);
            Vector2 SpawnPos = new Vector2(Main.MouseWorld.X + Main.rand.Next(-210, 211), player.Center.Y + Main.rand.NextFloat(777, 1579));
            Projectile.NewProjectile(source, SpawnPos, Vector2.UnitY * -Item.shootSpeed, type, damage, knockback, ai2: Main.rand.Next(8));

            return false;
        }
        public override void HoldItem(Player player)
        {
        }
        public override void UpdateInventory(Player player)
        {
            var mp = player.GetModPlayer<EclipseModPlayer>();
            if (player.HeldItem.type != Item.type)
            {
                mp.BlahHole = 0;
                player.ClearBuff(ModContent.BuffType<BlackHole>());
            }

            if (mp.BlahHole < 1f)
                mp.BlahHole += 0.001f;

            Filters.Scene["Eclipse:SpaceWarp"].GetShader().UseProgress(mp.BlahHole).UseTargetPosition(mp.HolePos).Update(Main.gameTimeCache);
        }
        public override bool AltFunctionUse(Player player)
        {
            var mp = player.GetModPlayer<EclipseModPlayer>();

            if (!Filters.Scene["Eclipse:SpaceWarp"].Active)
            {
                mp.BlahHole = 0f;
                mp.HolePos = Main.MouseWorld;
                Filters.Scene.Activate("Eclipse:SpaceWarp");
                return true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipee = Recipe.Create(Type);
            recipee.AddIngredient(ItemID.DemonScythe);
            recipee.AddIngredient(ItemID.WaterBolt);
            recipee.AddIngredient(ItemID.BookofSkulls);
            recipee.AddIngredient(ItemID.CursedFlames);
            recipee.AddIngredient(ItemID.GoldenShower);
            recipee.AddIngredient(ItemID.CrystalStorm);
            recipee.AddIngredient(ItemID.MagnetSphere);
            recipee.AddIngredient(ItemID.RazorbladeTyphoon);
            recipee.AddIngredient(ItemID.LunarFlareBook);
            recipee.AddTile(TileID.LunarCraftingStation);
            recipee.Register();
        }
    }
}
