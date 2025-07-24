using System;
using System.Numerics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine.Rendering;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

[System.Serializable]
public struct Pair<T1,T2>
{
    public T1 fst;
    public T2 snd;
    public Pair(T1 _fst, T2 _snd)
    {
        fst = _fst;
        snd = _snd;
    }
}

[System.Serializable]
public struct MinMaxInt 
{
    public int min;
    public int max;

    public MinMaxInt(int _min, int _max)
    {
        min = _min;
        max = _max;
    }

    public int Roll()
    {
        return UnityEngine.Random.Range(min, max);
    }
}
public struct MinMaxFloat
{
    public float min;
    public float max;

    public MinMaxFloat(int _min, int _max)
    {
        min = _min;
        max = _max;
    }

    public float Roll()
    {
        return UnityEngine.Random.Range(min, max);
    }
}