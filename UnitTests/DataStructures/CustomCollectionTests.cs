using Albin.AlgorithmsAndDataStructures.Core.DataStructures;
using FluentAssertions.Execution;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.DataStructures;

public class CustomCollectionTests
{
    [Fact]
    public void InitializeEmptyCollection_CollectionShouldBeEmpty_AndHaveZeroCount_AndDefaultCapacity()
    {
        var collection = new CustomCollection<string>();

        using var assertionScope = new AssertionScope();
        collection.IsEmpty().Should().BeTrue();
        collection.Count.Should().Be(0);
        collection.Capacity.Should().Be(10);
    }

    [Fact]
    public void AddItemsToCollection_CollectionShouldNotBeEmpty_AndShouldHaveExpectedCount()
    {
        var collection = new CustomCollection<string>();

        collection.Add("Red");
        collection.Add("Green");
        collection.Add("Blue");

        using var assertionScope = new AssertionScope();
        collection.IsEmpty().Should().BeFalse();
        collection.Count.Should().Be(3);
    }

    [Fact]
    public void AddMoreItemsThanInitialCapacity_ShouldDoubleCapacity()
    {
        const int initialCapacity = 4;
        var collection = new CustomCollection<string>(initialCapacity);

        collection.Add("Red");
        collection.Add("Green");
        collection.Add("Blue");
        collection.Add("Purple");

        int capacityBefore = collection.Capacity;
        collection.Add("Orange");
        int capacityAfter = collection.Capacity;

        using var assertionScope = new AssertionScope();
        capacityBefore.Should().Be(initialCapacity);
        capacityAfter.Should().Be(initialCapacity * 2);
        collection.Count.Should().Be(5);
    }

    [Fact]
    public void TrimExcess_ShouldDecreaseExcessiveCapacity_AndNotAffectAnyCurrentItems()
    {
        const int initialCapacity = 100;
        var collection = new CustomCollection<string>(initialCapacity);

        collection.Add("Red");
        collection.Add("Green");
        collection.Add("Blue");
        collection.Add("Purple");

        int capacityBefore = collection.Capacity;
        collection.TrimExcess();
        int capacityAfter = collection.Capacity;

        using var assertionScope = new AssertionScope();
        capacityBefore.Should().Be(initialCapacity);
        capacityAfter.Should().Be(4);
        collection.Count.Should().Be(4);
    }

    [Fact]
    public void IteratePopulatedCollection_ShouldReturnAllItems()
    {
        var collection = new CustomCollection<string>();

        collection.Add("Red");
        collection.Add("Green");
        collection.Add("Blue");

        var newCollection = new CustomCollection<string>();
        foreach (var item in collection)
        {
            newCollection.Add(item);
        }

        newCollection.Should().BeEquivalentTo(collection);
    }

    [Fact]
    public void GetFirstItem()
    {
        var collection = new CustomCollection<string>();

        collection.Add("Red");
        collection.Add("Green");
        collection.Add("Blue");

        collection.First().Should().Be("Red");
    }

    [Fact]
    public void ResetEnumerator()
    {
        var collection = new CustomCollection<string>();
        collection.Add("Red");
        collection.Add("Green");
        collection.Add("Blue");

        var enumerator = collection.GetEnumerator();

        using var assertionScope = new AssertionScope();
        enumerator.MoveNext();
        enumerator.Current.Should().Be("Red");

        enumerator.Reset();
        enumerator.MoveNext();
        enumerator.Current.Should().Be("Red");
    }

    [Fact]
    public void InvalidEnumeratorAccess()
    {
        var collection = new CustomCollection<string>();
        collection.Add("Red");

        var enumerator = collection.GetEnumerator();

        using var assertionScope = new AssertionScope();

        // Access Current before MoveNext is called
        Action act = () => { var current = enumerator.Current; };
        act.Should().Throw<InvalidOperationException>();

        // Iterate through the collection
        enumerator.MoveNext();
        enumerator.Current.Should().Be("Red");

        // Access Current after iteration is complete
        enumerator.MoveNext();
        act = () => { var current = enumerator.Current; };
        act.Should().Throw<InvalidOperationException>();
    }
}
