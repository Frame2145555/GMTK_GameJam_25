using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Objective
{
    [SerializeField] private UnitStat baseUnitStat;
    [SerializeField] private ObjectiveCondition conditionType = ObjectiveCondition.GreaterEqual;
    [SerializeField] Func<UnitStat, UnitStat, bool> condition;

    [SerializeField] private int requireUnitCount;
    [SerializeField] private List<Unit> acceptedUnit = new List<Unit>();

    public UnitStat BaseUnitStat { get => baseUnitStat; }
    public ObjectiveCondition ConditionType { get => conditionType; }
    public int RequireUnitCount { get => requireUnitCount; }

    public Objective(UnitStat req, ObjectiveCondition contype, Func<UnitStat, UnitStat, bool> condi, int reqCnt)
    {
        baseUnitStat = req;
        conditionType = contype;
        condition = condi;
        requireUnitCount = reqCnt;
    }

    public bool IsComplete() => requireUnitCount == acceptedUnit.Count;
    public bool TryAdd(Unit unit)
    {
        bool b = condition(baseUnitStat, unit.Stat);
        if (b)
        {
            acceptedUnit.Add(unit);
        }
        return b;
    }

    public int GetAcceptedUnitCount() => acceptedUnit.Count;
    
}