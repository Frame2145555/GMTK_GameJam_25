using UnityEngine;
using System.Collections.Generic;
using System;
public struct ItemPortrait
{
    public Sprite portrait;
    public UnitJob job;
    public string name;
}
public class ItemGameObjectBuilder : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Prefab")]
    [SerializeField] Card cardPrefab;
    [SerializeField] JobItem jobItemPrefab;
    [SerializeField] WorldItem worldItemPrefab;
    [Header("Card Item (the Name Parameter is not being used)")]
    [SerializeField] List<ItemPortrait> cardItem = new List<ItemPortrait>();
    Dictionary<UnitJob, Sprite> cardItemDict = new Dictionary<UnitJob, Sprite>();
    [Header("Job Item (All Parameter is being used)")]
    [SerializeField] List<ItemPortrait> jobItem = new List<ItemPortrait>();
    Dictionary<UnitJob, Dictionary<string, Sprite>> jobItemDict = new Dictionary<UnitJob, Dictionary<string, Sprite>>();

    [Header("World Item (the job Parameter is being used)")]
    [SerializeField] List<ItemPortrait> worldItem = new List<ItemPortrait>();
    Dictionary<string, Sprite> worldItemDict = new Dictionary<string, Sprite>();
    void Start()
    {
        //Card Portrait
        for (int i = 0; i < cardItem.Count; i++)
        {
            if (!cardItemDict.ContainsKey(cardItem[i].job))
            {
                cardItemDict.Add(cardItem[i].job, cardItem[i].portrait);
            }
            else
            {
                Debug.LogWarning($"Duplicate key found: {cardItem[i].job}");
            }
        }

        //Job Item Sprite
        foreach (UnitJob job in Enum.GetValues(typeof(UnitJob)))
        {
            Dictionary<string, Sprite> tempDict = new Dictionary<string, Sprite>();
            for (int i = 0; i < jobItem.Count; i++)
            {
                if (!jobItemDict.ContainsKey(job) && !tempDict.ContainsKey(jobItem[i].name) && jobItem[i].job == job)
                {
                    tempDict.Add(jobItem[i].name, jobItem[i].portrait);
                }
                else
                {
                    Debug.LogWarning($"Duplicate key found: {jobItem[i].portrait}");
                }
            }
            jobItemDict.Add(job, tempDict);
        }

        //World item Sprite
        for (int i = 0; i < worldItem.Count; i++)
        {
            if (!worldItemDict.ContainsKey(worldItem[i].name))
            {
                worldItemDict.Add(worldItem[i].name, worldItem[i].portrait);
            }
            else
            {
                Debug.LogWarning($"Duplicate key found: {worldItem[i].name}");
            }
        }
    }
    public void CreateItemGameObject(Item item, Vector2 pos)
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
        newObject.transform.position = pos;
    }
    GameObject CreateCard(Item item)
    {
        GameObject newObject = Instantiate(cardPrefab).gameObject;

        newObject.GetComponent<Card>().SetUp(item,cardItemDict[item.Owner.Stat.job]);
        return newObject; 
    }
    GameObject CreateJobItem(Item item)
    {
        GameObject newObject = Instantiate(jobItemPrefab).gameObject;

        newObject.GetComponent<JobItem>().SetUp(item, jobItemDict[item.Owner.Stat.job][item.Name]);
        return newObject; 
    }
    GameObject CreateWorldItem(Item item)
    {
        GameObject newObject = Instantiate(worldItemPrefab).gameObject;

        newObject.GetComponent<WorldItem>().SetUp(item,worldItemDict[item.Name]);
        return newObject; 
    }
}
