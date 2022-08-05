using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterItems
{
    private int _itemsBeforeTrigger;
    private int _itemsAfterTrigger;
    private int _oneItem = 1;

    public void CalculateOneItem()
    {
        _itemsBeforeTrigger += _oneItem;
    }

    public void CalculateAllItems()
    {
        _itemsAfterTrigger = _itemsBeforeTrigger;
    }

    public int GetCountItems()
    {
        return _itemsAfterTrigger;
    }
}
