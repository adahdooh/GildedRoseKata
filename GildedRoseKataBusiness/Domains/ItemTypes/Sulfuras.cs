using GildedRoseKataModels;
namespace GildedRoseKataBusiness.Domains
{
    public class Sulfuras : FactoryItem
    {
        public static readonly string SULFURAS_HAND_OF_RAGNAROS = "Sulfuras, Hand of Ragnaros";

        public Sulfuras(Item Item) : base(Item) { }

        protected override void UpdateQuality() { }

        protected override void ProcessExpired() { }

    }
}