using System.Collections;

namespace Albin.AlgorithmsAndDataStructures.Core.DataStructures;

public interface IDoublyLinkedList<T> : IEnumerable<T>
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

public class DoublyLinkedList<T> : IDoublyLinkedList<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;
    private int _count;

    public DoublyLinkedList()
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

        if (IsEmpty() || _head is null)
        {
            _head = _tail = temp;
        }
        else
        {
            temp.Next = _head;
            _head.Previous = temp;
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
            temp.Previous = _tail;
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

        if (_head == _tail)
        {
            _head = _tail = null;
        }
        else
        {
            _head = _head.Next;
            _head!.Previous = null;
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
        if (IsEmpty() || _tail is null)
        {
            throw new InvalidOperationException("Linked list is empty.");
        }

        if (_head == _tail)
        {
            _head = _tail = null;
        }
        else
        {
            _tail = _tail.Previous;
            _tail!.Next = null;
        }

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

    private class Node<U>(U data)
    {
        public U Data { get; set; } = data;
        public Node<U>? Next { get; set; } = null;
        public Node<U>? Previous { get; set; } = null;
    }
}

