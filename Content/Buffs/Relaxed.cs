using Eclipse.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace Eclipse.Content.Buffs
{

    public class Relaxed : ModBuff
    {

        public override void Update(Player player, ref int buffIndex)
        {

  
        }

    }
    public class RelaxedCheck : GlobalBuff
    {
      
        
        public override void Update(int type, Player player, ref int buffIndex)
        {
        
                if (player.HasBuff<Relaxed>())
                {
               
                    if (Main.debuff[type] == true && type != BuffID.PotionSickness && type != ModContent.BuffType<Stoned>() && type != BuffID.ManaSickness)
                    {
                    Main.NewText("r");
                    player.DelBuff(buffIndex);
                    buffIndex--;
                }



                }
            }
        }
        }
    
