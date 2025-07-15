using TMPro;
using UnityEngine;

public class Necklace : MonoBehaviour
{
    [SerializeField] TMP_Text job;
    [SerializeField] Item m_item;
    [SerializeField] GameObject rankLogo;
    public Item Item { get => m_item; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        if (!job)
            job = transform.Find("job").GetComponent<TMP_Text>();
        if (!rankLogo)
            rankLogo = transform.Find("ranklogo").gameObject;
    }
    public void SetUp(Item item)
    {
        m_item = item;
        job.text = item.Stat.job.ToString();
        CreateLogo(item.Stat.grade);
    }

    void CreateLogo(UnitGrade grade)
    {
        Transform temp = rankLogo.transform.Find("base");
        temp.gameObject.SetActive(true);
        int value = (int)grade;
        for (int i = 0; i < value * 2 - 1; i++)
        {
            Transform newTemp = Instantiate(temp);
            newTemp.gameObject.SetActive(true);
            newTemp.parent = rankLogo.transform;
        }
    }
}
