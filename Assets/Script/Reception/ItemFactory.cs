using UnityEngine;
using System;
using System.Collections.Generic;

public class ItemFactory : MonoBehaviour
{
    
    public Item CreateItem(Unit owner, string itemName, UnitStat unitStat, ItemType itemType, bool isFake = false)
    {
        Item new_item = new Item(owner, itemName, unitStat, itemType, isFake);
        // owner.AddItem(new_item);
        return new_item;
    }
    public Item CreateRandomItem(Unit owner, UnitStat stat, bool isFake = false)
    {
        
        string[] randomName = { "Pooh", "Paul", "Sky", "Shogun", "Showy", "Kong" };
        string name = randomName[UnityEngine.Random.Range(0, randomName.Length)];
        ItemType type = Auxiliary.RandomEnum<ItemType>();
        if (type == ItemType.World)
        {
            isFake = owner.Stat.grade >= stat.grade && owner.Stat.job == stat.job;
        }
        else
        {
            isFake = owner.Stat.job == stat.job;
        }
        return new Item(owner, name, stat, type, isFake);
    }
}
