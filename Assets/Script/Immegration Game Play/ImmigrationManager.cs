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
    private UnitFactory m_unitFactory = new UnitFactory();
    private QuestFactory m_questFactory = new QuestFactory();
    
    [ContextMenu("Start New Day")]
    public void StartDay()
    {
        m_todayQuest = m_questFactory.CreateQuest();

        int rand = UnityEngine.Random.Range(49, 50);
        for (int i = 0; i < rand; i++)
        {
            m_todayUnits.Enqueue(m_unitFactory.CreateUnit());

        }

        NextPerson();
    }

    [ContextMenu("Submit Quest (End the day)")]
    public void EndDay()
    {
        // foreach (Unit unit in m_acceptedUnit)
        // {
        //     m_todayQuest.CompareRequirment(unit);
        // }

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
    public void Decided(bool accept)
    {
        Unit next = NextPerson();
        if (m_currentUnit != null)
        {
            if (accept)
            {
                m_currentUnit.Accept = true;
                m_acceptedUnit.Add(m_currentUnit);
            }
            else
            {
                m_currentUnit.Reject = false;
                m_rejectedUnit.Add(m_currentUnit);
            }
        }
        m_currentUnit = next;
    }
}
