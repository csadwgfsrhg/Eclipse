
using Eclipse.Common.Items;

namespace Eclipse.Content.Items.Harvester.Scythes
{
    public class BloodCrawlerLeg : ScytheAI
    {
        public override void SetStaticDefaults()
        {
            Item.width = 50;
            Item.damage = 12;
            Item.height = 44;
            Item.rare = 2;
            Item.shoot = ModContent.ProjectileType<BloodCrawlerLegProj>();
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.autoReuse = true;
        }



    }
    public class BloodCrawlerLegProj : ScytheProj
    {
        public override string Texture => "Eclipse/Content/Items/Harvester/Scythes/BloodCrawlerLeg";
        public override void SetStaticDefaults()
        {
           
            Projectile.width = 50;
            Projectile.height = 44;
            Projectile.timeLeft = 15;


        }
       

    }
}