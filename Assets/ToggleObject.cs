using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    [SerializeField] GameObject[] View;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < View.Length; i++)
        {
            View[i].SetActive(false);
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < View.Length; i++)
            {
                View[i].SetActive(true);
                
            }
        }
    }
}
