using System.Collections;

namespace Albin.AlgorithmsAndDataStructures.Core.DataStructures;

public interface IBag<T> : IEnumerable<T>
{
    void Add(T item);
    bool IsEmpty();
}

public class Bag<T> : IBag<T>
{
    private readonly List<T> _items = new List<T>();

    public int Count 
        => _items.Count;

    public void Add(T item) 
        => _items.Add(item);

    public bool IsEmpty()
        => _items.Count is 0;

    public IEnumerator<T> GetEnumerator() 
        => _items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() 
        => GetEnumerator();
}

/*
A Bag is a type of collection that allows items to be added and iterated over, but not removed. 
Unlike Stacks and Queues, where the order of processing items is critical, a Bag does not enforce any specific order. 
The focus is solely on the ability to collect items and process them, without concern for the order in which they are handled.

Analogy:
A collector puts marbles into a bag one by one. 
The collector may want to process these marbles, for example by checking each marble for a particular characteristic. 
The order in which the marbles are checked is not important.

Use cases:
- When you want to emphasize that the order of which the items are processed does not matter.
- Calculating averages or standard deviations.
- Aggregating data, for example survey responses.
*/