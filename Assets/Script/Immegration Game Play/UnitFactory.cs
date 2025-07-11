using UnityEngine;
using System.Collections.Generic;
using System;

public class UnitFactory : MonoBehaviour
{
    public Unit CreateUnit()
    {
        return null;
    }
    public Unit CreateRandomUnit()
    {
        string randName = GenerateFantasyName();
        UnitStat randStat = new UnitStat();
        randStat.RandomSelf();

        return new Unit(randName,randStat);

    }
    public Unit CreateUnit(bool isFake, List<GameObject> items)
    {
        //Read from something
        string[] randomName = { "Pooh", "Paul", "Sky", "Shogun", "Showy", "Kong" };
        string name = randomName[UnityEngine.Random.Range(0, randomName.Length)];
        UnitStat m_unitStatus = new();
        m_unitStatus.RandomSelf();
        Unit unit = new Unit(name, m_unitStatus, items, isFake );
        return unit;
    }
    public Unit CreateUnit(UnitStat unitStatus,bool isFake, List<GameObject> items)
    {
        //Read from something
        string[] randomName = { "Pooh", "Paul", "Sky", "Shogun", "Showy", "Kong" };
        string name = randomName[UnityEngine.Random.Range(0, randomName.Length)];
        Unit unit = new Unit(name, unitStatus, items, isFake);
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