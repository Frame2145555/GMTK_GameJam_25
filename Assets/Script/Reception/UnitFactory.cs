using UnityEngine;
using System.Collections.Generic;
using System;

public class UnitFactory : MonoBehaviour
{
    ItemFactory iFac;
    void Start()
    {
        iFac = GetComponent<ItemFactory>();   
    }
    public Unit CreateRandomUnit(Quest quest)
    {
        string randName = GenerateFantasyName();
        UnitStat randStat = new UnitStat();
        randStat.RandomSelf();
        randStat.job = quest.Objectives[0].Requirement.job;
        Unit newUnit = new Unit(randName, randStat, quest);
        // newUnit.AddItem(iFac.CreateRandomItem(newUnit, randStat));
        return newUnit;

    }
    public Unit CreateUnit(Quest quest ,List<Item> items)
    {
        //Read from something
        string[] randomName = { "Pooh", "Paul", "Sky", "Shogun", "Showy", "Kong" };
        string name = randomName[UnityEngine.Random.Range(0, randomName.Length)];

        UnitStat m_unitStatus = new();
        m_unitStatus.RandomSelf();
        Unit unit = new Unit(name, m_unitStatus,quest, items);
        return unit;
    }
    public Unit CreateUnit(UnitStat UnitStat,Quest quest , List<Item> items)
    {
        //Read from something
        string[] randomName = { "Pooh", "Paul", "Sky", "Shogun", "Showy", "Kong" };
        string name = randomName[UnityEngine.Random.Range(0, randomName.Length)];

        Unit unit = new Unit(name, UnitStat,quest, items);
        return unit;
    }

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