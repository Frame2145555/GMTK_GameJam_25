using UnityEngine;
using System.Collections.Generic;
using System;

public class QuestFactory : MonoBehaviour
{
    private UnitFactory m_unitFactory = new UnitFactory();
    public Quest CreateQuest()
    {
        //Some function to add quest
        string[] randomName = { "Get down", "Omae wa mou", "Sky so high", "Raiden Shogun", "Super Idol", "King Kong" };
        Quest quest = new Quest(randomName[UnityEngine.Random.Range(0, randomName.Length)], "temp description", CreateRandomQuestRank());


        return quest;
    }
    public QuestRank CreateRandomQuestRank()
    {
        return (QuestRank)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(QuestRank)).Length);
    }
}