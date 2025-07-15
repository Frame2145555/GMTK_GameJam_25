using UnityEngine;

public enum ItemType
{
    Card,
    Job,
    World
}
public class Item
{
    private Unit owner;
    private ItemType type;
    private string name;
    private UnitStat stat;
    private bool isFake;
    public Unit Owner { get => owner; }
    public ItemType Type { get => type; }
    public string Name { get => name; }
    public UnitStat Stat { get => stat; }
    public bool IsFake { get => isFake; }
    public Item(Unit owner, string name, UnitStat stat, ItemType type)
    {
        this.owner = owner;
        this.name = name;
        this.stat = stat;
        this.type = type;
    }
    public Item(Unit owner, string name, UnitStat stat, ItemType type, bool isFake)
    {
        this.owner = owner;
        this.name = name;
        this.stat = stat;
        this.type = type;
        this.isFake = isFake;
    }
}