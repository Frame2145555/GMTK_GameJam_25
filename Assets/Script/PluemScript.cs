using UnityEngine;

public class PluemScript : MonoBehaviour
{
    [Header("this script is for Pluem. Dont touch this!!!!!!!!!!!!!!!")]
    ItemGameObjectBuilder itemGame;
    [SerializeField] Item item;
    void Start()
    {
        itemGame = GetComponent<ItemGameObjectBuilder>();
        
        itemGame.CreateItemGameObject(item);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
