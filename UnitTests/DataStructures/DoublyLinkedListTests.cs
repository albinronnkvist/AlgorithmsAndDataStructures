using FluentAssertions.Execution;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.DataStructures;

public class DoublyLinkedListTests
{
    [Fact]
    public void IsEmpty_ShouldReturnTrueWhenListIsEmpty()
    {
        var list = new Core.DataStructures.DoublyLinkedList<int>();

        list.IsEmpty().Should().BeTrue();
    }

    [Fact]
    public void IsEmpty_ShouldReturnFalseWhenListHasItems()
    {
        var list = new Core.DataStructures.DoublyLinkedList<int>();
        list.AddFirst(1);

        list.IsEmpty().Should().BeFalse();
    }

    [Fact]
    public void AddFirst_ShouldAddItemToTheBeginning()
    {
        var list = new Core.DataStructures.DoublyLinkedList<int>();

        list.AddFirst(1);
        list.AddFirst(2);
        list.AddFirst(3);

        using var assertionScope = new AssertionScope();
        list.Count.Should().Be(3);
        list.GetFirst().Should().Be(3);
        list.GetLast().Should().Be(1);
    }

    [Fact]
    public void AddLast_ShouldAddItemToTheEnd()
    {
        var list = new Core.DataStructures.DoublyLinkedList<int>();

        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);

        using var assertionScope = new AssertionScope();
        list.Count.Should().Be(3);
        list.GetFirst().Should().Be(1);
        list.GetLast().Should().Be(3);
    }

    [Fact]
    public void RemoveFirst_ShouldRemoveTheFirstItem()
    {
        var list = new Core.DataStructures.DoublyLinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);

        list.RemoveFirst();

        using var assertionScope = new AssertionScope();
        list.Count.Should().Be(2);
        list.GetFirst().Should().Be(2);
        list.GetLast().Should().Be(3);
    }

    [Fact]
    public void RemoveLast_ShouldRemoveTheLastItem()
    {
        var list = new Core.DataStructures.DoublyLinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);

        list.RemoveLast();

        using var assertionScope = new AssertionScope();
        list.Count.Should().Be(2);
        list.GetFirst().Should().Be(1);
        list.GetLast().Should().Be(2);
    }


    [Fact]
    public void RemoveFirst_ShouldMakeListEmptyIfOnlyOneItemExists()
    {
        var list = new Core.DataStructures.DoublyLinkedList<int>();
        list.AddFirst(1);

        list.RemoveFirst();

        using var assertionScope = new AssertionScope();
        list.Count.Should().Be(0);
        list.IsEmpty().Should().BeTrue();
    }

    [Fact]
    public void RemoveLast_ShouldMakeListEmptyIfOnlyOneItemExists()
    {
        var list = new Core.DataStructures.DoublyLinkedList<int>();
        list.AddLast(1);

        list.RemoveLast();

        using var assertionScope = new AssertionScope();
        list.Count.Should().Be(0);
        list.IsEmpty().Should().BeTrue();
    }

    [Fact]
    public void GetFirst_ShouldThrowWhenListIsEmpty()
    {
        var list = new Core.DataStructures.DoublyLinkedList<int>();

        Action action = () => list.GetFirst();

        action.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void GetLast_ShouldThrowWhenListIsEmpty()
    {
        var list = new Core.DataStructures.DoublyLinkedList<int>();

        Action action = () => list.GetLast();

        action.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Enumerator_ShouldIterateOverAllItems()
    {
        var list = new Core.DataStructures.DoublyLinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);

        var items = list.ToList();

        items.Should().Equal(1, 2, 3);
    }
}
