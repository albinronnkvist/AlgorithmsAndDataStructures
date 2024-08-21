namespace Albin.AlgorithmsAndDataStructures.Core.DataStructures;

public interface IStack<T> : IEnumerable<T>
{
    void Push(T item);
    T Pop();
    T Peek();
    bool IsEmpty();
}

public class Stack<T>
{
    private T[] _items;
    private int _count;

    public Stack()
    {
        _items = new T[4];
        _count = 0;
    }

    public int Count => _count;
    public int Capacity => _items.Length;

    public void Push(T item)
    {
        if (_count == _items.Length)
        {
            Resize(_items.Length * 2);
        }

        _items[_count++] = item;
    }

    public T Pop()
    {
        if (_count is 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        T item = _items[--_count];
        return item;
    }

    public T Peek()
    {
        if (_count is 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        return _items[_count - 1];
    }

    private void Resize(int newSize)
    {
        T[] newArray = new T[newSize];
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