using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public Score score;

    void Start()
    {
        score = FindObjectOfType<Score>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out PlayerController player))
        {
            score.morning = true;

            SceneManager.LoadScene(1);
        }
    }
}
