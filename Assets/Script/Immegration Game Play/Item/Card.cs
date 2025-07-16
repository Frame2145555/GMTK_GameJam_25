using System;
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
            Auxiliary.CheckInspectorNotAssign<SpriteRenderer>(profile);
        if (!m_job)
            Auxiliary.CheckInspectorNotAssign<TMP_Text>(m_job);
        if (!m_grade)
            Auxiliary.CheckInspectorNotAssign<TMP_Text>(m_grade);
        if (!m_name)
            Auxiliary.CheckInspectorNotAssign<TMP_Text>(m_name);
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
