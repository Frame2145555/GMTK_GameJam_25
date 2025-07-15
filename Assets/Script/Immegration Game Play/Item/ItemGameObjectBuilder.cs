using UnityEngine;

public class ItemGameObjectBuilder : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Card cardPrefab;
    [SerializeField] JobItem jobPrefab;
    [SerializeField] WorldItem worldItemPrefab;
    UnitFactory unitFactory = new UnitFactory();
    void Start()
    {
        
    }
    public void CreateItemGameObject(Item item, Vector2 pos)
    {
        switch (item.Type)
        {
            case ItemType.Card:
                break;
            case ItemType.Job:
                break;
            case ItemType.World:
                break;
            default:
                Debug.LogError("Item Type Not Found");
                break;
        }
    }
    GameObject CreateCard()
    {
        return null;
    }
    GameObject CreateJobItem()
    {
        return null;
    }
    GameObject CreateWorldItem()
    {
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
