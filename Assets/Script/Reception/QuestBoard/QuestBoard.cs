using UnityEngine;

public class QuestBoard : MonoBehaviour
{
    [SerializeField] QuestBoardUIHandler questBoardUIHandler;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        Debug.Log($"{gameObject.name} was clicked!");
        questBoardUIHandler.OpenUI();
    }
}
