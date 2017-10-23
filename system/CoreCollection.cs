using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreCollection<T>
{
    private T[] _items;
    private int _itemsCount = 0;

    public T this[int index]
    {
        get
        {
            return _items[index];
        }

        set
        {
            _items[index] = value;
        }
    }

    /// <summary>
    /// Gets the length of collection
    /// </summary>
    public int Length
    {
        get
        {
            return _itemsCount;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CoreCollection{T}"/> class
    /// </summary>
    /// <param name="length">Collection max size</param>
    public CoreCollection(int length)
    {
        _items = new T[length];
    }

    /// <summary>
    /// Removes the specified item
    /// </summary>
    /// <param name="item">Item</param>
    public void Remove(T item)
    {
        for(int i = 0; i < _itemsCount; i++)
        {
            if(_items[i].Equals(item))
            {
                Remove(i);
                return;
            }
        }
    }

    /// <summary>
    /// Removes the specified index
    /// </summary>
    /// <param name="index">The index</param>
    public void Remove(int index)
    {
        _itemsCount--;

        for (int i = index; i < _itemsCount; i++)
        {
            _items[i] = _items[i + 1];
        }
    }

    /// <summary>
    /// Pushes item to collection
    /// </summary>
    /// <param name="item">Item</param>
    public void Add(T item)
    {
        _items[_itemsCount] = item;
        _itemsCount++;
    }
}
