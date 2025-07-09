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
    [SerializeField] List<UnitInfo> m_minUnitRequirment = new List<UnitInfo>();
    [SerializeField] List<int> m_minCount = new List<int>();
    [SerializeField] List<int> m_currentCount = new List<int>();


    public Quest(string name)
    {
        m_name = name;
    }

    public void AddUnitRequirment(UnitInfo minInfo, int count)
    {
        m_minUnitRequirment.Add(minInfo);
        for (int i = 0; i < count; i++)
        {
            m_minCount.Add(count);
            m_currentCount.Add(0);
        }
    }

    public void CompareRequirment(Unit unit)
    {
        UnitInfo info = unit.Info;

        for (int i = 0; i < m_minUnitRequirment.Count; ++i) 
        {
            UnitInfo minInfo = m_minUnitRequirment[i];

            if (info.job == minInfo.job
                || info.grade > minInfo.grade
                )
            {
                if (m_currentCount[i] < m_minCount[i])
                {
                    m_currentCount[i]++;
                    return;
                }
                else
                {
                    continue;
                }
            }
        }
    }

    public bool CheckSuccess()
    {
        bool isSuccess = true;
        for (int i = 0; i < m_minUnitRequirment.Count; ++i)
        {
            isSuccess = isSuccess && m_currentCount[i] >= m_minCount[i];
        }
        return isSuccess;
    }

}
