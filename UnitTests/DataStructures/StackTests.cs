using System.Reflection;
using FluentAssertions.Execution;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.DataStructures;

public class StackTests
{
    // ***********************
    // Using custom Stack<T> *
    // ***********************
    [Fact]
    public void MyImpl_Pop_RemovesAndReturnsTopItem()
    {
        var stack = new Core.DataStructures.Stack<string>();

        stack.Push("Red");
        stack.Push("Green");
        stack.Push("Blue");
        stack.Push("Purple");
        stack.Push("Orange");

        using var assertionScope = new AssertionScope();
        stack.Pop().Should().Be("Orange");
        stack.Count.Should().Be(4);
    }

    [Fact]
    public void MyImpl_Peek_ReturnsTopItem()
    {
        var stack = new Core.DataStructures.Stack<string>();

        stack.Push("Red");
        stack.Push("Green");
        stack.Push("Blue");
        stack.Push("Purple");
        stack.Push("Orange");

        using var assertionScope = new AssertionScope();
        stack.Peek().Should().Be("Orange");
        stack.Count.Should().Be(5);
    }

    [Fact]
    public void MyImpl_PopEmpty_ThrowsInvalidOperationException()
    {
        var stack = new Core.DataStructures.Stack<string>();

        stack.Push("Red");
        stack.Push("Green");

        stack.Pop();
        stack.Pop();

        Action act = () => stack.Pop();
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void MyImpl_PushMoreItemsThanInitialCapacity_AutomaticallyDoublesCapacity()
    {
        const int initialCapacity = 4;
        var stack = new Core.DataStructures.Stack<string>(initialCapacity);

        stack.Push("Red");
        stack.Push("Green");
        stack.Push("Blue");
        stack.Push("Purple");

        int capacityBefore = stack.Capacity;
        stack.Push("Orange");
        int capacityAfter = stack.Capacity;

        using var assertionScope = new AssertionScope();
        capacityBefore.Should().Be(initialCapacity);
        capacityAfter.Should().Be(capacityBefore * 2);
        stack.Count.Should().Be(5);
        stack.Pop().Should().Be("Orange");
    }



    // *************************
    // Using standard Stack<T> *
    // *************************
    [Fact]
    public void Standard_Pop_RemovesAndReturnsTopItem()
    {
        var stack = new System.Collections.Generic.Stack<string>();

        stack.Push("Red");
        stack.Push("Green");
        stack.Push("Blue");
        stack.Push("Purple");
        stack.Push("Orange");

        using var assertionScope = new AssertionScope();
        stack.Pop().Should().Be("Orange");
        stack.Count.Should().Be(4);
    }

    [Fact]
    public void Standard_Peek_ReturnsTopItem()
    {
        var stack = new System.Collections.Generic.Stack<string>();

        stack.Push("Red");
        stack.Push("Green");
        stack.Push("Blue");
        stack.Push("Purple");
        stack.Push("Orange");

        using var assertionScope = new AssertionScope();
        stack.Peek().Should().Be("Orange");
        stack.Count.Should().Be(5);
    }

    [Fact]
    public void Standard_PopEmpty_ThrowsInvalidOperationException()
    {
        var stack = new System.Collections.Generic.Stack<string>();

        stack.Push("Red");
        stack.Push("Green");

        stack.Pop();
        stack.Pop();

        Action act = () => stack.Pop();
        act.Should().Throw<InvalidOperationException>();
    }

    // If you know in advance that your stack will hold a large number of elements, 
    // specifying an initial capacity can reduce the number of memory allocations needed as the stack grows. 
    // Without an initial capacity, the stack starts with a default size (usually small), and each time it needs to grow, 
    // it will allocate a new, larger array and copy the elements over. 
    // This reallocation and copying can be costly in terms of both time and memory.
    [Fact]
    public void Standard_PushMoreItemsThanInitialCapacity_AutomaticallyDoublesCapacity()
    {
        const int initialCapacity = 4;
        var stack = new System.Collections.Generic.Stack<string>(initialCapacity);

        stack.Push("Red");
        stack.Push("Green");
        stack.Push("Blue");
        stack.Push("Purple");

        int capacityBefore = GetStackCapacity(stack);
        stack.Push("Orange");
        int capacityAfter = GetStackCapacity(stack);

        using var assertionScope = new AssertionScope();
        capacityBefore.Should().Be(initialCapacity);
        capacityAfter.Should().Be(capacityBefore * 2);
        stack.Count.Should().Be(5);
        stack.Pop().Should().Be("Orange");
    }

    [Fact]
    public void Standard_Clear()
    {
        var stack = new System.Collections.Generic.Stack<string>();

        stack.Push("Red");
        stack.Push("Green");
        stack.Push("Blue");
        stack.Push("Purple");

        stack.Clear();

        stack.Count.Should().Be(0);
    }

    private int GetStackCapacity<T>(System.Collections.Generic.Stack<T> stack)
    {
        var arrayField = typeof(System.Collections.Generic.Stack<T>)
            .GetField("_array", BindingFlags.NonPublic | BindingFlags.Instance);

        var array = arrayField?.GetValue(stack) as T[];
        return array?.Length ?? throw new Exception("Unable to get stack capacity");
    }
}