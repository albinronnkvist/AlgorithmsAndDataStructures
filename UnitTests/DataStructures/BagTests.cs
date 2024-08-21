using Albin.AlgorithmsAndDataStructures.Core.DataStructures;
using FluentAssertions.Execution;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.DataStructures;

public class BagTests
{
    [Fact]
    public void InitializeEmptyBag_ShouldBeEmpty_AndHaveZeroCount()
    {
        var bag = new Bag<string>();

        using var assertionScope = new AssertionScope();
        bag.IsEmpty().Should().BeTrue();
        bag.Count.Should().Be(0);
    }

    [Fact]
    public void AddItemsToBag_ShouldNotBeEmpty_AndShouldHaveExpectedCount()
    {
        var bag = new Bag<string>();

        bag.Add("Red");
        bag.Add("Green");
        bag.Add("Blue");

        using var assertionScope = new AssertionScope();
        bag.IsEmpty().Should().BeFalse();
        bag.Count.Should().Be(3);
    }

    [Fact]
    public void IteratePopulatedBag_ShouldReturnAllItems()
    {
        var bag = new Bag<string>();

        bag.Add("Red");
        bag.Add("Green");
        bag.Add("Blue");

        var newBag = new Bag<string>();
        foreach (var item in bag)
        {
            newBag.Add(item);
        }

        newBag.Should().BeEquivalentTo(bag);
    }
}
