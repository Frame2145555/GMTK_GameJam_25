using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour
{
    [SerializeField] SpriteRenderer profile;
    [SerializeField] TMP_Text m_name;
    [SerializeField] TMP_Text m_job;
    [SerializeField] TMP_Text m_grade;
    [SerializeField] Item m_item;
    public Item Item { get => m_item; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!profile)
            profile = transform.Find("Profile").GetComponent<SpriteRenderer>();
        if (!m_job)
            m_job = transform.Find("Job").GetComponent<TMP_Text>();
        if (!m_grade)
            m_grade = transform.Find("Grade").GetComponent<TMP_Text>();
        if (!m_name)
            m_name = transform.Find("Name").GetComponent<TMP_Text>();
    }
    public void SetUp(Item item,Sprite portrait)
    {
        m_item = item;
        m_name.text = item.Owner.Name.ToString();
        m_job.text = item.Stat.job.ToString();
        m_grade.text = item.Stat.grade.ToString();
        profile.sprite = portrait;
    }
}
