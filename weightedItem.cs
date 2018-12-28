using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class WeightedItem<T>
{
    private T _item;
    private int _weight;

    /// <summary>
    /// A weighted item
    /// </summary>
    /// <param name="item">The Item</param>
    /// <param name="weight">The Weight</param>
    public WeightedItem(T item, int weight = 1)
    {
        _item = item;
        _weight = weight;
    }

    public T getItem() { return _item; }
    public int getWeight() { return _weight; }
}