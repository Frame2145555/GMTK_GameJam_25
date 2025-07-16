using UnityEngine;
using System;
using System.Collections.Generic;

public class ItemFactory : MonoBehaviour
{
    
    public Item CreateItem(Unit owner, string itemName, UnitStat unitStat, ItemType itemType)
    {
        Item new_item = new Item(owner, itemName, unitStat, itemType);
        return new_item;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
