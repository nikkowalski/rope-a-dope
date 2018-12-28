using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Aenima<T>
{
    private Queue<T> _history;
    private int _maxInHistory;  //If there are less than this many in history you can add it to the current contents.
    private int _maxHistoryLength;

    private WeightedItemList<T> _contents;
    private WeightedItemList<T> _currentContents;

    /// <summary>
    /// Creates a random selector which will restrict the selection to what has not exceeded the limit within the history.
    /// </summary>
    /// <param name="maxHistoryLength">The length of history to track</param>
    /// <param name="maxInHistory">The limit of how much can exist in history before removal from the selection</param>
    public Aenima(int maxHistoryLength, int maxInHistory = 1)
    {
        _maxInHistory = maxInHistory;
        _maxHistoryLength = maxHistoryLength;
        _history = new Queue<T>();
        _contents = new WeightedItemList<T>();
        _currentContents = new WeightedItemList<T>();
    }

    /// <summary>
    /// Adds an item to the list
    /// </summary>
    /// <param name="item">The item</param>
    /// <param name="weight">The weight</param>
    public void addItem(T item, int weight = 1)
    {
        _contents.addItem(item, weight);

        updateCurrentContents();
    }

    /// <summary>
    /// Gets the next item from the list, and updates the history as well as current contents.
    /// </summary>
    /// <returns>A random valid selection. default(T) if something went wrong.</returns>
    public T getNext()
    {
        WeightedItem<T> wItem = _currentContents.getWeightedItem();

        if (wItem == null)
        {
            Debug.Log("wItem is null");
            return default(T);
        }

        _history.Enqueue(wItem.getItem());
        while (_history.Count > _maxHistoryLength)
        {
            T poppedItem = _history.Dequeue();
        }
        updateCurrentContents();    //Easiest way but not most efficient way
        return wItem.getItem();
    }

    /// <summary>
    /// Rebuilds the current content weightedItemList
    /// </summary>
    private void updateCurrentContents()
    {
        _currentContents.clear();

        Dictionary<T, int> _countInHistory = new Dictionary<T, int>();
        foreach (T historyItem in _history)
        {
            if(_countInHistory.ContainsKey(historyItem) == false)
            {
                _countInHistory[historyItem] = 0;
            }
            _countInHistory[historyItem]++;
        }

        foreach (WeightedItem<T> wItem in _contents.getAllItems())
        {
            if(_countInHistory.ContainsKey(wItem.getItem()) == true)
            {
                if(_countInHistory[wItem.getItem()] < _maxInHistory)
                {
                    _currentContents.addItem(wItem);
                }
            }
            else
            {
                _currentContents.addItem(wItem);
            }
        }
    }

    public void setMaxInHistory(int val)
    {
        _maxInHistory = val;
    }

    public void setMaxHistoryLength(int val)
    {
        _maxHistoryLength = val;
    }

    public int getNumElements()
    {
        return _contents.count();
    }
}
