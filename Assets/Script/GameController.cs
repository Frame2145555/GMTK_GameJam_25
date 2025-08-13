using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(1000)]
public class GameController : MonoBehaviour
{
    [SerializeReference] Reception reception;
    [SerializeReference] GameManager gameManager;

    [SerializeField] UnitGFXBuilder builder;
    [SerializeField] ItemGameObjectBuilder itemBuilder;
    [SerializeField] UnitGFXHandler handler;
    [SerializeField] ItemGFXHandler itemHandler;
    private void Awake()
    {
        Auxiliary.CheckInspectorNotAssign(reception);
        Auxiliary.CheckInspectorNotAssign(gameManager);
        Auxiliary.CheckInspectorNotAssign(builder);
        Auxiliary.CheckInspectorNotAssign(itemBuilder);
        Auxiliary.CheckInspectorNotAssign(handler);
        Auxiliary.CheckInspectorNotAssign(itemHandler);
    }
    private void Start()
    {

        reception.OnNextUnit += TryCreateUnitGFX;
        reception.OnNextUnit += TryCreateItemGFX;

        NextDay();
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
    void TryCreateItemGFX()
    {
        if (reception.CurrentUnit != null)
        {
            List<GameObject> itemGFXList = new List<GameObject>();
            foreach (Item item in reception.CurrentUnit.Items)
            {
                GameObject newItem = itemBuilder.CreateItemGameObject(item);
                itemGFXList.Add(newItem);
            }
            itemHandler.Items = itemGFXList;
            // unitGFX = builder.BuildUnitGFX(reception.CurrentUnit);s
        }   
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
