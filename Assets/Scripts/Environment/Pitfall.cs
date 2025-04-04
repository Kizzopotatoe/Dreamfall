using UnityEngine;
using UnityEngine.SceneManagement;

public class Pitfall : MonoBehaviour
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
            score.Death();

            SceneManager.LoadScene(1);
        }
    }
}
