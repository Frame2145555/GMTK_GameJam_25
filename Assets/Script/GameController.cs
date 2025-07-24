using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeReference] Reception reception;
    [SerializeReference] GameManager gameManager;

    [SerializeField] UnitGFXBuilder builder;
    [SerializeField] ItemGameObjectBuilder itemBuilder;
    [SerializeField] UnitGFXHandler handler;

    private void Awake()
    {
        Auxiliary.CheckInspectorNotAssign(reception);
        Auxiliary.CheckInspectorNotAssign(gameManager);
        Auxiliary.CheckInspectorNotAssign(builder);
        Auxiliary.CheckInspectorNotAssign(itemBuilder);
        Auxiliary.CheckInspectorNotAssign(handler);
    }
    private void Start()
    {
        reception.OnNextUnit += TryCreateUnitGFX;
    }
    void TryCreateUnitGFX()
    {
        //try instantiate UnitGFX GameObject
        GameObject unitGFX = null;
        if (reception.CurrentUnit != null)
        {
            unitGFX = builder.BuildUnitGFX(reception.CurrentUnit);
        }   
        else { }

            handler.CurrentUnitGFX = unitGFX == null ? null : unitGFX.GetComponent<UnitGFX>();
    }

    [ContextMenu("Accept Unit")]
    public void Accept()
    {
        reception.Accept();
    }
    [ContextMenu("Reject Unit")]
    public void Reject()
    {
        reception.Reject();
    }
    [ContextMenu("Start Day")]
    public void StartDay()
    {
        gameManager.DayStart();
    }
    [ContextMenu("End Day")]
    public void EndDay()
    {
        gameManager.DayEnd();
    }
    [ContextMenu("Next Day")]
    public void NextDay()
    {
        gameManager.DayNext();
    }

    public void Enter()
    {

    }
    public void Leave()
    {

    }
}
