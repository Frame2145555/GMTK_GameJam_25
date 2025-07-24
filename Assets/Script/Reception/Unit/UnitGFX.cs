using System;
using UnityEngine;

public class UnitGFX : MonoBehaviour
{
    [SerializeField] public SpriteRenderer SR;

    Action onStartAnimEnd;
    Action onEndAnimEnd;
    private void Awake()
    {
        Auxiliary.CheckInspectorNotAssign(SR);
    }

    private void Start()
    {
        onEndAnimEnd += () => Destroy(gameObject);
    }

    public void PlayStartAnim()
    {
        onStartAnimEnd?.Invoke();
    }
    
    public void PlayEndAnim()
    {
        onEndAnimEnd?.Invoke();
    }

}
