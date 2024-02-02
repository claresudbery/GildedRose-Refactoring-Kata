using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("fixme", Items[0].Name);
        }
    }
}

/*
 NB: The final state of the code is commented out at the bottom of GildedRoseTest.cs. 
    Also the final state of this code is the starting state of the csharp-mutation-start branch.
INTRO
    Explain Gilded Rose
        Show the UpdateQuality method
    Explain that I'm starting from where you always start if you clone this repo
        [Java](https://github.com/emilybache/GildedRose-Refactoring-Kata/blob/main/Java/src/test/java/com/gildedrose/GildedRoseTest.java)
        [Python]([text](https://github.com/emilybache/GildedRose-Refactoring-Kata/blob/main/python/test_gilded_rose.py))
    Explain that there is currently no test coverage
        - We want to add tests before refactoring
        - This LH is ONLY about adding tests
    Add or remove x to/from each line below as I cover it, so I can see where I'm up to
        (Each time I come in here I'm either adding x or removing x, depending what I did last time)
STEP 1 - get test passing
    See it fail first, by running it
    Rename it: Replace foo() with UpdateQuality() 
        (just copy UpdateQuality into test name and apply rename refactoring)
    Change fixme to foo
    Run ALL tests and see it pass
STEP 2 - get approvals working
    Replace this...
            Assert.Equal("foo", Items[0].Name);
    ...with this:
            Approvals.Verify(Items[0].Name);
    Alt Enter: Import missing references            
        (will add this: using ApprovalTests;)
    Run all tests. It will fail and error will tell you to add this to class:
        [UseReporter(typeof(DiffReporter))]
    Alt Enter: Import missing references    
        (will add this: using ApprovalTests.Reporters;)
    Run all tests: Should bring up diff reporter
        Might disappear straight after - use Cmd + ` to bring it back
    SHOW NEW FILE: gildedRoseTest.UpdaeQuality.approved.txt
        Also click the eye icon, top left, to show the associated received.txt
    Implement Item.ToString and call it in test instead of Name
        Approvals.Verify(Items[0].ToString());
        alt + cmd + / to uncomment code in Rider
    Run all tests - will bring up diff reporter again
    Point out we're comparing received.txt with approved.txt
    click >> to accept new content
    Run all tests again - should pass
STEP 3 - get combination approvals working  
    Introduce `itemString` var for `Items[0].ToString()`
        Highlight `Items[0].ToString()`, then Cmd + Shift + R => Introduce variable            
        Will result in this:
            string itemString = Items[0].ToString();
            Approvals.Verify(itemString);
    Run all tests
    Do same with `item` var for `new Item { Name = "foo", SellIn = 0, Quality = 0 }`            
        Will result in this:            
            var item = new Item { Name = "foo", SellIn = 0, Quality = 0 };
    Do same for hard-coded Name, SellIn and Quality
        Highlight the literal value in each case (eg `"foo"`)
        For literals of `0`, choose "Replace one occurrence"
        Will result in this:   
            var name = "foo";
            var sellIn = 0;
            var quality = 0;
            var item = new Item { Name = name, SellIn = sellIn, Quality = quality };
    Extract `DoUpdateQuality` method (Cmd + R + M)
        These are the 5 lines to isolate and highlight to extract into method:
            var item = new Item { Name = name, SellIn = sellIn, Quality = quality };
            IList<Item> Items = new List<Item> { item };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            string itemString = Items[0].ToString();
        Call the method DoUpdateQuality - see sample code below
        The method will return a string
        That string is then passed into `Approvals.Verify`:
            var itemString = DoUpdateQuality(name, sellIn, quality);
            Approvals.Verify(itemString); 
    Explain this means I've now created a useful method that can update quality according to passed in params
        - Show the method
        - (the reason it returns `Items[0]` is that `Items` was created in the test and only contains one item)
    Replace ALL the existing code in the `UpdateQuality` test (5 lines) with a call to VerifyAllCombinations: 
            CombinationApprovals.VerifyAllCombinations(
                DoUpdateQuality,
                new String[] { "foo" },
                // SellIn:
                new int[] { 0 },
                // Quality:
                new int[] { 0 });
    Alt Enter: Import missing references    
        (will add this: using ApprovalTests.Combinations;)
    Alt Enter: Remove unused using directives
    Run tests again - approve the new output
        Using CombinationApprovals means you get input as well as output
    Note that "foo" is useful data, because it acts as a default item name (rather than a special case)
STEP 4 - start adding meaningful test data
    Start by running the tests WITH COVERAGE
        You get several coverage results on the right
        You're interested in the GildedRose result under GildedRoseKata - ignore other numbers
        GildedRose is the GildedRose class, and if you expand you'll see the UpdateQuality method
         - this is what we care about
    Show GildedRose.cs and how you can see coverage feedback in the gutter on the left
    On each step, add the data to the call to `CombinationApprovals.VerifyAllCombinations`
    Then run the test, approve the new output and close the diff reporter
    Then run the test again WITH COVERAGE to see it pass and check coverage
STEP 5 - Finish adding data
    Note this can either be done as a demo or a collaborative ensemble exercise
        For O'Reilly bootcamp, I demoed the whole thing
        For GDS LH, I just did "foo" and then every other bit of data was added in the ensemble
    First just aged brie: ADD "Aged Brie" to list after "foo"
        NB: It's important to keep "foo" in the list! That acts as default normal item 
        Coverage should go from 40% to 45%
    Look for candidates for other bits of data to add in 
        start with all 3 names of products (79% coverage)
        then add -1 and 11 to sellin (second param) (84% coverage)
            because there are if statements for sellin `< 0` and `< 11`
        then add 1, 49 and 50 to quality (third param) (100% coverage)
            because there are if statements for quality `> 0` and `< 50`                
    So now you have 100% coverage
        Code will look like this (in public void UpdateQuality()):
            CombinationApprovals.VerifyAllCombinations(
                DoUpdateQuality,
                new String[] { "foo", "Aged Brie", "Backstage passes to a TAFKAL80ETC concert", "Sulfuras, Hand of Ragnaros" },
                // SellIn:
                new int[] { -1, 0, 11 },
                // Quality:
                new int[] { 0, 1, 49, 50 });
                
        
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
 */
