using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Reception reception;
    [SerializeField] UnitGFXBuilder builder;
    [SerializeField] ItemGameObjectBuilder itemBuilder;
    [SerializeField] UnitGFXHandler handler;

    private void Awake()
    {
        Auxiliary.CheckInspectorNotAssign(reception);
        Auxiliary.CheckInspectorNotAssign(builder);
        Auxiliary.CheckInspectorNotAssign(itemBuilder);
        Auxiliary.CheckInspectorNotAssign(handler);
    }
    private void Start()
    {
        reception.OnQueueNext += TryCreateUnitGFX;
    }
    void TryCreateUnitGFX()
    {
        GameObject unitGFX = null;
        if (reception.CurrentUnit != null)
            unitGFX = builder.BuildUnitGFX(reception.CurrentUnit);

        handler.CurrentUnitGFX = unitGFX == null? null : unitGFX.GetComponent<UnitGFX>();
    }

    [ContextMenu("Accept Unit")]
    public void Accept()
    {
        reception.Decide(true);
    }
    [ContextMenu("Reject Unit")]
    public void Reject()
    {
        reception.Decide(false);
    }
    [ContextMenu("Next Day")]
    public void EndDay()
    {
        reception.NextDay();
    }
    

    public void Enter()
    {

    }
    public void Leave()
    {

    }
}
