using UnityEngine;
using System.Collections.Generic;
public class ItemGameObjectBuilder : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Prefab")]
    [SerializeField] Card cardPrefab;
    [SerializeField] JobItem jobItemPrefab;
    [SerializeField] WorldItem worldItemPrefab;
    [Header("Card Item")]
    [SerializeField] List<Sprite> cardPortrait = new List<Sprite>();
    [SerializeField] List<UnitJob> cardJobName = new List<UnitJob>();
    Dictionary<UnitJob, Sprite> cardPortraitDict = new Dictionary<UnitJob, Sprite>();
    [Header("Job Item")]
    [SerializeField] List<UnitJob> job = new List<UnitJob>();
    [SerializeField] List<Sprite> jobSprite = new List<Sprite>();
    Dictionary<UnitJob, Sprite> jobItemDict = new Dictionary<UnitJob, Sprite>();

    [Header("World Item")]
    [SerializeField] List<string> itemName = new List<string>();
    [SerializeField] List<Sprite> itemSprite = new List<Sprite>();
    Dictionary<string, Sprite> worldItemDict = new Dictionary<string, Sprite>();
    void Start()
    {
        //Card Portrait
        for (int i = 0; i < cardJobName.Count && i < cardPortrait.Count; i++)
        {
            if (!cardPortraitDict.ContainsKey(cardJobName[i]))
            {
                cardPortraitDict.Add(cardJobName[i], cardPortrait[i]);
            }
            else
            {
                Debug.LogWarning($"Duplicate key found: {cardJobName[i]}");
            }
        }

        //Job Item Sprite
        for (int i = 0; i < job.Count && i < jobSprite.Count; i++)
        {
            if (!jobItemDict.ContainsKey(job[i]))
            {
                jobItemDict.Add(job[i], jobSprite[i]);
            }
            else
            {
                Debug.LogWarning($"Duplicate key found: {job[i]}");
            }
        }
        //World item Sprite
        for (int i = 0; i < itemName.Count && i < itemSprite.Count; i++)
        {
            if (!worldItemDict.ContainsKey(itemName[i]))
            {
                worldItemDict.Add(itemName[i], itemSprite[i]);
            }
            else
            {
                Debug.LogWarning($"Duplicate key found: {itemName[i]}");
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

        newObject.GetComponent<Card>().SetUp(item,cardPortraitDict[item.Owner.Stat.job]);
        return newObject; 
    }
    GameObject CreateJobItem(Item item)
    {
        GameObject newObject = Instantiate(jobItemPrefab).gameObject;

        newObject.GetComponent<JobItem>().SetUp(item, jobItemDict[item.Owner.Stat.job]);
        return newObject; 
    }
    GameObject CreateWorldItem(Item item)
    {
        GameObject newObject = Instantiate(worldItemPrefab).gameObject;

        newObject.GetComponent<WorldItem>().SetUp(item,worldItemDict[item.Name]);
        return newObject; 
    }
}
