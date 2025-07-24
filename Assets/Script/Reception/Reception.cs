using UnityEngine;
using System.Collections.Generic;
using System;

public class Reception : MonoBehaviour
{
    private GameManager gm;
    [SerializeReference] Unit currentUnit;

    public Action OnNextUnit;

    public Unit CurrentUnit { get => currentUnit; }

    private void Awake()
    {
        gm = FindFirstObjectByType<GameManager>();
        gm.OnDayNext += OnDayNext;
    }
    void Decide(bool decision)
    {
        if (currentUnit == null)
        {
            return;
        }

        if (decision)
        {
            currentUnit.Quest.AddUnit(currentUnit);
            GameData.acceptedUnit.Add(currentUnit);
        }
        else
        {
            GameData.rejectedUnit.Add(currentUnit);
        }

        NextUnit();
    }

    /// <summary>
    /// GetNextUnit warpper for calling Action
    /// </summary>
    void NextUnit()
    {
        currentUnit = GetNextUnit();
        OnNextUnit?.Invoke();
    }
    Unit GetNextUnit()
    {
        //Debug
        //Debug.Log(GameData.units.Count);
        if (GameData.units.Count <= 0)
            return null;
        int index = UnityEngine.Random.Range(0, GameData.units.Count);
        Unit temp = GameData.units[index];
        GameData.units.RemoveAt(index);
        return temp;
    }

    public void Accept() => Decide(true);
    public void Reject() => Decide(false);

    void OnDayNext()
    {
        NextUnit();
    }
}
