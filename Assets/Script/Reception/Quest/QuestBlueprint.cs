using UnityEngine;

[System.Serializable]       
public struct ObjectiveBlueprint
{
    public UnitStat baseUnitStat;
    public ObjectiveCondition conditionType;
    public int requireUnit;
}

[CreateAssetMenu(fileName = "NewQuestObject", menuName = "ScriptableObject/Quest")]
public class QuestBlueprint : ScriptableObject
{
    public QuestInfo info;
    public ObjectiveBlueprint objective;
}
