using System.Collections;

namespace Albin.AlgorithmsAndDataStructures.Core.DataStructures;

public interface IQueue<T> : IEnumerable<T>
{
    void Enqueue(T item);
    T Dequeue();
    T Peek();
    bool IsEmpty();
    int Count { get; }
}

public class Queue<T> : IQueue<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;
    private int _count;

    public Queue()
    {
        _head = null;
        _tail = null;
        _count = 0;
    }

    public int Count => _count;

    public bool IsEmpty() => Count is 0;

    /// <summary>
    /// Adds an item to the end of the queue.
    /// </summary>
    /// <param name="item">The item to be added.</param>
    public void Enqueue(T item)
    {
        var temp = new Node<T>(item);

        if (_tail is null)
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
    /// Removes and returns the first item from the queue.
    /// If the queue is empty, throws an InvalidOperationException.
    /// </summary>
    /// <returns>The first item in the queue.</returns>
    /// <exception cref="InvalidOperationException">If the queue is empty.</exception>
    public T Dequeue()
    {
        if (IsEmpty() || _head is null)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        var temp = _head.Data;
        if (_head.Next is null)
        {
            _tail = null;
        }

        _count--;
        
        return temp;
    }

    /// <summary>
    /// Returns the first item in the queue without removing it.
    /// If the queue is empty, throws an InvalidOperationException.
    /// </summary>
    /// <returns>The first item in the queue.</returns>
    /// <exception cref="InvalidOperationException">If the queue is empty.</exception>
    public T Peek()
    {
        if (IsEmpty() || _head is null)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        return _head.Data;
    }

    /// <summary>
    /// Returns an enumerator that iterates through the queue.
    /// The enumerator returns the data of each node in the queue, in the order they were added.
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
    }
}

/*
A queue is a linear data structure that follows the First-In-First-Out (FIFO) principle. 
This means that the first element added to the queue will be the first one to be removed. 

Analogy:
Imagine you're at a checkout line in a grocery store. The first person to get in line is the first person to check out. 
As more people join the line, they stand behind the last person, and each person leaves the line in the order they entered. 

Use cases:
- Task Scheduling: Queues are used in operating systems for managing tasks, such as scheduling processes.
- Request Handling: Web servers use queues to manage incoming requests to ensure that they are handled in the order they are received.
*/