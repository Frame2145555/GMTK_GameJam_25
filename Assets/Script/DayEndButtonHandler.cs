using UnityEngine;

public class DayEndButtonHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject endDayButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        endDayButton.SetActive(GameData.units.Count <= 0);
    }
}
