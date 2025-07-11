using UnityEngine;

public class CreateItem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Card cardPrefab;
    [SerializeField] Necklace necklacePrefab;
    [SerializeField] Canvas canvas;
    UnitFactory unitFactory = new UnitFactory();
    void Start()
    {
        UnitStatus stat = unitFactory.CreateRandomStatus();
        Item item = new Item(ItemType.Card, stat);
        Card newCard = Instantiate(cardPrefab);
        newCard.transform.parent = canvas.transform;
        newCard.SetUp(item);

        item = new Item(ItemType.Necklect, stat);
        Necklace newNecklace = Instantiate(necklacePrefab);
        newNecklace.transform.parent = canvas.transform;
        newNecklace.SetUp(item);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
