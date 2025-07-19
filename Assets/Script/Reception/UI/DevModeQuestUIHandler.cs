using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;

// public class DevModeQuestUIHandler : MonoBehaviour
// {
//     [SerializeField] TMP_Text m_title;
//     [SerializeField] TMP_Text m_description;
//     [SerializeField] TMP_Text m_rank;

//     [SerializeField] List<DevModeObjectiveUI> m_objectiveUIs;

//     Quest m_rQuest;

//     public Quest rQuest
//     {
//         set
//         {
//             m_rQuest = value;

//             UpdateTexts();
//         }
//     }

//     private void Awake()
//     {
//         Auxiliary.CheckInspectorNotAssign(m_title);
//         Auxiliary.CheckInspectorNotAssign(m_description);
//         Auxiliary.CheckInspectorNotAssign(m_rank);
//         Auxiliary.CheckInspectorNotAssign(m_objectiveUIs);
//     }

//     private void UpdateTexts()
//     {
//         QuestInfo questInfo = m_rQuest.Info;
//         m_title.text = questInfo.name;
//         m_description.text = questInfo.description;
//         m_rank.text = questInfo.rank.ToString();

//         m_objectiveUIs.ForEach((ui) => ui.gameObject.SetActive(false));

//         int objCount = m_rQuest.Objectives.Count;
//         for (int i = 0; i < objCount; i++)
//         {
//             DevModeObjectiveUI objUI = m_objectiveUIs[i];
//             Objective obj = m_rQuest.Objectives[i];

//             objUI.gameObject.SetActive(true);
//             objUI.gameObject.name = "Objective#" + (1 + i).ToString();

//             objUI.JobText.text = obj.Requirement.job.ToString();
//             objUI.GradeText.text = obj.Requirement.grade.ToString();
//             objUI.CountText.text = obj.RequireUnitCount.ToString();
//         }
//     }
// }
public class DevModeQuestUIHandler : MonoBehaviour
{
    [SerializeField] TMP_Text m_title;
    [SerializeField] TMP_Text m_description;
    [SerializeField] TMP_Text m_job;
    [SerializeField] TMP_Text m_rank;
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

    private void Awake()
    {
        Auxiliary.CheckInspectorNotAssign(m_title);
        Auxiliary.CheckInspectorNotAssign(m_description);
        Auxiliary.CheckInspectorNotAssign(m_rank);
        Auxiliary.CheckInspectorNotAssign(m_job);
        Auxiliary.CheckInspectorNotAssign(m_count);
    }

    private void UpdateTexts()
    {
        QuestInfo questInfo = m_rQuest.Info;
        m_title.text = questInfo.name;
        m_description.text = questInfo.description;
        m_rank.text = questInfo.rank.ToString();
        Objective obj = m_rQuest.Objectives[0];
        m_count.text = $"{obj.AcceptedUnitCount} / {obj.RequireUnitCount}";

        UnitStat stat = obj.Requirement;
        m_job.text = $"{stat.grade} {stat.job}";

    }
    public void Active(bool active)
    {
        Debug.Log($"SetActive {active} ");
        m_title.gameObject.SetActive(active);
        m_description.gameObject.SetActive(active);
        m_rank.gameObject.SetActive(active);
        m_count.gameObject.SetActive(active);
        m_job.gameObject.SetActive(active);
    }
}
