using UnityEngine;
using System.Collections.Generic;
using System;
public class Reception : MonoBehaviour
{
    QuestFactory qFac;
    UnitFactory uFac;
    ItemFactory iFac;

    [SerializeField] private Quest m_todayQuest;
    [SerializeField] private Queue<Unit> m_lineUp = new Queue<Unit>();
    [SerializeField] private Unit m_currentUnit;

    [SerializeField] private List<Unit> m_acceptUnits = new List<Unit>();
    [SerializeField] private List<Unit> m_rejectedUnits = new List<Unit>();

    [Header("Config")]
    [SerializeField] private int m_unitCount = 10;

    public Action OnDayNext;
    public Action OnQueueNext;

    public Unit CurrentUnit { 
        get
        {
            // Debug
            // String s = m_currentUnit.Name + "/"
            //     + m_currentUnit.Stat.job.ToString() + "/"
            //     + m_currentUnit.Stat.grade.ToString() + "/";
            // Debug.Log(s);
            return m_currentUnit;
        }
        private set
        {
            m_currentUnit = value;
            OnQueueNext?.Invoke();
        }
    }

    public Quest TodayQuest { get => m_todayQuest; }
    private void Start()
    {
        qFac = GetComponent<QuestFactory>();
        uFac = GetComponent<UnitFactory>();
        iFac = GetComponent<ItemFactory>();
    }
    [ContextMenu("Next Day")]
    public void NextDay()
    {
        if (m_todayQuest != null)
        {
            string logSuccess = m_todayQuest.ConfirmQuest(m_acceptUnits)? "Quest Success!" : "Quest Failed...";
            Debug.Log(logSuccess);
        }

        m_lineUp.Clear();
        m_acceptUnits.Clear();
        m_rejectedUnits.Clear();

        //create quest
        m_todayQuest = qFac.CreateRandomQuest(3);
        //create units base upon quest
        for (int i = 0; i < m_unitCount; i++)
        {
            m_lineUp.Enqueue(uFac.CreateRandomUnit());
        }

        CurrentUnit = NextInQueue();

        OnDayNext?.Invoke();
    }

    public void Decide(bool accept)
    {
        if (m_currentUnit == null) return;

        if (accept)
        {
            m_acceptUnits.Add(m_currentUnit);
        }
        else
        {
            m_rejectedUnits.Add(m_currentUnit);
        }

        CurrentUnit = NextInQueue();
    }

    [ContextMenu("Accept")]
    public void Accept() => Decide(true);

    [ContextMenu("Reject")]
    public void Reject() => Decide(false);

    Unit NextInQueue()
    {
        return m_lineUp.Count > 0 ? m_lineUp.Dequeue() : null;
    }



}
