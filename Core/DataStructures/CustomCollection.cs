using System.Collections;

namespace Albin.AlgorithmsAndDataStructures.Core.DataStructures;

public class CustomCollection<T> : IEnumerable<T>
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

    public int Size => _count;
    public bool IsEmpty() => _count is 0;
    public int Capacity => _items.Length;

    public void Add(T item)
    {
        if (_count == _items.Length)
        {
            Resize(_items.Length * 2);
        }

        _items[_count++] = item;
    }

    public void TrimExcess()
    {
        if (_count < _items.Length)
        {
            Resize(_count);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new CustomEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }



    private void Resize(int newCapacity)
    {
        T[] newArray = new T[newCapacity];
        Array.Copy(_items, newArray, _count);
        _items = newArray;
    }



    // Enumerator
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

        public void Reset()
        {
            _index = -1;
            _current = default(T);
        }

        public void Dispose()
        {
        }
    }
}
