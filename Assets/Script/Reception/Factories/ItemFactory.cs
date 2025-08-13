using UnityEngine;
using System;
using System.Collections.Generic;

public class ItemFactory : MonoBehaviour
{
    [SerializeField] int m_randomCardStatChange = 4;
    [SerializeField] int m_randomJobItemStatChange = 10;
    [SerializeField] int m_randomWorldItemStatChange = 10;
    [SerializeField] List<Pair<UnitJob, string>> jobNamePair;
    Dictionary<UnitJob, string> JobNamePair = new Dictionary<UnitJob, string>();
    [SerializeField] List<string> worldItemName = new List<string>();
    void Start()
    {
        Auxiliary.CheckInspectorNotAssign(jobNamePair);
        JobNamePair = Auxiliary.ListPair2Dictionary(jobNamePair);
    }
    public List<Item> CreateUnitItem(Unit owner)
    {
        List<Item> op = new List<Item>();
        Item card = CreateCardItem(owner);
        if (card != null)
            op.Add(card);
        Item job = CreateJobItem(owner);
        if (job != null)
            op.Add(job);
        // Item world = CreateWorldItem(owner);
        // if (world != null)
        //     op.Add(world);

        return op;
    }
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
            isFake = !(owner.Stat.grade >= stat.grade && owner.Stat.job == stat.job);
        }
        else
        {
            isFake = owner.Stat.job != stat.job;
        }
        return new Item(owner, name, stat, type, isFake);
    }
    public Item CreateCardItem(Unit owner)
    {
        string name = $"{owner.Name} 's Card";
        UnitStat stat = owner.Stat;

        //random stat
        if (UnityEngine.Random.Range(0, m_randomCardStatChange) == 0)
        {
            stat.grade = Auxiliary.RandomEnumLessThan(stat.grade);
            Debug.Log($"Create new Stat Card : {stat.grade.ToString()}");
        }
        return new Item(owner, name, stat, ItemType.Card);
    }
    public Item CreateJobItem(Unit owner)
    {
        string name = $"{JobNamePair[owner.Stat.job]}";
        UnitStat stat = owner.Stat;
        bool isFake = false;
        if (UnityEngine.Random.Range(0, m_randomJobItemStatChange) == 0)
        {
            stat.job = Auxiliary.RandomEnum<UnitJob>();
            isFake = true;
            Debug.Log($"Create new Stat Job Item : {stat.grade.ToString()}");
        }
        return new Item(owner, name, stat, ItemType.Job, isFake);
    }
    public Item CreateWorldItem(Unit owner)
    {
        List<ItemBlueprint> allWorldItem = GameData.worldItemSO;

        UnitStat stat = owner.Stat;
        if (UnityEngine.Random.Range(0, m_randomWorldItemStatChange) == 0)
        {
            stat.grade = Auxiliary.RandomEnum<UnitGrade>();
            Debug.Log($"Create new Stat World Item : {stat.grade.ToString()}");
        }
        Auxiliary.Shuffle(allWorldItem);
        foreach (ItemBlueprint i in allWorldItem)
        {
            if (i.stat <= stat.grade)
            {
                stat.grade = i.stat;
                return new Item(owner, i.Name, stat, ItemType.World);
            }
        }
        return null;

    }
}
