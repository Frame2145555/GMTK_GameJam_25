using UnityEngine;
using System.Collections.Generic;
using System;
public class Reception : MonoBehaviour
{
    QuestFactory qFac;
    UnitFactory uFac;


    [SerializeField] private Quest m_todayQuest;
    [SerializeField] private Queue<Unit> m_lineUp = new Queue<Unit>();
    [SerializeField] private Unit m_current;

    [SerializeField] private List<Unit> m_acceptUnits = new List<Unit>();
    [SerializeField] private List<Unit> m_rejectedUnits = new List<Unit>();

    [Header("Config")]
    [SerializeField] private int m_unitCount = 10;

    private void Start()
    {
        qFac = GetComponent<QuestFactory>();
        uFac = GetComponent<UnitFactory>();
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
        
        m_current = NextInQueue();
    }

    public void Decide(bool accept)
    {
        if (m_current == null) return;

        if (accept)
        {
            m_current.Accept = true;
            m_acceptUnits.Add(m_current);
        }
        else
        {
            m_current.Reject = true;
            m_rejectedUnits.Add(m_current);

        }

        m_current = NextInQueue();
        
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
