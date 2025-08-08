using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
[Serializable]
public struct ItemPortrait
{
    public string name;
    public UnitJob job;
    public Sprite realPortrait;
    public List<Sprite> fakePortrait;
}
public class ItemGameObjectBuilder : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] Card cardPrefab;
    [SerializeField] JobItem jobItemPrefab;
    [SerializeField] WorldItem worldItemPrefab;
    [Header("Card Item (the Name Parameter isn't being used)")]
    [SerializeField] List<ItemPortrait> cardItem = new List<ItemPortrait>();
    Dictionary<UnitJob, Sprite> cardItemDict = new Dictionary<UnitJob, Sprite>();
    [Header("Job Item (All Parameter is being used)")]
    [SerializeField] List<ItemPortrait> jobItem = new List<ItemPortrait>();
    Dictionary<UnitJob, Dictionary<string, Sprite>> jobItemDict = new Dictionary<UnitJob, Dictionary<string, Sprite>>();

    [Header("World Item (the job Parameter isn't being used)")]
    [SerializeField] List<ItemPortrait> worldItem = new List<ItemPortrait>();
    Dictionary<string, Sprite> worldItemDict = new Dictionary<string, Sprite>();
    void Start()
    {
        Auxiliary.CheckInspectorNotAssign(cardPrefab);
        Auxiliary.CheckInspectorNotAssign(jobItemPrefab);
        Auxiliary.CheckInspectorNotAssign(worldItemPrefab);

        //Card Portrait
        // for (int i = 0; i < cardItem.Count; i++)
        // {
        //     if (!cardItemDict.ContainsKey(cardItem[i].job))
        //     {
        //         cardItemDict.Add(cardItem[i].job, cardItem[i].portrait);
        //     }
        //     else
        //     {
        //         Debug.LogWarning($"Duplicate key found: {cardItem[i].job}");
        //     }
        // }

        // //Job Item Sprite
        // foreach (UnitJob job in Enum.GetValues(typeof(UnitJob)))
        // {
        //     Dictionary<string, Sprite> tempDict = new Dictionary<string, Sprite>();
        //     for (int i = 0; i < jobItem.Count; i++)
        //     {
        //         if (!jobItemDict.ContainsKey(job) && !tempDict.ContainsKey(jobItem[i].name) && jobItem[i].job == job)
        //         {
        //             tempDict.Add(jobItem[i].name, jobItem[i].portrait);
        //         }
        //         else
        //         {
        //             Debug.LogWarning($"Duplicate key found: {jobItem[i].portrait}");
        //         }
        //     }
        //     jobItemDict.Add(job, tempDict);
        // }

        // //World item Sprite
        // for (int i = 0; i < worldItem.Count; i++)
        // {
        //     if (!worldItemDict.ContainsKey(worldItem[i].name))
        //     {
        //         worldItemDict.Add(worldItem[i].name, worldItem[i].portrait);
        //     }
        //     else
        //     {
        //         Debug.LogWarning($"Duplicate key found: {worldItem[i].name}");
        //     }
        // }
    }
    Sprite GetPortrait(Item item)
    {
        switch (item.Type)
        {
            case ItemType.Card:
                return GetCardPortrait(item);
            case ItemType.Job:
                return GetJobItemPortrait(item);
            case ItemType.World:
                return GetWorldItemPortrait(item);
        }

        return null;
    }
    Sprite GetCardPortrait(Item item)
    {
        foreach (ItemPortrait p in cardItem)
        {
            if (p.job == item.Stat.job)
            {
                if (item.IsFake)
                    return p.fakePortrait[UnityEngine.Random.Range(0, p.fakePortrait.Count)];
                return p.realPortrait;
            }
        }
        Debug.LogError($"Can not find {item.Stat.job} image");
        return null;
    }
    Sprite GetJobItemPortrait(Item item)
    {
        foreach (ItemPortrait p in jobItem)
        {
            if (p.job == item.Stat.job && p.name == item.Name)
            {
                if (item.IsFake)
                    return p.fakePortrait[UnityEngine.Random.Range(0, p.fakePortrait.Count)];
                return p.realPortrait;
            }
        }
        Debug.LogError($"Can not find {item.Name} {item.Stat.job} image");
        return null;
    }
    Sprite GetWorldItemPortrait(Item item)
    {
        List<ItemBlueprint> allWorldItem = GameData.worldItemSO;
        foreach (ItemBlueprint p in allWorldItem)
        {
            if (p.name == item.Name)
            {
                return p.portrait;
            }
        }
        Debug.LogError($"Can not find {item.Name} image");
        return null;
    }
    public GameObject CreateItemGameObject(Item item)
    {
        GameObject newObject = null;
        switch (item.Type)
        {
            case ItemType.Card:
                newObject = CreateCard(item);
                break;
            case ItemType.Job:
                newObject = CreateJobItem(item);
                break;
            case ItemType.World:
                newObject = CreateWorldItem(item);
                break;
            default:
                Debug.LogError("Item Type Not Found");
                break;
        }
        return newObject;
    }
    GameObject CreateCard(Item item)
    {
        GameObject newObject = Instantiate(cardPrefab).gameObject;

        newObject.GetComponent<Card>().SetUp(item,GetPortrait(item));
        return newObject; 
    }
    GameObject CreateJobItem(Item item)
    {
        GameObject newObject = Instantiate(jobItemPrefab).gameObject;

        newObject.GetComponent<JobItem>().SetUp(item, GetPortrait(item));
        return newObject; 
    }
    GameObject CreateWorldItem(Item item)
    {
        GameObject newObject = Instantiate(worldItemPrefab).gameObject;

        newObject.GetComponent<WorldItem>().SetUp(item,GetPortrait(item));
        return newObject; 
    }
}
