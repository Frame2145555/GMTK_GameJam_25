using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class JobItem : MonoBehaviour
{
    [SerializeField] SpriteRenderer m_sprite;
    [SerializeField] Item m_item;
    public Item Item { get => m_item; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        if (!m_sprite)
            Auxiliary.CheckInspectorNotAssign<SpriteRenderer>(m_sprite);
            // m_sprite = transform.Find("Sprite").GetComponent<SpriteRenderer>();
    }
    public void SetUp(Item item, Sprite sprite)
    {
        m_item = item;
        m_sprite.sprite = sprite;
    }

}
