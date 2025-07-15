using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour
{
    [SerializeField] Image profile;
    [SerializeField] TMP_Text job;
    [SerializeField] TMP_Text rank;
    [SerializeField] GameObject rankLogo;
    [SerializeField] Item m_item;
    public Item Item { get => m_item; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!profile)
            profile = transform.Find("Image").GetComponent<Image>();
        if (!job)
            job = profile.transform.Find("job").GetComponent<TMP_Text>();
        if (!rank)
            rank = profile.transform.Find("rank").GetComponent<TMP_Text>();
        if (!rankLogo)
            rankLogo = transform.Find("ranklogo").gameObject;
    }
    public void SetUp(Item item)
    {
        m_item = item; 
        job.text = item.Stat.job.ToString();
        rank.text = item.Stat.grade.ToString();
        CreateLogo(item.Stat.grade);
    }
    void CreateLogo(UnitGrade grade)
    {
        Transform temp = rankLogo.transform.Find("base");
        int value = (int)grade + 1;
        for (int i = 0; i < value; i++)
        {
            Transform newTemp = Instantiate(temp);
            newTemp.gameObject.SetActive(true);
            newTemp.parent = rankLogo.transform;
        }
    }
}
