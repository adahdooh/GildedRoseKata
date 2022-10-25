using GildedRoseKataBusiness;
using GildedRoseKataModels;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var Item in Items)
            {
                FactoryItem.CreateInstance(Item).DailyUpdate();
            }
        }
    }
}