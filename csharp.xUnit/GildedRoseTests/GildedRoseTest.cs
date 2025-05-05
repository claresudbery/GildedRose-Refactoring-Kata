using System;
using Xunit;
using System.Collections.Generic;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using GildedRoseKata;

namespace GildedRoseTests;

[UseReporter(typeof(DiffReporter))]
public class GildedRoseTest
{
    [Fact]
    public void UpdateQuality()
    {
        CombinationApprovals.VerifyAllCombinations(
            DoUpdateQuality,
            new String[] {
                "foo",
                "Aged Brie",
                "Backstage passes to a TAFKAL80ETC concert",
                "Sulfuras, Hand of Ragnaros" },
            // SellIn:
            new int[] { -1, 0, 11 },
            // Quality:
            new int[] { 0, 1, 49, 50 });
    }

    private string DoUpdateQuality(
        string name, int sellIn, int quality)
    {
        Item item = new Item { Name = name, SellIn = sellIn, Quality = quality };
        IList<Item> Items = new List<Item> { item };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        var itemString = Items[0].ToString();
        return itemString;
    }
}

/*
 See other branch (coverage-demo-start) for instructions on how to reach this starting point.
 From here, do a demo of mutation testing:
    - YOU WANT THE TESTS TO FAIL - THIS IS GOOD - YOUR TESTS ARE WORKING
        - When they fail, do NOT accept the new approved file
        - Just revert the change, see the tests pass again, move onto the next change
    - If you have trouble with the diff tool for approval tests 
        - (sometimes it stops popping up - I think as a result of me fiddling with the approved file?)
            - I think maybe it's still there, just in the background
            - Try Cmd + ` to bring it back up
        - If you can't find diff tool: To approve new outputs, just run this on the Terminal in Rider: 
            - (Make sure you're in right subfolder: `cd GildedRoseTests`)
            - Run `mv GildedRoseTest.UpdateQuality.received.txt GildedRoseTest.UpdateQuality.approved.txt`
    - Subtract 2 instead of 1 on this line (currently line 24):
        - if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                    {
                        Items[i].Quality = Items[i].Quality - 1;
                    }
    - REVERT PREV CHANGE, then Add 2 instead of 1 on this line (currently line 32) - tests will fail again
        - if (Items[i].Quality < 50)
                {
                    Items[i].Quality = Items[i].Quality + 1;
    - REVERT PREV CHANGE, then Add 2 instead of 1 on this line (currently line 40) - THIS TIME TESTS DON'T FAIL
        - NOTE THIS LINE IS IDENTICAL TO THE LINE ABOVE
            - it's duplicated later in the code
        -  if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
        - THIS line does get executed but something happens later on to override the change
            - The problem is that we're going from 0 sellin to 11
                - We don't have any values that are less than 11 but >= 6
                - You might think that 0 and -1 are less than 11 - and they are 
                    - but line 76 means that quality gets set to 0 if sellin is less than 0
                    - which it will be if it starts at 0 or -1, because of line  57
            - TAKE AWAY THE MUTANT
            - add the value of 6 to the list of sellin values in the combination approvals data
                - because it comes up in if statement
                    - NB: WHEN I DID THIS LIVE, 6 DIDN'T WORK BUT 5 DID
                    - THIS IS BECAUSE I WAS MUTATING LINE 48 INSTEAD OF LINE 40
                    - See [explanation below](#resolving-confusing-sellin-behaviour)!
            - test fails, approve the change
            - try the mutation again (line 40)
            - this time it works
    - try the next quality (line 48)
        - change 1 to 2 again
        - is a problem again - tests don't fail
        - take away the mutant, improve the test suite
            - add 2 for sellin to create broader range
            - this time you want something that's greater than 0 but less than 6
        - test suite "kills the mutant"
        - prove it's worked by reintroducing the mutant (line 48) - tests fail
        - then taking it out again - tests pass
    - try changing all the places where it updates quality and sellin
 */