using UnityEngine;

public enum ItemType
{
    Necklect,
    Card
}
public class Item
{
    private ItemType m_type;
    private UnitStatus m_unitRealStat;
    private bool m_fake = false;
    private UnitStatus m_unitFakeStat;

    public ItemType Type { get => m_type; }
    public UnitStatus Stat
    {
        get
        {
            if (m_fake)
                return m_unitFakeStat;
            return m_unitRealStat;
        }
    }
    public UnitStatus RealStat { get => m_unitRealStat; }
    public UnitStatus FakeStat { get => m_unitFakeStat; }
    public bool IsFake { get => m_fake; }
    public Item(ItemType type, UnitStatus stat)
    {
        m_type = type;
        m_unitRealStat = stat;
        m_fake = false;
        m_unitFakeStat = stat;
    }
    public Item(ItemType type, UnitStatus realStat, bool isFake, UnitStatus fakeStat)
    {
        m_type = type;
        m_unitRealStat = realStat;
        m_fake = isFake;
        m_unitFakeStat = fakeStat;
    }
}