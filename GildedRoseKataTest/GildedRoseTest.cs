using GildedRoseKata;
using GildedRoseKataModels;
using Microsoft.SqlServer.Server;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace GildedRoseKataTest
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void conjured_items_degrade_in_Quality_twice_as_fast_as_normal_items()
        {
            var Item = new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 20 };
            IList<Item> Items = new List<Item> { Item };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(Item.Quality, 18);
        }

        [Test]
        public void item_can_never_have_its_Quality_increase_above_50()
        {
            var Item = new Item { Name = "item", SellIn = 10, Quality = 51 };
            IList<Item> Items = new List<Item> { Item };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(Item.Quality, 50);
        }

        [Test]
        public void Sulfuras_is_a_legendary_item_and_as_such_its_Quality_is_80_and_it_never_alters()
        {
            var Item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 20, Quality = 80 };
            IList<Item> Items = new List<Item> { Item };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(Item.Quality, 80);
        }

        [Test]
        public void test_lowers_values()
        {
            var Items = new List<Item> { 
                new Item { Name = "first", SellIn = 5, Quality = 5 },
                new Item { Name = "second", SellIn = 8, Quality = 8 } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(4, Items[0].SellIn);
            Assert.AreEqual(4, Items[0].Quality);

            Assert.AreEqual(7, Items[1].SellIn);
            Assert.AreEqual(7, Items[1].Quality);
        }


        [Test]
        public void non_negative_quality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "item", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }
    }
}
