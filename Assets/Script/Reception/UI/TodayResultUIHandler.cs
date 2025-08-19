using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TodayResultUIHandler : MonoBehaviour
{
    [SerializeField] List<TMP_Text> results = new List<TMP_Text>();
    [SerializeField] GameObject UI;
    [SerializeField] GameManager gm;
    void ShowResult()
    {
        UI.SetActive(true);
        for (int i = 0; i < results.Count; i++)
        {
            string text = "";
            if (i < GameData.quests.Count)
            {
                Quest q = GameData.quests[i];
                text += $"Quest {q.Info.title}  : ";
                text += q.IsCompleted() ? "Completed" : "InCompleted";
            }
            results[i].text = text;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI.SetActive(false);
        gm.OnDayEnd += ShowResult;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NextButton()
    {
        //Go Next Day
        SceneManager.LoadScene("Demo-Guild");
    }
}
