using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace Gilded_rose.Test;

[UsesVerify]
public class GildedRoseApprovalTest
{
 
        private  GildedRose CreateGildedRoseSample()
        {
            return new GildedRose( new List<Item>{
                    new ("Aged Brie", 2, 0),
                    new ("Sulfuras, Hand of Ragnaros",  0,  80),
                    new ("Backstage passes to a TAFKAL80ETC concert",15,20),
                    new ("Madoran Bronzebeard Hammer", 10, 20),
                    new ("Ironforge Mountain Stone", 5, 7),
                }
            );
        }

        private string StringifyItemSnapshot(int day, Item item)
        {
            return $"Day={day}: Name={item.Name}, SellIn={item.SellIn}, Quality={item.SellIn}\n";
        }

        private string ItemsSnapshotAtDay(int day, GildedRose gildedRose)
        {
            var outputBuilder = new StringBuilder();
            for (int i = 0; i < gildedRose.Items.Count;i++)
            {
                outputBuilder.Append(StringifyItemSnapshot(day, gildedRose.Items[i]));
            }
            return outputBuilder.ToString();
        }

        [Fact]
<<<<<<< HEAD
        public Task OriginalBeahviorShouldNotChange()
=======
        public Task Test_OriginalBeahvior_ShouldNotChange()
>>>>>>> origin/master
        {
            var outpuBuilder = new StringBuilder();
            var gildedRose = CreateGildedRoseSample();
            outpuBuilder.Append(ItemsSnapshotAtDay(0, gildedRose));
            for (int day = 1; day <= 100; day++)
            {
                gildedRose.UpdateQuality();
                outpuBuilder.Append(ItemsSnapshotAtDay(day, gildedRose));
            }
            return Verifier.Verify(outpuBuilder.ToString());
        }

}