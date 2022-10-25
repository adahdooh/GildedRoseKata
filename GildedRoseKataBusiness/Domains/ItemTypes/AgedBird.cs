using GildedRoseKataModels;

namespace GildedRoseKataBusiness.Domains
{
    public class AgedBird : FactoryItem
    {
        public static readonly string AGED_BRIE = "Aged Brie";

        public AgedBird(Item Item) : base(Item) { }

        protected override void UpdateQuality() => IncreaseQuality();
        protected override void ProcessExpired() => IncreaseQuality();
    }
}
