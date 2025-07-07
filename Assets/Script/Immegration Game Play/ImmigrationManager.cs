using UnityEngine;
using System.Collections.Generic;

public class ImmigrationManager : MonoBehaviour
{
    private Quest m_todayQuest;
    private Queue<Unit> m_todayUnits;

    private Unit m_currentUnit;
    private List<Unit> m_choosenUnit;

    public void GenerateQuest()
    {
        Quest m_quest = new Quest(name);
        m_todayQuest = m_quest;
    }
    public void GenerateUnits()
    {

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
        m_choosenUnit.Add(m_currentUnit);
        nextPerson();
    }

    public void reject()
    {
        nextPerson();
    }
}
