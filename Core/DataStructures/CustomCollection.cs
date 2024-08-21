using System.Collections;

namespace Albin.AlgorithmsAndDataStructures.Core.DataStructures;

public interface ICustomCollection<T> : IEnumerable<T>
{
    int Count { get; }
    int Capacity { get; }
    bool IsEmpty();
    void Add(T item);
    void TrimExcess();
}

public class CustomCollection<T> : ICustomCollection<T>
{
    private T[] _items;
    private int _count;

    public CustomCollection(int capacity = 10)
    {
        if (capacity < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than 0");
        }

        _items = new T[capacity];
        _count = 0;
    }

    public int Count => _count;
    public int Capacity => _items.Length;

    /// <summary>
    /// Checks if the collection is empty.
    /// </summary>
    public bool IsEmpty() => _count is 0;

    /// <summary>
    /// Adds an item to the collection.
    /// If the current capacity is reached, the capacity is doubled.
    /// </summary>
    /// <param name="item">The item to be added.</param>
    public void Add(T item)
    {
        if (_count == _items.Length)
        {
            Resize(_items.Length * 2);
        }

        _items[_count++] = item;
    }

    /// <summary>
    /// Reduces the capacity of the collection to the current size.
    /// This can be useful when the collection has been initialized with a large capacity
    /// but the actual size is much smaller.
    /// </summary>
    public void TrimExcess()
    {
        if (_count < _items.Length)
        {
            Resize(_count);
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator for the collection.</returns>
    public IEnumerator<T> GetEnumerator() => new CustomEnumerator(this);

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator for the collection.</returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();



    /// <summary>
    /// Creates a new array with the given capacity and copies the elements from the current array into it.
    /// </summary>
    /// <param name="newCapacity">The new capacity of the array.</param>
    private void Resize(int newCapacity)
    {
        T[] newArray = new T[newCapacity];
        Array.Copy(_items, newArray, _count);
        _items = newArray;
    }



    private class CustomEnumerator : IEnumerator<T>
    {
        private CustomCollection<T> _collection;
        private int _index;
        private T? _current;

        public CustomEnumerator(CustomCollection<T> collection)
        {
            _collection = collection;
            _index = -1;
            _current = default(T);
        }

        public T Current
        {
            get
            {
                if (_index is -1 || _index >= _collection._count)
                {
                    throw new InvalidOperationException("Enumeration has not started or has already finished.");
                }

                return _current!;
            }
        }

        object IEnumerator.Current => Current ?? throw new InvalidOperationException();


        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the enumerator was successfully advanced to the next element; <c>false</c> if the enumerator has passed the end of the collection.
        /// </returns>
        public bool MoveNext()
        {
            if (++_index < _collection._count)
            {
                _current = _collection._items[_index];
                return true;
            }

            _index = _collection._count;
            _current = default(T);
            return false;
        }

        /// <summary>
        /// Resets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        public void Reset()
        {
            _index = -1;
            _current = default(T);
        }


        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <remarks>
        /// This method is required by the <see cref="IDisposable"/> interface which IEnumerator<T> implements.
        /// It is currenly an empty implementation method and does not actually free any resources.
        /// </remarks>
        public void Dispose()
        {
        }
    }
}
