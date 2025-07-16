using UnityEngine;
using UnityEngine.UI;

public class ReceptionUIHandler : MonoBehaviour
{
    Reception reception;
    [SerializeField] DevModeUnitUIHandler unitUIHandler;
    [SerializeField] DevModeQuestUIHandler questUIHandler;

    void Start()
    {
        reception = GetComponent<Reception>();

        Auxiliary.CheckInspectorNotAssign(unitUIHandler);
        Auxiliary.CheckInspectorNotAssign(questUIHandler);

        reception.OnQueueNext += AssignReferenceToUnitUI;
        reception.OnDayNext += AssignReferenceToQuestUI;
    }

    void AssignReferenceToUnitUI()
    {
        if (reception.CurrentUnit != null)
            unitUIHandler.rUnit = reception.CurrentUnit;
    }

    void AssignReferenceToQuestUI()
    {
        if (reception.TodayQuest != null)
            questUIHandler.rQuest = reception.TodayQuest;
    }
}
