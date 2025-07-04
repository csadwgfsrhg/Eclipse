

//using Eclipse.Content.Projectiles.Harvester.Hunger;
using Terraria.DataStructures;
using Eclipse.Content.NPCs.Spells;

namespace Eclipse.Content.Items.Harvester.Hunger
{
    public class StrawDoll : ModItem

    {
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;
            Item.rare = 1;
          //  Item.damage = 0;
            //   Item.shoot = ModContent.ProjectileType<StrawDollProj>();
            Item.shootSpeed = 6f;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.mana = 40;
            Item.useStyle = 4;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            
        }
        public override bool CanUseItem(Player player)
        {
            foreach (var npc in Main.ActiveNPCs)
            {
                if (npc.type == ModContent.NPCType<StrawDollNpc>())
                {

                    return false;
                }
                
            }
            return true;

        }
        public override bool? UseItem(Player player)
        {
          
            NPC minionNPC = NPC.NewNPCDirect(Item.GetSource_FromThis(), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<StrawDollNpc>(), player.whoAmI);
       
            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.AddIngredient(ItemID.Hay, 12);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }


      

    }
}


   