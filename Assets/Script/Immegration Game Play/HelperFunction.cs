using UnityEngine;

public static class Auxiliary
{
    public static T RandomEnum<T>()
    {
        var values = System.Enum.GetValues(typeof(T));
        int index = UnityEngine.Random.Range(0, values.Length);
        return (T)values.GetValue(index);
    }
}