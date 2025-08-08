using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

public static class Auxiliary
{
    public static T RandomEnum<T>()
    {
        var values = System.Enum.GetValues(typeof(T));
        int index = UnityEngine.Random.Range(0, values.Length);
        return (T)values.GetValue(index);
    }
    public static T RandomEnumLessThan<T>(T current) where T : Enum
    {
        int currentIndex = Convert.ToInt32(current);
        if (currentIndex <= 0) throw new InvalidOperationException("No lower enum values.");

        int randomIndex = UnityEngine.Random.Range(0, currentIndex);
        return (T)Enum.GetValues(typeof(T)).GetValue(randomIndex);
    }
    public static Sprite TextureToSprite(Texture2D texture)
    {
        if (texture == null) return null;

        return Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f)
        );
    }
    public static void CheckInspectorNotAssign<T>(T obj)
    {
        if (obj == null) throw new ArgumentNullException(typeof(T).Name + "is not assign in the Inspector.");
    }

    public static Dictionary<TKey, TValue> ListPair2Dictionary<TKey, TValue>(List<Pair<TKey, TValue>> listPair)
    {
        Dictionary<TKey, TValue> kvp = new Dictionary<TKey, TValue>();
        foreach (var pair in listPair) kvp.Add(pair.fst, pair.snd);
        return kvp;
    }
    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
}