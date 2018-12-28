using System;
using System.Collections.Generic;

public class WeightedItemList<T>
{
    private List<WeightedItem<T>> _contents;
    private int _totalWeight;
    private Random _random;

    /// <summary>
    /// Creates a weighted item list
    /// </summary>
    public WeightedItemList()
    {
        _contents = new List<WeightedItem<T>>();
        _totalWeight = 0;
        _random = new Random();
    }

    /// <summary>
    /// Adds an item to the weighted item list
    /// </summary>
    /// <param name="item">The weightedItem you want to generate</param>
    public void addItem(WeightedItem<T> item)
    {
        _contents.Add(item);
        _totalWeight += item.getWeight();
    }

    /// <summary>
    /// Adds an item to the weighted item list
    /// </summary>
    /// <param name="item">The item you want to add</param>
    /// <param name="weight">The weight of the item you are adding</param>
    public void addItem(T item, int weight = 1)
    {
        addItem(new WeightedItem<T>(item, weight));
    }

    /// <summary>
    /// Emptys the weighted item list.
    /// </summary>
    public void clear()
    {
        _contents.Clear();
        _totalWeight = 0;
    }

    /// <summary>
    /// Retrieves a weighted item from an internal roll.
    /// </summary>
    /// <returns>A random weighted item from the list. null if something went wrong.</returns>
    public WeightedItem<T> getWeightedItem()
    {
        int roll = _random.Next(0, _totalWeight) + 1;
        int seenWeight = 0;

        for (int i = 0; i < _contents.Count; i++)
        {
            seenWeight += _contents[i].getWeight();
            if (roll <= seenWeight)
            {
                return _contents[i];
            }
        }

        return null;
    }

    /// <summary>
    /// Retrieves an item from an internal roll.
    /// </summary>
    /// <returns>A random item from the list. default(T) if something went wrong.</returns>
    public T getItem()
    {
        WeightedItem<T> item = getWeightedItem();

        if(item == null)
        {
            return default(T);
        }

        return item.getItem();
    }

    /// <summary>
    /// Get all the items in the list.
    /// </summary>
    /// <returns>A list of all the items</returns>
    public List<WeightedItem<T>> getAllItems()
    {
        return _contents;
    }

    /// <summary>
    /// Get the count of items in the list.
    /// </summary>
    /// <returns>Number of items in the list</returns>
    public int count()
    {
        return _contents.Count;
    }
}
