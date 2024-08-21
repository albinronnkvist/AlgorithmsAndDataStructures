namespace Albin.AlgorithmsAndDataStructures.Core.DataStructures;

public interface IQueue<T> : IEnumerable<T>
{
    void Enqueue(T item);
    T Dequeue();
    T Peek();
    int Count { get; }
}

public class Queue
{
    
}
