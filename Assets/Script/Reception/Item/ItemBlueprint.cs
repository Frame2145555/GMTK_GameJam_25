using UnityEngine;

[CreateAssetMenu(fileName = "NewItemObject", menuName = "ScriptableObject/Item")]
public class ItemBlueprint : ScriptableObject
{
    [Header("For World Item Only")]
    public string Name;
    public UnitGrade stat;
    public Sprite portrait;
}