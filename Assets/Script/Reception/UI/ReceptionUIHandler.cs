using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceptionUIHandler : MonoBehaviour
{
    Reception reception;
    [SerializeField] DevModeUnitUIHandler unitUIHandler;
    [SerializeField] List<DevModeQuestUIHandler> questUIHandler = new List<DevModeQuestUIHandler>();

    void Start()
    {
        reception = GetComponent<Reception>();

        Auxiliary.CheckInspectorNotAssign(unitUIHandler);
        Auxiliary.CheckInspectorNotAssign(questUIHandler);

        for (int i = 0; i < 3; i++)
        {
            questUIHandler[i].Active(false);
        }

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
        for (int i = 0; i < reception.TodayQuest.Count; i++)
        {
            if (reception.TodayQuest[i] != null)
            {
                Quest todayQuest = reception.TodayQuest[i];
                questUIHandler[i].rQuest = todayQuest;
                questUIHandler[i].Active(true);
            }
            else
            {
                questUIHandler[i].Active(false);
                
            }
        }
    }
}
