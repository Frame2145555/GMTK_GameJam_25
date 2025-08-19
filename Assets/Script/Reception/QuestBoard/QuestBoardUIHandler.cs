using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Xml.Linq;
public class QuestBoardUIHandler : MonoBehaviour
{
    [SerializeField] List<QuestBoardCard> allCard = new List<QuestBoardCard>();
    [SerializeField] GameObject questBoardUI;
    public List<Quest> AllCard
    {
        set
        {
            if (value.Count > allCard.Count)
                throw new InvalidOperationException("the two List doesn't have the same size");

            for (int i = 0; i < value.Count; i++)
            {
                allCard[i].rQuest = value[i];
                allCard[i].gameObject.SetActive(true);
            }
            int remain = allCard.Count - value.Count;
            if (remain <= 0)
                return;
            for (int i = value.Count; i < allCard.Count; i++)
            {
                allCard[i].gameObject.SetActive(false);
            }
        }
    }
    public void OpenUI()
    {
        questBoardUI.SetActive(true);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
