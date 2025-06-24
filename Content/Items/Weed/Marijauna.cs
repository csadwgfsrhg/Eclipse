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
    public class Marijauna : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 18;

            Item.maxStack = 1;
            //Item.value = Item.buyPrice(platinum: 2);
            Item.rare = ItemRarityID.Green;
        }
    }
}
