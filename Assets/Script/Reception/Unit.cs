using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
[System.Serializable]

public enum UnitGrade
{
    G, F, E, D, C, B, A, S, SS, SSS
}

[System.Serializable]
public enum UnitJob
{
    Fighter,
    Ranger,
    Mage,
    Cleric
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
    [SerializeField] private string m_name;
    [SerializeField] private UnitStat m_stat;
    [SerializeField] private List<Item> m_items = new List<Item>();
    [SerializeField] private Quest m_quest;
    public Unit(string name, UnitStat status, Quest quest, List<Item> items = null)
    {
        m_name = name;
        m_stat = status;
        m_items = items;
        m_quest = quest;
    }
    public string Name { get => m_name; }
    public UnitStat Stat { get => m_stat; }
    public List<Item> Items { get => m_items; }
    public Quest Quest{ get => m_quest; }
    public void AddItem(Item item)
    {
        m_items.Add(item);
    }
}
