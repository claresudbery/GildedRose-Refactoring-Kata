# Gilded Rose Refactoring Kata

## Clare's Intro

This is a fork from [Emily Bache's original repo](https://github.com/emilybache/GildedRose-Refactoring-Kata) - created so I can issue some PRs.

Note that I also have an entirely separate repo - [gilded-rose-kata](https://github.com/claresudbery/gilded-rose-kata) - which is a *copy* of the original. I created this so that I could do some actual refactoring, but to be honest I'm now thinking I could also have done that in the fork. Maybe I'll sort that out at some point.

Note that I also added a section to my [clare-wiki](https://clare-wiki.herokuapp.com/pages/think/code-princ/Refactoring#approval-testing) which has a few more notes on getting started with approval testing.

## A note on keeping this repo up to date with Emily's source

I've deliberately kept my `main` branch clean. It only contains Emily's source code. Any additional code is [in branches](#a-note-on-branches). That way I can sync my main branch with Emily's and then merge it into my own branches, so that I can keep my fork up to date. If there are any conflicts with any of my branches, I can resolve them at my leisure and prioritise only the branches I'm actively using.

## A note on branches

Note that I have [another version of this repo](https://github.com/claresudbery/gilded-rose-kata), not a fork, which has its own readme. 
  - It's mostly deprecated now - you probably want to ignore it.
  - BUT it is worth noting that my sample refactored code - using polymorphism - was originally coded in the other version of this repo, and although I have copied the code over to the [`sample-polymorphic-refactor` branch](https://github.com/claresudbery/GildedRose-Refactoring-Kata/tree/sample-polymorphic-refactor) in *this* one, the original commits are all in the [older repo](https://github.com/claresudbery/gilded-rose-kata). 

At the time of writing, the following branches exist in this repo:

- Branches designed to be merged with new branches:
  - [`clare-fork-readme`](https://github.com/claresudbery/GildedRose-Refactoring-Kata/tree/clare-fork-readme)
    - Created purely to contain this forked version of the main readme 
    - Designed to be merged into any new branches
  - [`csharp-approval-fixes`](https://github.com/claresudbery/GildedRose-Refactoring-Kata/tree/csharp-approval-fixes)
    - Created to house changes I needed to make to get approval tests working in C# code
      - Note that they should now be working for both the `csharp` and `csharpcore` versions of the code
    - A [PR has been issued](https://github.com/emilybache/GildedRose-Refactoring-Kata/pull/402) to get this merged into Emily's source
  - [`requirements-edit`](https://github.com/claresudbery/GildedRose-Refactoring-Kata/tree/requirements-edit)
    - Edited version of the Gilded Rose requirements
    - A [PR has been issued](https://github.com/emilybache/GildedRose-Refactoring-Kata/pull/403) to get this merged into Emily's source
- Branches created for workshops and demos:
  - [`csharp-liftup-start`](https://github.com/claresudbery/GildedRose-Refactoring-Kata/tree/csharp-liftup-start)
    - Starting point for participants in a "lift up conditional" workshop
    - See [Emily's demo video](https://www.youtube.com/watch?v=OJmg9aMxPDI)
  - [`csharp-liftup-demo`](https://github.com/claresudbery/GildedRose-Refactoring-Kata/tree/csharp-liftup-demo)
    - Designed to contain demo commits for the lift up conditional technique 
    - Based on the `csharp-liftup-start` branch
  - [`csharp-liftup-demo-nearly-done`](https://github.com/claresudbery/GildedRose-Refactoring-Kata/tree/csharp-liftup-demo)
    - Designed for a demo of the lift up conditional technique - allows me to fast forward to when the refactor is nearly finished
    - Based on [this commit](https://github.com/claresudbery/GildedRose-Refactoring-Kata/commit/a3cda4722ad0306631d41e71e5b58e3e8f0e5833) from the `csharp-liftup-demo` branch
  - [`csharp-unit-tests`](https://github.com/claresudbery/GildedRose-Refactoring-Kata/tree/csharp-unit-tests)
    - Starting point for a refactoring based on unit tests rather than approval tests
    - Note that the original commits for this are all still in the [`csharp-test-start` branch in the older repo](https://github.com/claresudbery/gilded-rose-kata/tree/csharp-test-start)
  - [`sample-polymorphic-refactor`](https://github.com/claresudbery/GildedRose-Refactoring-Kata/tree/sample-polymorphic-refactor)
    - Demo of my polymorphic refactoring
    - Note that the original commits for this are all still in the `master` branch in [the older repo](https://github.com/claresudbery/gilded-rose-kata)
  - [`oreilly-refactoring-demo`](https://github.com/claresudbery/GildedRose-Refactoring-Kata/tree/oreilly-refactoring-demo)
    - I think I created this when I was demoing code the first time I ran the O'Reilly Refactoring Fundamentals course
  - [`oreilly-refactoring-demo-v2`](https://github.com/claresudbery/GildedRose-Refactoring-Kata/tree/oreilly-refactoring-demo-v2)
    - Looks like I created this when I was demoing code the *second* time I ran the O'Reilly Refactoring Fundamentals course
  - [`oreilly-demo1-start`](https://github.com/claresudbery/GildedRose-Refactoring-Kata/tree/oreilly-demo1-start)
    - Created as part of the O'Reilly refactoring course - see notes in clare-tech - `refactoring-demo.md`
    - This branch has a notes file with all the refactoring steps listed, at `csharpcore/GildedRose/demo-notes.txt`
  - [`if-parsing-exercise`](https://github.com/claresudbery/GildedRose-Refactoring-Kata/tree/if-parsing-exercise)
    - Created purely to play about with some equivalent boolean expressions for the sake of a little connect exercise
    - should be in a different repo really - only related to Gilded Rose because I created it for a "lift up conditional" learning hour which also used the Gilded Rose repo
  - [`coverage-demo-start`](https://github.com/claresudbery/GildedRose-Refactoring-Kata/tree/coverage-demo-start)
    - Created as part of my version of the Samman ["Using coverage to add tests to existing code" learning hour](https://www.sammancoaching.org/learning_hours/legacy/verify_xml_reports.html)
    - My notes for this are in clare-tech - code-coverage-add-tests.md
    - This branch gives a useful starting point for my code coverage demo
    - This branch has the following changes to Emily's base code:
      - The `ApprovalTests` NuGet package has been included
      - I've added demo notes at the bottom of `GildedRoseTest.cs`
      - I've added a commented-out `ToString()` method to `Item.cs`
      - I've formatted `GildedRose.cs` ever so slightly differently 
        - one long line has been formatted across two lines
        - but I've also removed an empty line elsewhere - this is deliberate... 
        - ...so that when I refer to line numbers during the mutation demo, my line numbers will hopefully match other people's
  - [`coverage-demo-complete`](https://github.com/claresudbery/GildedRose-Refactoring-Kata/tree/coverage-demo-complete)
    - What the code looks like at the end of the coverage demo (see `coverage-demo-start` above)
    - It's basically the same as `csharp-mutation-start` (see notes below)
  - [`csharp-mutation-start`](https://github.com/claresudbery/GildedRose-Refactoring-Kata/tree/csharp-mutation-start)
    - Created as part of my mutation testing learning hour
    - My notes for this are in clare-tech - mutation-testing.md
    - This branch gives a useful starting point for my mutation testing demo 
      - it's basically in the same place as `coverage-demo-complete`, because this exercise takes up where that one left off
    - The following changes have been made from Emily's base. It has the same changes as `coverage-demo-start` (see notes above), and...
      - `ToString()` is no longer commented out in `Item.cs`
      - `GildedRoseTest.cs` has new combination approvals test code, which represents 100% test coverage but doesn't contain edge cases that will be discovered during the mutation testing demo
      - It has a new file - `GildedRoseTest.UpdateQuality.approved.txt` - which represents the approved test data from having added 100% test coverage in the code coverage learning hour
  - [`csharp-mutation-complete`](https://github.com/claresudbery/GildedRose-Refactoring-Kata/tree/csharp-mutation-complete)
    - What the code looks like at the end of the mutation demo (see `csharp-mutation-start` above)
    - The only actual change between this and `csharp-mutation-start` is that there are some extra combinations in `GildedRoseTest.cs`, to handle the revealed edge cases

## Emily's Intro

This Kata was originally created by Terry Hughes (http://twitter.com/TerryHughes). It is already on GitHub [here](https://github.com/NotMyself/GildedRose). See also [Bobby Johnson's description of the kata](https://iamnotmyself.com/refactor-this-the-gilded-rose-kata/).

I translated the original C# into a few other languages, (with a little help from my friends!), and slightly changed the starting position. This means I've actually done a small amount of refactoring already compared with the original form of the kata, and made it easier to get going with writing tests by giving you one failing unit test to start with. I also added test fixtures for Text-Based approval testing with TextTest (see [the TextTests](https://github.com/emilybache/GildedRose-Refactoring-Kata/tree/master/texttests))

As Bobby Johnson points out in his article ["Why Most Solutions to Gilded Rose Miss The Bigger Picture"](https://iamnotmyself.com/why-most-solutions-to-gilded-rose-miss-the-bigger-picture/), it'll actually give you
better practice at handling a legacy code situation if you do this Kata in the original C#. However, I think this kata
is also really useful for practicing writing good tests using different frameworks and approaches, and the small changes I've made help with that. I think it's also interesting to compare what the refactored code and tests look like in different programming languages.

I use this kata as part of my work as a technical coach. I wrote a lot about the coaching method I use in this book [Technical Agile Coaching with the Samman method](https://leanpub.com/techagilecoach). A while back I wrote this article ["Writing Good Tests for the Gilded Rose Kata"](http://coding-is-like-cooking.info/2013/03/writing-good-tests-for-the-gilded-rose-kata/) about how you could use this kata in a [coding dojo](https://leanpub.com/codingdojohandbook).

## How to use this Kata

The simplest way is to just clone the code and start hacking away improving the design. You'll want to look at the ["Gilded Rose Requirements"](https://github.com/emilybache/GildedRose-Refactoring-Kata/tree/master/GildedRoseRequirements.txt) which explains what the code is for. I strongly advise you that you'll also need some tests if you want to make sure you don't break the code while you refactor.

You could write some unit tests yourself, using the requirements to identify suitable test cases. I've provided a failing unit test in a popular test framework as a starting point for most languages.

Alternatively, use the "Text-Based" tests provided in this repository. (Read more about that in the next section)

Whichever testing approach you choose, the idea of the exercise is to do some deliberate practice, and improve your skills at designing test cases and refactoring. The idea is not to re-write the code from scratch, but rather to practice designing tests, taking small steps, running the tests often, and incrementally improving the design. 

### Gilded Rose Requirements in other languages 

- [English](GildedRoseRequirements.txt)
- [Español](GildedRoseRequirements_es.md)
- [Français](GildedRoseRequirements_fr.md)
- [日本語](GildedRoseRequirements_jp.md)
- [Português](GildedRoseRequirements_pt-BR.md)
- [Русский](GildedRoseRequirements_ru.txt)
- [ไทย](GildedRoseRequirements_th.md)
- [中文](GildedRoseRequirements_zh.txt)
- [한국어](GildedRoseRequirements_kr.md)
- [German](GildedRoseRequirements_de.md)

## Text-Based Approval Testing

Most language versions of this code have a [TextTest](https://texttest.org) fixture for Approval testing. For information about this, see the [TextTests README](https://github.com/emilybache/GildedRose-Refactoring-Kata/tree/master/texttests)

Note from Clare: You can also see my [clare-wiki section](https://clare-wiki.herokuapp.com/pages/think/code-princ/Refactoring#approval-testing) which has a few more notes on getting started.

## Translating this code

More translations are most welcome! I'm very open for pull requests that translate the starting position into additional languages. 

Please note a translation should ideally include:

- a translation of the production code for 'update_quality' and Item
- one failing unit test complaining that "fixme" != "foo"
- a TextTest fixture, ie a command-line program that runs update_quality on the sample data for the number of days specified.

Please don't write too much code in the starting position or add too many unit tests. The idea with the one failing unit test is to tempt people to work out how to fix it, discover it wasn't that hard, and now they understand what this test is doing they realize they can improve it.  

If your programming language doesn't have an easy way to add a command-line interface, then the TextTest fixture is probably not necessary.

