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
    public int Count => throw new NotImplementedException();

    public bool IsEmpty() => Count is 0;

    public void Enqueue(T item)
    {
        throw new NotImplementedException();
    }

    public T Dequeue()
    {
        throw new NotImplementedException();
    }

    public T Peek()
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
