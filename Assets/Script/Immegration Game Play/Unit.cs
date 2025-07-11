using UnityEngine;
using System.Collections.Generic;
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

public struct UnitStat
{
    public UnitGrade grade;
    public UnitJob job;

    public void RandomSelf()
    {
        grade = Auxiliary.RandomEnum<UnitGrade>();
        job = Auxiliary.RandomEnum<UnitJob>();
    }
}
/// <summary>
/// Unit class is the data container of a person
/// </summary>
[System.Serializable]
public class Unit
{
    [SerializeField] string m_name;
    [SerializeField] private UnitStat m_stat;
    [SerializeField] private List<GameObject> m_items;

    [SerializeField] private bool m_accept = false;
    [SerializeField] private bool m_reject = false;
    [SerializeField] private bool m_fake = false;
    public Unit(string name, UnitStat status, List<GameObject> items = null, bool isFake = false)
    {
        m_name = name;
        m_stat = status;
        m_fake = isFake;
        m_items = items;
    }
    public string Name { get => m_name; }
    public UnitStat Stat { get => m_stat; }
    public bool Accept { get => m_accept; set => m_accept = value; }
    public bool Reject { get => m_reject; set => m_reject = value; }
    public bool IsFake { get => m_fake; }
    public List<GameObject> Items { get => m_items; }
}
