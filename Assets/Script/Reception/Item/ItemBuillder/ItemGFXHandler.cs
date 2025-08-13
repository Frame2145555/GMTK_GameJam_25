using System.Collections.Generic;
using UnityEngine;

public class ItemGFXHandler : MonoBehaviour
{
    [SerializeField] Transform itemAreaCenter;
    [SerializeField] List<Transform> itemPosition = new List<Transform>();
    float width, height;
    List<GameObject> m_items = new List<GameObject>();
    public List<GameObject> Items
    {
        set
        {
            foreach (GameObject Object in m_items)
            {
                Destroy(Object);
            }
            m_items = value;
            for (int i = 0; i < m_items.Count; i++)
            {
                m_items[i].transform.parent = itemAreaCenter;
                m_items[i].transform.position = itemPosition[i].position;
            }
        }
    }
    [SerializeField] float tolerance = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(itemAreaCenter.position, new Vector3(width, height));

    }
    public Vector2 GetRandomPosition()
    {
        MinMaxFloat minMaxWidth = new MinMaxFloat(-1 * width / 2.5f + tolerance, width / 2.5f - tolerance);
        MinMaxFloat minMaxHeight = new MinMaxFloat(-1 * height / 2.5f + tolerance, height / 2.5f - tolerance);
        Vector2 pos = new Vector2(
            minMaxHeight.Roll(),
            minMaxWidth.Roll());
        return itemAreaCenter.position + (Vector3)pos;
    }
}
