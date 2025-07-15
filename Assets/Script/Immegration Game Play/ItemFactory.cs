using UnityEngine;
using System;
using System.Collections.Generic;

public class ItemFactory : MonoBehaviour
{
    [SerializeField] List<Sprite> classSprite = new List<Sprite>();
    [SerializeField] List<string> className = new List<string>();
    Dictionary<string, Sprite> classImagePair = new Dictionary<string, Sprite>();
    public Item CreateItem(Unit owner, string itemName, UnitStat unitStat, ItemType itemType)
    {
        Item new_item = new Item(owner, itemName, unitStat, itemType);
        return new_item;
    }
    void Start()
    {
        for (int i = 0; i < className.Count && i < classSprite.Count; i++)
        {
            if (!classImagePair.ContainsKey(className[i]))
            {
                classImagePair.Add(className[i], classSprite[i]);
            }
            else
            {
                Debug.LogWarning($"Duplicate key found: {className[i]}");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
