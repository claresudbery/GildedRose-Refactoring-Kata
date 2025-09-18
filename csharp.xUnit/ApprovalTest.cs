using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace csharp
{
    [UseReporter(typeof(DiffReporter))]
    [TestFixture]
    public class ApprovalTest
    {
        [Test]
        public void UpdateQuality()
        {
            CombinationApprovals.VerifyAllCombinations(
                DoUpdateQuality,
                new String[] { "foo", "Aged Brie", "Backstage passes to a TAFKAL80ETC concert", "Sulfuras, Hand of Ragnaros" },
                new int[] { -1, 0, 2, 6, 11 },
                new int[] { 0, 1, 49, 50 });
        }

        private String DoUpdateQuality(String name, int sellin, int quality)
        {
            Item[] items = new Item[] { 
                new Item
                    {
                        Name = name, 
                        SellIn = sellin, 
                        Quality = quality
                    } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            return items[0].ToString();
        }
    }
}
