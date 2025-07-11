using System;
using UnityEngine;

[System.Serializable]
public class Objective
{
    [SerializeField] private UnitStat m_requirement;
    [SerializeField] private ObjectiveCondition m_conditionType;
    [SerializeField] Func<UnitStat,UnitStat,bool> m_condition;

    [SerializeField] private int m_requireUnitCount;
    [SerializeField] private int m_acceptedUnitCount = 0;

    public Objective(UnitStat req, ObjectiveCondition contype, Func<UnitStat, UnitStat, bool> condi, int reqCnt)
    {
        m_requirement = req;
        m_conditionType = contype;
        m_condition = condi;
        m_requireUnitCount = reqCnt;
    }

    public bool IsComplete() => m_requireUnitCount == m_acceptedUnitCount;
    public bool CheckRequriment(Unit unit)
    {
        bool b = m_condition(m_requirement, unit.Stat);
        if (b) m_acceptedUnitCount++;
        return b;
    }
    public bool IsFull() => m_requireUnitCount == m_acceptedUnitCount;
    
}