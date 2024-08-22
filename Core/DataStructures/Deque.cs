using System.Collections;

namespace Albin.AlgorithmsAndDataStructures.Core.DataStructures;

public interface IDeque<T> : IEnumerable<T>
{
    void AddFirst(T item);
    void AddLast(T item);
    T RemoveFirst();
    T RemoveLast();
    T PeekFirst();
    T PeekLast();
    bool IsEmpty();
    int Count { get; }
}

public class Deque<T> : IDeque<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;
    private int _count;

    public Deque()
    {
        _head = null;
        _tail = null;
        _count = 0;
    }

    public int Count => _count;

    public bool IsEmpty() => Count is 0;

    public void AddFirst(T item)
    {
        var temp = new Node<T>(item);

        if (_head is null)
        {
            _head = _tail = temp;
        }
        else
        {
            temp.Next = _head;
            _head.Prev = temp;
            _head = temp;
        }

        _count++;
    }

    public void AddLast(T item)
    {
        var temp = new Node<T>(item);

        if (_tail is null)
        {
            _head = _tail = temp;
        }
        else
        {
            _tail.Next = temp;
            temp.Prev = _tail;
            _tail = temp;
        }

        _count++;
    }

    public T RemoveFirst()
    {
        if (IsEmpty() || _head is null)
        {
            throw new InvalidOperationException("Deque is empty.");
        }

        var temp = _head.Data;

        if (_head == _tail)
        {
            _head = _tail = null;
        }
        else
        {
            _head = _head.Next;
            if (_head is not null)
            {
                _head.Prev = null;
            }
        }

        _count--;

        return temp;
    }

    public T RemoveLast()
    {
        if (IsEmpty() || _tail is null)
        {
            throw new InvalidOperationException("Deque is empty.");
        }

        var temp = _tail.Data;

        if (_head == _tail)
        {
            _head = _tail = null;
        }
        else
        {
            _tail = _tail.Prev;
            if (_tail is not null)
            {
                _tail.Next = null;
            }
        }

        _count--;

        return temp;
    }

    public T PeekFirst()
    {
        if (IsEmpty() || _head is null)
        {
            throw new InvalidOperationException("Deque is empty.");
        }

        return _head.Data;
    }

    public T PeekLast()
    {
        if (IsEmpty() || _tail is null)
        {
            throw new InvalidOperationException("Deque is empty.");
        }

        return _tail.Data;
    }

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

    private class Node<U>(U data)
    {
        public U Data { get; set; } = data;
        public Node<U>? Next { get; set; } = null;
        public Node<U>? Prev { get; set; } = null;
    }
}

/*
A Doubly Ended Queue (often abbreviated as Deque and pronounced as "deck") is a type of data structure that extends the functionality 
of a standard queue by allowing elements to be added or removed from both ends. 

Analogy
Imagine a line at a busy ticket counter where people can join from both the front and the back. 
Additionally, tickets are handed out not just from the front of the line but from the back as well. 
This setup allows for flexibility in how the line is managed, similar to how a deque allows operations at both ends.

Use cases:
- Palindrome Checking: Deques are useful for checking if a word or phrase is a palindrome, as you can efficiently compare characters from both ends.
- Undo/Redo Operations: Deques can be used to manage the history of actions in applications, allowing you to efficiently move forward and backward through user actions.
*/