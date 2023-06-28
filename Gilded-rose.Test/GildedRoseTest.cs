using System.Collections.Generic;
using Xunit;

namespace Gilded_rose.Test
{
    public class GildedRoseTest
    {


        private Item RegularItem(int sellIn, int quality)
        {
            return new Item("foo", sellIn, quality);
        }
        
        private Item AgedBrieItem(int sellIn, int quality)
        {
            return new Item("Aged Brie", sellIn, quality);
        }
        
        private Item BackstagePassItem(int sellIn, int quality)
        {
            return new Item("Backstage passes to a TAFKAL80ETC concert", sellIn, quality);
        }
        
        private Item LegendaryItem(int sellIn, int quality)
        {
            return new Item("Sulfuras, Hand of Ragnaros", sellIn, quality);
        }
        
        [Fact]
        public void InsertedItemShouldBePresent()
        {
            IList<Item> items = new List<Item> { RegularItem( 0, 0) };
            var app = new GildedRose(items);
            
            app.UpdateQuality();
            
            Assert.Equal("foo", items[0].Name);
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void RegularItemQualityShouldDecrease()
        {
            IList<Item> items = new List<Item> { RegularItem( 10, 10) };
            var app = new GildedRose(items);
            
            app.UpdateQuality();

            Assert.Equal(9, app.Items[0].Quality);
        }

        [Fact]
        public void RegularItemQualityShouldDecreaseFastWhenSellinExpired()
        {
            IList<Item> items = new List<Item> {RegularItem(0, 10)};
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(8, app.Items[0].Quality);
        }

        [Fact]
        public void RegularItemQualityShouldntBeNegative()
        {
            IList<Item> items = new List<Item> {RegularItem(0, 0)};
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, app.Items[0].Quality);
        }
        
        
        [Fact]
        public void RegularItemSellinShouldDecrease()
        {
            IList<Item> items = new List<Item> {RegularItem(1, 10)};
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, app.Items[0].SellIn);
        }
        
        
        [Fact]
        public void RegularItemSellinShouldDecreaseNegative()
        {
            IList<Item> items = new List<Item> {RegularItem(0, 10)};
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(-1, app.Items[0].SellIn);
        }
        [Theory]
        [InlineData(10,10,9)]
        [InlineData(0,10,8)]
        [InlineData(0,0,0)]
        public void RegularItemQualityUpdatedShouldBe(int initialSellIn,int initialQuality,int expectedQuality)
        {
            IList<Item> items = new List<Item> {RegularItem(initialSellIn, initialQuality)};
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(expectedQuality, app.Items[0].Quality);
        }
       
        [Fact]
        public void AgedBrieItemQualityShouldIncrease()
        {
            IList<Item> items = new List<Item> { AgedBrieItem( 10, 10) };
            var app = new GildedRose(items);
            
            app.UpdateQuality();

            Assert.Equal(11, app.Items[0].Quality);
        }
        
        [Fact]
        public void AgedBrieItemQualityShouldNotIncreaseAfter50()
        {
            IList<Item> items = new List<Item> { AgedBrieItem( 10, 50) };
            var app = new GildedRose(items);
            
            app.UpdateQuality();

            Assert.Equal(50, app.Items[0].Quality);
        }
        
        [Fact]
        public void LegendaryItemQualityShouldNotDecrease()
        {
            IList<Item> items = new List<Item> { LegendaryItem( 10, 10) };
            var app = new GildedRose(items);
            
            app.UpdateQuality();

            Assert.Equal(10, app.Items[0].Quality);
        }
        
        [Fact]
        public void LegendaryItemSellinShouldNotDecrease()
        {
            IList<Item> items = new List<Item> { LegendaryItem( 10, 10) };
            var app = new GildedRose(items);
            
            app.UpdateQuality();

            Assert.Equal(10, app.Items[0].SellIn);
        }
        
        [Fact]
        public void BackstagePassItemQualityShouldIcrease()
        {
            IList<Item> items = new List<Item> { BackstagePassItem( 11, 48) };
            var app = new GildedRose(items);
            
            app.UpdateQuality();

            Assert.Equal(49, app.Items[0].Quality);
        }
        
        [Fact]
        public void BackstagePassItemQualityShouldIcreaseBy1WhenReaching50()
        {
            IList<Item> items = new List<Item> { BackstagePassItem( 10, 49) };
            var app = new GildedRose(items);
            
            app.UpdateQuality();

            Assert.Equal(50, app.Items[0].Quality);
        }
        
        [Fact]
        public void BackstagePassItemQualityShouldIcreaseBy2WhenReaching50()
        {
            IList<Item> items = new List<Item> { BackstagePassItem( 5, 48) };
            var app = new GildedRose(items);
            
            app.UpdateQuality();

            Assert.Equal(50, app.Items[0].Quality);
        }
        [Fact]
        public void BackstagePassItemQualityShouldIcreaseBy2()
        {
            IList<Item> items = new List<Item> { BackstagePassItem( 6, 10) };
            var app = new GildedRose(items);
            
            app.UpdateQuality();

            Assert.Equal(12, app.Items[0].Quality);
        }
        
        [Fact]
        public void BackstagePassItemQualityShouldIcreaseBy3()
        {
            IList<Item> items = new List<Item> { BackstagePassItem( 5, 10) };
            var app = new GildedRose(items);
            
            app.UpdateQuality();

            Assert.Equal(13, app.Items[0].Quality);
        }
        
        [Fact]
        public void BackstagePassItemQualityShouldToBe0()
        {
            IList<Item> items = new List<Item> { BackstagePassItem( 0, 10) };
            var app = new GildedRose(items);
            
            app.UpdateQuality();

            Assert.Equal(0, app.Items[0].Quality);
        }
    }
}