using Eclipse.Content.Items.Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using static tModPorter.ProgressUpdate;
namespace Eclipse.Content.Items.Weed

{
    public class HempFiber : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 24;

            Item.maxStack = 9999;
            //Item.value = Item.buyPrice(platinum: 2);
            Item.rare = ItemRarityID.White;
        }
        
    }
}
