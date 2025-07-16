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
    [SerializeField] public string m_name;
    [SerializeField] public UnitStat m_stat;
    [SerializeField] public List<Item> m_items;

    public Unit(string name, UnitStat status, List<Item> items = null)
    {
        m_name = name;
        m_stat = status;
        m_items = items;
    }
    public string Name { get => m_name; }
    public UnitStat Stat { get => m_stat; }
    public List<Item> Items { get => m_items; }
    public void AddItem(Item item)
    {
        m_items.Add(item);
    }
}
