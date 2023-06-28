using System.Collections.Generic;
using Xunit;

namespace Gilded_rose.Test
{
    public class GildedRoseTest
    {
        [Fact]
        public void InsertedItemShouldBePresent()
        {
            IList<Item> items = new List<Item> { new Item("foo", 0, 0) };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal("foo", items[0].Name);
        }

    }
}