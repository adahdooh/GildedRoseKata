using GildedRoseKataModels;

namespace GildedRoseKataBusiness.Domains
{
    public class BackStagePasses : FactoryItem
    {
        public static readonly string BACKSTAGE_PASSES = "Backstage passes to a TAFKAL80ETC concert";

        public BackStagePasses(Item Item) : base(Item) { }

        protected override void UpdateQuality()
        {
            IncreaseQuality();

            if (Item.SellIn < 11)
            {
                IncreaseQuality();
            }

            if (Item.SellIn < 6)
            {
                Item.Quality = 0;
            }
        }

        protected override void ProcessExpired() => IncreaseQuality();
    }
}
