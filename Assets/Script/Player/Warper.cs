using UnityEngine;
using UnityEngine.SceneManagement;

public class Warper : MonoBehaviour
{
    [SerializeField] bool changeScene = false;
    [Header("If not change Scene")]
    [SerializeField] Vector2 m_targetPosition;
    public Vector2 TargetPosition { get => m_targetPosition; }

    [Header("If Change Scene")]
    [SerializeField] string nextScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (TryGetComponent(out PlayerController player))
        {
            if (changeScene)
            {
                SceneManager.LoadScene(nextScene);
            }
            else
            {
                player.transform.position = m_targetPosition;
            }
        }
    }
}
