using UnityEngine;
using System.Collections.Generic;
using System;
public class ImmigrationManager : MonoBehaviour
{
    [SerializeField] private Quest m_todayQuest;
    [SerializeField] private Queue<Unit> m_todayUnits = new Queue<Unit>();

    [SerializeField] private Unit m_currentUnit;
    [SerializeField] private List<Unit> m_choosenUnit = new List<Unit>();
    public UnitInfo CreateRandomInfo()
    {
        string[] randomName = { "Pooh", "Paul", "Sky", "Shogun", "Showy", "Kong" };

        UnitInfo unitInfo = new UnitInfo();
        unitInfo.name = randomName[UnityEngine.Random.Range(0, randomName.Length)];

        unitInfo.grade = (UnitGrade)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(UnitGrade)).Length);
        unitInfo.job = (UnitJob)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(UnitJob)).Length);
        //write a code that randomized unitInfo struct.
        Debug.Log($"Create UnitInfo Name: {unitInfo.name}, Grade: {unitInfo.grade}, Job: {unitInfo.job}");
        return unitInfo;
    }
    public void GenerateQuest()
    {
        string[] randomName = { "Get down", "Omae wa mou", "Sky so high", "Raiden Shogun", "Super Idol", "King Kong" };
        Quest m_quest = new Quest(randomName[UnityEngine.Random.Range(0, randomName.Length)]);

        m_quest.addUnitRequirment(CreateRandomInfo(), UnityEngine.Random.Range(1, 3));


        m_todayQuest = m_quest;
    }
    public void GenerateUnits()
    {
        UnitInfo m_unitInfo = CreateRandomInfo();
        Unit m_unit = new Unit(m_unitInfo);
        m_todayUnits.Enqueue(m_unit);
    }
    public void GenerateUnits(UnitInfo unitInfo)
    {
        Unit m_unit = new Unit(unitInfo);
        m_todayUnits.Enqueue(m_unit);
    }
    public void nextDay()
    {

    }

    void nextPerson()
    {
        m_currentUnit = m_todayUnits.Dequeue();
    }

    public void accept()
    {
        m_currentUnit.Accept = true;
        m_choosenUnit.Add(m_currentUnit);
        nextPerson();
    }

    public void reject()
    {
        m_currentUnit.Reject = false;
        nextPerson();
    }
}
