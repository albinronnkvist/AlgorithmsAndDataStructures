using FluentAssertions.Execution;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.DataStructures;

public class QueueTests
{
    [Fact]
    public void MyImpl_IsEmpty_ShouldReturnTrueWhenQueueIsEmpty()
    {
        var queue = new Core.DataStructures.Queue<int>();

        queue.IsEmpty().Should().BeTrue();
    }

    [Fact]
    public void MyImpl_IsEmpty_ShouldReturnFalseWhenQueueIsNotEmpty()
    {
        var queue = new Core.DataStructures.Queue<int>();
        queue.Enqueue(10);

        queue.IsEmpty().Should().BeFalse();
    }

    [Fact]
    public void MyImpl_Enqueue_ShouldAddItemToQueue()
    {
        var queue = new Core.DataStructures.Queue<int>();

        queue.Enqueue(10);

        using var assertionScope = new AssertionScope();
        queue.Count.Should().Be(1);
        queue.Peek().Should().Be(10);
    }

    [Fact]
    public void MyImpl_Dequeue_ShouldRemoveAndReturnItemFromQueue()
    {
        var queue = new Core.DataStructures.Queue<int>();
        queue.Enqueue(10);

        var queueCountBeforeDequeue = queue.Count;
        var dequeResult = queue.Dequeue();
        var queueCountAfterDequeue = queue.Count;

        using var assertionScope = new AssertionScope();
        dequeResult.Should().Be(10);
        queueCountBeforeDequeue.Should().Be(1);
        queueCountAfterDequeue.Should().Be(0);
    }

    [Fact]
    public void MyImpl_Dequeue_ShouldRemoveAndReturnItemFromQueueFifo()
    {
        var queue = new Core.DataStructures.Queue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);

        var queueCountBeforeDequeue = queue.Count;
        var dequeResult = queue.Dequeue();
        var queueCountAfterDequeue = queue.Count;

        using var assertionScope = new AssertionScope();
        dequeResult.Should().Be(10);
        queueCountBeforeDequeue.Should().Be(2);
        queueCountAfterDequeue.Should().Be(1);
    }

    [Fact]
    public void MyImpl_Dequeue_OnEmptyQueue_ShouldThrowInvalidOperationException()
    {
        var queue = new Core.DataStructures.Queue<int>();
        
        var act = () => queue.Dequeue();

        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void MyImpl_Peek_ShouldReturnItemWithoutRemovingIt()
    {
        var queue = new Core.DataStructures.Queue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);

        var result = queue.Peek();

        using var assertionScope = new AssertionScope();
        result.Should().Be(10);
        queue.Count.Should().Be(2);
    }

    [Fact]
    public void MyImpl_Peek_OnEmptyQueue_ShouldThrowInvalidOperationException()
    {
        var queue = new Core.DataStructures.Queue<int>();

        var act = () => queue.Peek();

        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void MyImpl_Enumerator_ShouldIterateOverQueueItems()
    {
        var queue = new Core.DataStructures.Queue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        var result = new List<int>();
        foreach (var item in queue)
        {
            result.Add(item);
        }

        result.Should().BeEquivalentTo([10, 20, 30]);
    }

    [Fact]
    public void MyImpl_Count_ShouldReturnCorrectNumberOfItemsInQueue()
    {
        var queue = new Core.DataStructures.Queue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        var count = queue.Count;

        count.Should().Be(3);
    }



    // **********
    // Standard *
    // **********
    [Fact]
    public void Standard_Constructor_ShouldAddItemToQueue()
    {
        var queue = new Queue<int>([10]);

        using var assertionScope = new AssertionScope();
        queue.Count.Should().Be(1);
        queue.Peek().Should().Be(10);
    }

    [Fact]
    public void Standard_Enqueue_ShouldAddItemToQueue()
    {
        var queue = new Queue<int>();

        queue.Enqueue(10);

        using var assertionScope = new AssertionScope();
        queue.Count.Should().Be(1);
        queue.Peek().Should().Be(10);
    }

    [Fact]
    public void Standard_Dequeue_ShouldRemoveAndReturnItemFromQueue()
    {
        var queue = new Queue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);

        var queueCountBeforeDequeue = queue.Count;
        var dequeResult = queue.Dequeue();
        var queueCountAfterDequeue = queue.Count;

        using var assertionScope = new AssertionScope();
        dequeResult.Should().Be(10);
        queueCountBeforeDequeue.Should().Be(2);
        queueCountAfterDequeue.Should().Be(1);
    }

    [Fact]
    public void Standard_Dequeue_OnEmptyQueue_ShouldThrowInvalidOperationException()
    {
        var queue = new Queue<int>();
        
        var act = () => queue.Dequeue();

        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Standard_Peek_ShouldReturnItemWithoutRemovingIt()
    {
        var queue = new Queue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);

        var result = queue.Peek();

        using var assertionScope = new AssertionScope();
        result.Should().Be(10);
        queue.Count.Should().Be(2);
    }

    [Fact]
    public void Standard_Peek_OnEmptyQueue_ShouldThrowInvalidOperationException()
    {
        var queue = new Queue<int>();

        var act = () => queue.Peek();

        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Standard_TryPeek_OnEmptyQueue_ShouldReturnFalse_AndDefaultValue()
    {
        var queue = new Queue<int>();

        var result = queue.TryPeek(out int item);

        result.Should().BeFalse();
        item.Should().Be(0);
    }
}
