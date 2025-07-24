using UnityEngine;
using System.Collections.Generic;
using System;

public class UnitFactory : MonoBehaviour
{
    [SerializeField] ItemFactory itemFactory;
    void Awake()
    {
        Auxiliary.CheckInspectorNotAssign(itemFactory);
    }
    public Unit CreateRandomUnit(Quest quest = null)
    {
        string randName = GenerateFantasyName();
        
        UnitStat randStat = new();
        randStat.RandomSelf();

        Unit newUnit = new(randName, randStat);

        if (quest != null) newUnit.AssignQuest(quest);

        return newUnit;
    }

    public Unit CreateUnit(string name, UnitGrade grade, UnitJob job, Quest quest = null)
    {
        UnitStat stat;
        stat.grade = grade;
        stat.job = job;

        Unit newUnit = new(name, stat);

        if (quest != null) newUnit.AssignQuest(quest);

        return newUnit;
    }

    #region 

    //public Unit CreateUnit(Quest quest, List<Item> items)
    //{
    //    //Read from something
    //    string[] randomName = { "Pooh", "Paul", "Sky", "Shogun", "Showy", "Kong" };
    //    string name = randomName[UnityEngine.Random.Range(0, randomName.Length)];

    //    UnitStat m_unitStatus = new UnitStat();
    //    m_unitStatus.RandomSelf();
    //    while (m_unitStatus.grade > quest.Objectives[0].BaseUnitStat.grade)
    //        m_unitStatus.RandomSelf();
    //    m_unitStatus.job = quest.Objectives[0].BaseUnitStat.job;
    //    Unit unit = new Unit(name, m_unitStatus);
    //    return unit;
    //}
    //public Unit CreateUnit(UnitStat UnitStat, Quest quest)
    //{
    //    //Read from something
    //    string[] randomName = { "Pooh", "Paul", "Sky", "Shogun", "Showy", "Kong" };
    //    string name = randomName[UnityEngine.Random.Range(0, randomName.Length)];

    //    Unit unit = new Unit(name, UnitStat, quest, null);
    //    return unit;
    //}
    //public Unit CreateUnit(UnitStat UnitStat, Quest quest, List<Item> items)
    //{
    //    //Read from something
    //    string[] randomName = { "Pooh", "Paul", "Sky", "Shogun", "Showy", "Kong" };
    //    string name = randomName[UnityEngine.Random.Range(0, randomName.Length)];

    //    Unit unit = new Unit(name, UnitStat, quest, items);
    //    return unit;
    //}
    #endregion

    string GenerateFantasyName()
    {
        string[] surnames = {
            "Aure", "Eldrin", "Faylen", "Thorne", "Silvar",
            "Ashen", "Kael", "Myrr", "Orin", "Zephyr"
        };

        string[] lastNames = {
            "Stormborn", "Dawnbringer", "Nightshade", "Starfall", "Ironheart",
            "Shadowveil", "Emberwind", "Mooncrest", "Brightblade", "Windrider"
        };

        System.Random rand = new System.Random();

        string surname = surnames[rand.Next(surnames.Length)];
        string lastName = lastNames[rand.Next(lastNames.Length)];

        return $"{surname} {lastName}";
    }
}