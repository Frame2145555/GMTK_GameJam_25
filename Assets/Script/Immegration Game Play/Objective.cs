using UnityEngine;
[System.Serializable]
public class Objective
{
    private UnitStatus m_requirements;
    private bool m_predicate;
    private int m_requireUnitCount;
    private int m_acceptedUnitCount;
    public bool CheckUnit(Unit unit)
    {
        return false;
    }
    public bool IsFull()
    {
        return m_acceptedUnitCount == m_acceptedUnitCount;
    }
}