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

public struct UnitStatus
{
    public UnitGrade grade;
    public UnitJob job;
}
/// <summary>
/// Unit class is the data container of a person
/// </summary>
[System.Serializable]
public class Unit
{
    [SerializeField] string m_name;
    [SerializeField] private UnitStatus m_status;
    [SerializeField] private bool m_accept;
    [SerializeField] private bool m_reject;
    [SerializeField] private bool m_fake;
    [SerializeField] private List<GameObject> m_items;
    public Unit(string name, UnitStatus status, bool isFake, List<GameObject> items)
    {
        m_name = name;
        m_status = status;
        m_accept = false;
        m_reject = false;
        m_fake = isFake;
        m_items = items;
    }
    public string Name { get => m_name; }
    public UnitStatus Status { get => m_status; }
    public bool Accept { get => m_accept; set => m_accept = value; }
    public bool Reject { get => m_reject; set => m_reject = value; }
    public bool IsFake { get => m_fake; }
    public List<GameObject> Items { get => m_items; }
}
