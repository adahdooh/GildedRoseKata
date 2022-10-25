using GildedRoseKataModels;

namespace GildedRoseKataBusiness.Domains
{
    public class Conjured : FactoryItem
    {
        public static readonly string CONJURED_MANA_CAKE = "Conjured Mana Cake";

        public Conjured(Item Item) : base(Item) { }

        protected override void DecreaseQuality()
        {
            Item.Quality = System.Math.Max(0, Item.Quality - 2);
        }
    }
}
