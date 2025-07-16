
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