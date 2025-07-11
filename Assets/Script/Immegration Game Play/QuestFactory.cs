using UnityEngine;
using System.Collections.Generic;
using System;

public enum ObjectiveCondition
{
    Exact,Greater,Lesser,GreaterEqual,LesserEqual
}

public class QuestFactory : MonoBehaviour
{
    private static int IdCounter = 0;
    private static Dictionary<ObjectiveCondition, Func<UnitStat, UnitStat, bool>> ConditionMap = 
        new Dictionary<ObjectiveCondition, Func<UnitStat, UnitStat, bool>>();
    private static bool IsInitialized = false;

    [SerializeField] ObjectiveCondition m_currentCondition;
    [SerializeField] Quest m_QuestPreview;

    private void Start()
    {
        if (!IsInitialized)
        {
            ConditionMap[ObjectiveCondition.Exact] = ExactGrade;
            ConditionMap[ObjectiveCondition.Greater] = GreaterGrade;
            ConditionMap[ObjectiveCondition.GreaterEqual] = GreaterEqualGrade;
            ConditionMap[ObjectiveCondition.Lesser] = LesserGrade;
            ConditionMap[ObjectiveCondition.LesserEqual] = LesserEqualGrade;

            IsInitialized = true;
        }
    }
    [ContextMenu("Create Quest")]
    public Quest CreatRandomQuestAndPreview()
    {
        m_QuestPreview = CreateRandomQuest(3);
        return m_QuestPreview;
    }


    public Quest CreateRandomQuest(int maxObjCount)
    {
        //Some function to add quest
        string[] nameArr = { "Get down", "Omae wa mou", "Sky so high", "Raiden Shogun", "Super Idol", "King Kong" };
        int objCnt = UnityEngine.Random.Range(1, maxObjCount+1);
        QuestInfo randInfo = new QuestInfo();
        randInfo.RandomSelf();

        List<Objective> objs = new List<Objective>();

        for (int i = 0; i < objCnt; i++)
        {
            UnitStat randStat = new UnitStat();
            randStat.RandomSelf();
            int randCnt = UnityEngine.Random.Range(1, 4);

            Objective obj = new Objective(
                randStat,
                m_currentCondition,
                ConditionMap[m_currentCondition],
                randCnt);

            objs.Add(obj);
        }

        return new Quest(randInfo, ++IdCounter, objs);
    }

    bool ExactGrade(UnitStat req, UnitStat cmp) =>
        cmp.job == req.job &&
        cmp.grade == req.grade;

    bool GreaterGrade(UnitStat req, UnitStat cmp) =>
        cmp.job == req.job &&
        cmp.grade > req.grade;
    bool GreaterEqualGrade(UnitStat req, UnitStat cmp) =>
        cmp.job == req.job &&
        cmp.grade >= req.grade;

    bool LesserGrade(UnitStat req, UnitStat cmp) =>
        cmp.job == req.job &&
        cmp.grade < req.grade;
    bool LesserEqualGrade(UnitStat req, UnitStat cmp) =>
        cmp.job == req.job &&
        cmp.grade <= req.grade;
}