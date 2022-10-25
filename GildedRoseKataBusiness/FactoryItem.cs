using GildedRoseKataBusiness.Domains;
using GildedRoseKataModels;

namespace GildedRoseKataBusiness
{
    public class FactoryItem
    {
        // fields
        protected Item Item { get; set; }
        protected bool IsExpired => Item.SellIn < 0;

        public FactoryItem(Item Item) { this.Item = Item; }

        public static FactoryItem CreateInstance(Item Item)
        {
            if (Item.Name.Equals(AgedBird.AGED_BRIE))
            {
                return new AgedBird(Item);
            }

            if (Item.Name.Equals(BackStagePasses.BACKSTAGE_PASSES))
            {
                return new BackStagePasses(Item);
            }

            if (Item.Name.Equals(Sulfuras.SULFURAS_HAND_OF_RAGNAROS))
            {
                return new Sulfuras(Item);
            }

            if (Item.Name.Equals(Conjured.CONJURED_MANA_CAKE))
            {
                return new Conjured(Item);
            }

            // otherwise
            return new FactoryItem(Item);
        }

        // methods
        public void DailyUpdate()
        {
            UpdateQuality();

            UpdateExpiration();

            if (IsExpired) ProcessExpired();
        }

        protected virtual void ProcessExpired() => DecreaseQuality();
        protected virtual void UpdateQuality() => DecreaseQuality();

        protected virtual void UpdateExpiration() => Item.SellIn--;

        protected virtual void DecreaseQuality()
        {
            if (Item.Quality > 0)
            {
                Item.Quality = Item.Quality - 1;
            }
        }

        protected virtual void IncreaseQuality()
        {
            if (Item.Quality < 50)
            {
                Item.Quality = Item.Quality + 1;
            }
        }
    }
}