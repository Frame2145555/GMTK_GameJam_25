using UnityEngine;
using System.Collections.Generic;
using System;
public class ImmigrationManager : MonoBehaviour
{
    [SerializeField] private Quest m_todayQuest;
    [SerializeField] private Queue<Unit> m_todayUnits = new Queue<Unit>();

    [SerializeField] private Unit m_currentUnit;
    [SerializeField] private List<Unit> m_acceptedUnit = new List<Unit>();
    [SerializeField] private List<Unit> m_rejectedUnit = new List<Unit>();
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
    public Quest CreateRandomQuest()
    {
        string[] randomName = { "Get down", "Omae wa mou", "Sky so high", "Raiden Shogun", "Super Idol", "King Kong" };
        Quest quest = new Quest(randomName[UnityEngine.Random.Range(0, randomName.Length)]);

        quest.AddUnitRequirment(CreateRandomInfo(), UnityEngine.Random.Range(1, 3));

        return quest;
    }
    public Unit CreateRandomUnit()
    {
        UnitInfo m_unitInfo = CreateRandomInfo();
        Unit unit = new Unit(m_unitInfo);
        return unit;
    }
    public Unit CreateRandomUnit(UnitInfo unitInfo)
    {
        Unit unit = new Unit(unitInfo);
        return unit;
    }

    [ContextMenu("Start New Day")]
    public void StartDay()
    {
        m_todayQuest = CreateRandomQuest();

        int rand = UnityEngine.Random.Range(49, 50);
        for (int i = 0; i < rand; i++)
        {
            m_todayUnits.Enqueue(CreateRandomUnit());

        }

        NextPerson();
    }

    [ContextMenu("Submit Quest (End the day)")]
    public void EndDay()
    {
        foreach (Unit unit in m_acceptedUnit)
        {
            m_todayQuest.CompareRequirment(unit);
        }

        bool isSuccess = m_todayQuest.CheckSuccess();

        if (isSuccess)
        {
            Debug.Log("Quest Success!");
        }
        else
        {
            Debug.Log("Quest Failed!");
        }
    }

    Unit NextPerson()
    {
        return m_todayUnits.Count == 0 ? null : m_todayUnits.Dequeue();
    }

    [ContextMenu("accept")]
    public void Accept()
    {
        Unit next = NextPerson();
        if (m_currentUnit != null)
        {
            m_currentUnit.Accept = true;
            m_acceptedUnit.Add(m_currentUnit);
        }

        m_currentUnit = next;
    }

    [ContextMenu("reject")]
    public void Reject()
    {
        Unit next = NextPerson();
        if (m_currentUnit != null)
        {
            m_currentUnit.Reject = false;
            m_rejectedUnit.Add(m_currentUnit);
        }

        m_currentUnit = next;
    }
}
