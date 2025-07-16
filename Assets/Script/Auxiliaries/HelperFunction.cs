using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public static class Auxiliary
{
    public static T RandomEnum<T>()
    {
        var values = System.Enum.GetValues(typeof(T));
        int index = UnityEngine.Random.Range(0, values.Length);
        return (T)values.GetValue(index);
    }
    public static void CheckInspectorNotAssign<T>(T obj)
    {
        if (obj == null) throw new ArgumentNullException(typeof(T).Name + "is not assign in the Inspector.");
    }

    public static Dictionary<TKey,TValue> ListPair2Dictionary<TKey,TValue>(List<Pair<TKey,TValue>> listPair)
    {
        Dictionary<TKey, TValue> kvp = new Dictionary<TKey, TValue>();
        foreach (var pair in listPair) kvp.Add(pair.fst, pair.snd);
        return kvp;
    }
}