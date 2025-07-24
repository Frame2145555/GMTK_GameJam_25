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

    [SerializeField] private string name;
    [SerializeField] private UnitStat stat;
    [SerializeReference] private Quest quest;
    [SerializeReference] private List<Item> items;
    public Unit(string name, UnitStat status)
    {
        this.name = name;
        stat = status;
    }
    public string Name { get => name; }
    public UnitStat Stat { get => stat; set => stat = value; }
    public List<Item> Items { get => items; }
    public Quest Quest{ get => quest; }
    public void AssignQuest(Quest quest) => this.quest = quest;
    public void AddItem(Item item) => items.Add(item);
    
}
