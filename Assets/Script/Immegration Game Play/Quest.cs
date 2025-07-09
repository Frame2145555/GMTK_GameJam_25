using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;


[System.Serializable]
public enum QuestRank
{
    Slime, Deer, Hunter, Moose, Dragon, HellHound
}
[System.Serializable]

public struct QuestInfo
{
    public string name;
    public string description;
    public QuestRank rank;
}

[System.Serializable]
public class Quest
{
    [SerializeField] private string m_name;
    [SerializeField] private string m_description;
    [SerializeField] private QuestRank m_level;
    [SerializeField] private List<Objective> m_objective = new List<Objective>();
    [SerializeField] private List<Unit> m_choosenUnit = new List<Unit>();
    [SerializeField] private bool m_success;

    public string Name { get => m_name; }
    public string Description { get => m_description; }
    public QuestRank Level { get => m_level; }
    public List<Objective> Objective { get => m_objective; }
    public List<Unit> ChoosenUnit { get => m_choosenUnit; }

    // [SerializeField] List<UnitStatus> m_minUnitRequirment = new List<UnitStatus>();
    // [SerializeField] List<int> m_minCount = new List<int>();
    // [SerializeField] List<int> m_currentCount = new List<int>();


    public Quest(string name, string description, QuestRank rank)
    {
        m_name = name;
        m_description = description;
        m_success = false;
        m_level = rank;

    }
    public void AddObjective(Objective objective)
    {
        m_objective.Add(objective);
    }
    public void AddUnit(Unit unit)
    {
        m_choosenUnit.Add(unit);
    }
    public void UpdateSuccess(bool success)
    {
        m_success = success;
    }
    public bool CheckSuccess() => m_success;

    // public void AddUnitRequirment(UnitStatus minInfo, int count)
    // {
    //     m_minUnitRequirment.Add(minInfo);
    //     for (int i = 0; i < count; i++)
    //     {
    //         m_minCount.Add(count);
    //         m_currentCount.Add(0);
    //     }
    // }

    // public void CompareRequirment(Unit unit)
    // {
    //     UnitStatus info = unit.Info;

    //     for (int i = 0; i < m_minUnitRequirment.Count; ++i) 
    //     {
    //         UnitStatus minInfo = m_minUnitRequirment[i];

    //         if (info.job == minInfo.job
    //             || info.grade > minInfo.grade
    //             )
    //         {
    //             if (m_currentCount[i] < m_minCount[i])
    //             {
    //                 m_currentCount[i]++;
    //                 return;
    //             }
    //             else
    //             {
    //                 continue;
    //             }
    //         }
    //     }
    // }

    // public bool CheckSuccess()
    // {
    //     bool isSuccess = true;
    //     for (int i = 0; i < m_minUnitRequirment.Count; ++i)
    //     {
    //         isSuccess = isSuccess && m_currentCount[i] >= m_minCount[i];
    //     }
    //     return isSuccess;
    // }

}
