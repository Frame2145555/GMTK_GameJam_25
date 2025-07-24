using System;
using UnityEngine;

public enum ItemType
{
    Card,
    Job,
    World
}
[Serializable]
public class Item
{
    [SerializeReference] private Unit owner;
    [SerializeField] ItemType type;
    [SerializeField] private string name;
    [SerializeField] private UnitStat stat;
    [SerializeField] private bool isFake;
    public Unit Owner { get => owner; }
    public ItemType Type { get => type; }
    public string Name { get => name; }
    public UnitStat Stat { get => stat; }
    public bool IsFake { get => isFake; }
    public Item(Unit owner, string name, UnitStat stat, ItemType type, bool isFake = false)
    {
        this.owner = owner;
        this.name = name;
        this.stat = stat;
        this.type = type;
        this.isFake = isFake;
    }
}