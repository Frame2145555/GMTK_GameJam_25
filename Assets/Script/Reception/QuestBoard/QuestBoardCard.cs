using UnityEngine;
using TMPro;
public class QuestBoardCard : MonoBehaviour
{
    [SerializeField] TMP_Text title;
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text job;
    [SerializeField] TMP_Text rank;
    [SerializeField] TMP_Text m_count;
    // [SerializeField] List<DevModeObjectiveUI> m_objectiveUIs;

    Quest m_rQuest;
    public Quest rQuest
    {
        set
        {
            m_rQuest = value;

            UpdateTexts();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateTexts()
    {
        QuestInfo questInfo = m_rQuest.Info;
        title.text = questInfo.title;
        description.text = questInfo.description;
        rank.text = questInfo.rank.ToString();
        Objective obj = m_rQuest.Objective;
        m_count.text = $"{obj.GetAcceptedUnitCount()} / {obj.RequireUnitCount}";

        UnitStat stat = obj.BaseUnitStat;
        job.text = $"{stat.grade} {stat.job}";

    }
    
}
