using UnityEngine;

[System.Serializable]

public enum UnitGrade
{
    G,F,E,D,C,B,A,S,SS,SSS
}
[System.Serializable]

public enum UnitJob
{
    Archer,
    Warrior,
    Mage
}
[System.Serializable]

public struct UnitInfo
{
    public string name;
    public UnitGrade grade;
    public UnitJob job;
}
/// <summary>
/// Unit class is the data container of a person
/// </summary>
[System.Serializable]
public class Unit
{
    [SerializeField] private UnitInfo m_info;
    [SerializeField] private bool m_accept;
    [SerializeField] private bool m_reject;

    public Unit(UnitInfo info)
    {
        m_info = info;
    }

    public UnitInfo Info { get => m_info;}
    public bool Accept { get => m_accept; set => m_accept = value; }
    public bool Reject { get => m_reject; set => m_reject = value; }

}
