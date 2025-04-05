using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Graphics.Effects;

namespace Eclipse.Common
{
    public class EclipseModSystem : ModSystem
    {
        public override void PostDrawTiles()
        {
            //Filters.Scene["EclipseMod:SpaceWarp"].GetShader().UseProgress(1f).Update(Main.gameTimeCache);
        }
    }
}
