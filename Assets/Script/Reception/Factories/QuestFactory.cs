using UnityEngine;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;

public enum ObjectiveCondition
{
    Exact,Greater,Lesser,GreaterEqual,LesserEqual
}

public class QuestFactory : MonoBehaviour
{
    #region Condition Mapping
    private static Dictionary<ObjectiveCondition, Func<UnitStat, UnitStat, bool>> ConditionMap =
        new Dictionary<ObjectiveCondition, Func<UnitStat, UnitStat, bool>>();
    private static bool IsInitialized = false;
    #endregion

    [SerializeField] List<QuestBlueprint> questBlueprints;

    Dictionary<string,QuestBlueprint> questBlueprintsDict = new Dictionary<string, QuestBlueprint>();

    [Header("Preview")]
    [SerializeReference] ObjectiveCondition currentCondition;
    [SerializeReference] Quest questPreview;

    [Header("Config")]
    [SerializeField] int maxObjectiveUnitRequire= 4;

    private void Awake()
    {
        InitializeConditionMap();

        Auxiliary.CheckInspectorNotAssign(questBlueprints);
        ConvertBlueprintListToDict();
    }
    private void InitializeConditionMap()
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
    private void ConvertBlueprintListToDict()
    {
        foreach (var blueprint in questBlueprints)
            questBlueprintsDict.Add(blueprint.info.title, blueprint);
    }


    [ContextMenu("Create Quest")]
    Quest CreatRandomQuestAndPreview()
    {
        questPreview = CreateRandomQuest();
        return questPreview;
    }

    public Quest CreateRandomQuest()
    {
        //Create Random Quest Info
        QuestInfo randInfo = new QuestInfo();
        randInfo.RandomSelf();

        //Create random Objective
        UnitStat randStat = new UnitStat();
        randStat.RandomSelf();

        int randCnt = UnityEngine.Random.Range(1, maxObjectiveUnitRequire);

        Objective randObjective = new Objective(
        randStat,
        currentCondition,
        ConditionMap[currentCondition],
        randCnt);

        return new Quest(randInfo,randObjective);
    }

    public Quest CreateFromBlueprintRandom()
    {
        //random blueprint index
        int idx = UnityEngine.Random.Range(1,questBlueprints.Count);

        return BlueprintToQuest(questBlueprints[idx]);
    }
    public Quest CreateFromBlueprint(string questName)
    {
        return BlueprintToQuest(questBlueprintsDict[questName]);
    }

    Quest BlueprintToQuest(QuestBlueprint blueprint)
    {
        Objective obj = new Objective(blueprint.objective.baseUnitStat,
            blueprint.objective.conditionType,
            ConditionMap[blueprint.objective.conditionType],
            blueprint.objective.requireUnit);

        Quest quest = new Quest(blueprint.info,obj);
        return quest;
    }


    #region Quest Conditions
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
    #endregion
}