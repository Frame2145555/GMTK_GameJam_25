using UnityEngine;

public enum ItemType
{
    Necklect,
    Card
}
public class Item
{
    private ItemType m_type;
    private UnitStat m_unitRealStat;
    private bool m_fake = false;
    private UnitStat m_unitFakeStat;

    public ItemType Type { get => m_type; }
    public UnitStat Stat
    {
        get
        {
            if (m_fake)
                return m_unitFakeStat;
            return m_unitRealStat;
        }
    }
    public UnitStat RealStat { get => m_unitRealStat; }
    public UnitStat FakeStat { get => m_unitFakeStat; }
    public bool IsFake { get => m_fake; }
    public Item(ItemType type, UnitStat stat)
    {
        m_type = type;
        m_unitRealStat = stat;
        m_fake = false;
        m_unitFakeStat = stat;
    }
    public Item(ItemType type, UnitStat realStat, bool isFake, UnitStat fakeStat)
    {
        m_type = type;
        m_unitRealStat = realStat;
        m_fake = isFake;
        m_unitFakeStat = fakeStat;
    }
}