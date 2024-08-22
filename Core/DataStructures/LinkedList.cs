using System.Collections;

namespace Albin.AlgorithmsAndDataStructures.Core.DataStructures;

public interface ILinkedList<T> : IEnumerable<T>
{
    void AddFirst(T item);
    void AddLast(T item);
    void RemoveFirst();
    void RemoveLast();
    T GetFirst();
    T GetLast();
    bool IsEmpty();
    int Count { get; }
}

public class LinkedList<T> : ILinkedList<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;
    private int _count;

    public LinkedList()
    {
        _head = null;
        _tail = null;
        _count = 0;
    }

    public int Count => _count;

    public bool IsEmpty() => _count is 0;

    /// <summary>
    /// Adds an item to the beginning of the linked list.
    /// </summary>
    /// <param name="item">The item to be added.</param>
    public void AddFirst(T item)
    {
        var temp = new Node<T>(item);

        if (IsEmpty())
        {
            _head = _tail = temp;
        }
        else
        {
            temp.Next = _head;
            _head = temp;
        }

        _count++;
    }

    /// <summary>
    /// Adds an item to the end of the linked list.
    /// </summary>
    /// <param name="item">The item to be added.</param>
    public void AddLast(T item)
    {
        var temp = new Node<T>(item);

        if (IsEmpty() || _tail is null)
        {
            _head = _tail = temp;
        }
        else
        {
            _tail.Next = temp;
            _tail = temp;
        }

        _count++;
    }

    /// <summary>
    /// Removes the first item from the linked list.
    /// If the linked list is empty, throws an InvalidOperationException.
    /// </summary>
    /// <exception cref="InvalidOperationException">If the linked list is empty.</exception>
    public void RemoveFirst()
    {
        if (IsEmpty() || _head is null)
        {
            throw new InvalidOperationException("Linked list is empty.");
        }

        _head = _head.Next;
        if (_head is null)
        {
            _tail = null;
        }

        _count--;
    }

    /// <summary>
    /// Removes the last item from the linked list.
    /// If the linked list is empty, throws an InvalidOperationException.
    /// </summary>
    /// <exception cref="InvalidOperationException">If the linked list is empty.</exception>
    public void RemoveLast()
    {
        if (IsEmpty() || _head is null)
        {
            throw new InvalidOperationException("Linked list is empty.");
        }

        if (_head == _tail)
        {
            _head = _tail = null;
            _count--;

            return;
        }

        var current = _head;
        while (current.Next != null && current.Next != _tail)
        {
            current = current.Next;
        }

        _tail = current;
        _tail.Next = null;

        _count--;
    }

    /// <summary>
    /// Returns the first item in the linked list.
    /// </summary>
    /// <returns>The first item in the linked list.</returns>
    /// <exception cref="InvalidOperationException">If the linked list is empty.</exception>
    public T GetFirst()
    {
        if (IsEmpty() || _head is null)
        {
            throw new InvalidOperationException("Linked list is empty.");
        }

        return _head.Data;
    }

    /// <summary>
    /// Returns the last item in the linked list.
    /// </summary>
    /// <returns>The last item in the linked list.</returns>
    /// <exception cref="InvalidOperationException">If the linked list is empty.</exception>
    public T GetLast()
    {
        if (IsEmpty() || _tail is null)
        {
            throw new InvalidOperationException("Linked list is empty.");
        }

        return _tail.Data;
    }

    /// <summary>
    /// Returns an enumerator that iterates through the linked list.
    /// </summary>
    public IEnumerator<T> GetEnumerator()
    {
        var current = _head;
        while (current is not null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private class Node<U>
    {
        public U Data { get; set; }
        public Node<U>? Next { get; set; }

        public Node(U data)
        {
            Data = data;
            Next = null;
        }
    }
}

/*
A linked list is a recursive data structure composed of nodes. Each Node contains two main components:
- Data/Item: This holds the actual data.
- Next: This is a reference (or link) to the next node in the sequence.

Analogy:
Taken from here: https://stackoverflow.com/a/644250/15634040
A linked list is kind of like a scavenger hunt. You have a clue, and that clue has a pointer to place to find the next clue. 
So you go to the next place and get another piece of data, and another pointer. 
To get something in the middle, or at the end, the only way to get to it is to follow this list from the beginning
*/