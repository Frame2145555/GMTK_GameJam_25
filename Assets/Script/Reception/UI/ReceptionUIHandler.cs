using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceptionUIHandler : MonoBehaviour
{
    Reception reception;
    GameManager gm;
    [SerializeField] DevModeUnitUIHandler unitUIHandler;
    [SerializeField] List<DevModeQuestUIHandler> questUIHandler = new List<DevModeQuestUIHandler>();

    void Start()
    {
        reception = GetComponent<Reception>();
        gm = GetComponent<GameManager>();

        Auxiliary.CheckInspectorNotAssign(unitUIHandler);
        Auxiliary.CheckInspectorNotAssign(questUIHandler);

        //On start, disable all DevModeQuestUIHandler GameObject
        questUIHandler.ForEach((qUI) => qUI.gameObject.SetActive(false));

        reception.OnNextUnit += UpdateUnitUI;
        reception.OnNextUnit += UpdateQuestUI;
    }

    void UpdateUnitUI()
    {
        if (reception.CurrentUnit != null)
            unitUIHandler.rUnit = reception.CurrentUnit;
    }
    void UpdateQuestUI()
    {
        AssignReferenceToQuestUI();
        questUIHandler.ForEach((qUI) => { if (qUI.isActiveAndEnabled) qUI.UpdateTexts(); });
    }
    void AssignReferenceToQuestUI()
    {
        questUIHandler.ForEach((qUI) => qUI.gameObject.SetActive(false));
        for (int i = 0; i < GameData.quests.Count; i++)
        {
            questUIHandler[i].rQuest = GameData.quests[i];
            questUIHandler[i].gameObject.SetActive(true);
        }
    }

}
