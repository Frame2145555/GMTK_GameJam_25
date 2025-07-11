using UnityEngine;
using System.Collections.Generic;
using System;

public class UnitFactory : MonoBehaviour
{
    public Unit CreateUnit()
    {
        return null;
    }
    public Unit CreateUnit(bool isFake, List<GameObject> items)
    {
        //Read from something
        string[] randomName = { "Pooh", "Paul", "Sky", "Shogun", "Showy", "Kong" };
        string name = randomName[UnityEngine.Random.Range(0, randomName.Length)];
        UnitStatus m_unitStatus = CreateRandomStatus();
        Unit unit = new Unit(name, m_unitStatus, isFake, items);
        return unit;
    }
    public Unit CreateUnit(UnitStatus unitStatus,bool isFake, List<GameObject> items)
    {
        //Read from something
        string[] randomName = { "Pooh", "Paul", "Sky", "Shogun", "Showy", "Kong" };
        string name = randomName[UnityEngine.Random.Range(0, randomName.Length)];
        Unit unit = new Unit(name, unitStatus, isFake, items);
        return unit;
    }
    public UnitStatus CreateRandomStatus()
    {
        UnitStatus unitStatus = new UnitStatus();

        unitStatus.grade = (UnitGrade)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(UnitGrade)).Length);
        unitStatus.job = (UnitJob)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(UnitJob)).Length);

        //write a code that randomized UnitStatus struct.
        Debug.Log($"Create UnitStatus Name: , Grade: {unitStatus.grade}, Job: {unitStatus.job}");
        return unitStatus;
    }
}