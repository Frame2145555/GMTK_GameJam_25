using System;
using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    UnitFactory unitFactory;
    QuestFactory questFactory;
    ItemFactory itemFactory;

    [Header("Config")]
    [SerializeField] int questCount = 2;
    [SerializeField] int extraUnit = 3;

    public Action OnDayStart;
    public Action OnDayEnd;
    public Action OnDayNext;

    private void Awake()
    {
        GetWorldItemData();
        unitFactory = GetComponent<UnitFactory>();
        questFactory = GetComponent<QuestFactory>();
        itemFactory = GetComponent<ItemFactory>();
    }
    public void DayStart()
    {
        Debug.Log("Start the day");
        OnDayStart?.Invoke();
    }
    public void DayEnd()
    {
        Debug.Log("End the day");
        CheckQuestsCompletation();
        OnDayEnd?.Invoke();
    }

    public void DayNext()
    {
        GameData.acceptedUnit.Clear();
        GameData.rejectedUnit.Clear();
        GameData.quests.Clear();
        GameData.units.Clear();

        //build quest
        CreateQuests();

        //build units
        CreateUnits();

        OnDayNext?.Invoke();
    }

    private void CreateUnits()
    {
        //build unit base on quest
        foreach (var quest in GameData.quests)
        {
            for (int i = 0; i < questCount; i++)
            {
                Unit newUnit = unitFactory.CreateRandomUnit(quest);
                
                ApplyQuestBaseStat(newUnit, quest);
                GameData.units.Add(newUnit);
            }
        }

        //generate extra unit
        for (int i = 0; i < extraUnit; i++)
        {
            Quest randQuest = GameData.quests[UnityEngine.Random.Range(0, GameData.quests.Count)];
            GameData.units.Add(unitFactory.CreateRandomUnit(randQuest));
        }
    }

    private void CreateQuests()
    {
        for (int i = 0; i < questCount; i++)
        {

            //GameData.quests.Add(questFactory.CreateRandomQuest());

            //Testing
            GameData.quests.Add(questFactory.CreateFromBlueprint("Hatena Yousei"));
        }
    }

    void ApplyQuestBaseStat(Unit unit, Quest quest)
    {
        unit.Stat = quest.Objective.BaseUnitStat;
    }
    void CheckQuestsCompletation()
    {
        GameData.quests.ForEach(quest =>
        {
            Debug.Log(quest.Info.title);
            Debug.Log(quest.IsCompleted());
        });
    }
    void GetWorldItemData()
    {
        GameData.worldItemSO = new List<ItemBlueprint>(Resources.LoadAll<ItemBlueprint>("WorldItem"));
    }
}
