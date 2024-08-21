using System.Collections;

namespace Albin.AlgorithmsAndDataStructures.Core.DataStructures;

public interface IStack<T> : IEnumerable<T>
{
    void Push(T item);
    T Pop();
    T Peek();
    bool IsEmpty();
    int Count { get; }
    int Capacity { get; }
}

public class Stack<T>(int capacity = 4) : IStack<T>
{
    private T[] _items = new T[capacity];
    private int _count = 0;

    public int Count => _count;
    public int Capacity => _items.Length;

    public bool IsEmpty() => _count is 0;

    /// <summary>
    /// Pushes an item onto the stack.
    /// 
    /// If the stack is full, it will automatically double its capacity.
    /// </summary>
    /// <param name="item">The item to push onto the stack.</param>
    public void Push(T item)
    {
        if (_count == _items.Length)
        {
            Resize(_items.Length * 2);
        }

        _items[_count++] = item;
    }

    /// <summary>
    /// Removes and returns the top item from the stack.
    /// 
    /// If the stack becomes less than one-fourth full after removing an item, it will automatically halve its capacity.
    /// </summary>
    /// <returns>The item removed from the stack.</returns>
    /// <exception cref="InvalidOperationException">If the stack is empty.</exception>
    public T Pop()
    {
        if (_count is 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        T item = _items[--_count];
        _items[_count] = default!;

        if (_count > 0 && _count < _items.Length / 4)
        {
            Resize(_items.Length / 2);
        }

        return item;
    }

    /// <summary>
    /// Returns the top item from the stack without removing it.
    /// </summary>
    /// <returns>The top item from the stack.</returns>
    /// <exception cref="InvalidOperationException">If the stack is empty.</exception>
    public T Peek()
    {
        if (_count is 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        return _items[_count - 1];
    }

    public IEnumerator<T> GetEnumerator() => (IEnumerator<T>)_items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();



    /// <summary>
    /// Creates a new array with the given size and copies the elements from the current array into it.
    /// </summary>
    /// <param name="newCapacity">The size of the new array.</param>
    private void Resize(int newCapacity)
    {
        T[] newArray = new T[newCapacity];
        Array.Copy(_items, newArray, _count);
        _items = newArray;
    }
}

/*
Stacks stores objects in a sort of vertical tower where the last object that was added is the first object to be fetched (LIFO).

Analogy:
Stacks behaves like a stack of plates, where the last plate added is the first one to be removed.
- Pushing an element onto the stack is like adding a new plate on top.
- Popping an element removes the top plate from the stack.

Use cases:
- Undo/Redo operations
- Browser History
- Function calls
- Depth-first search
*/