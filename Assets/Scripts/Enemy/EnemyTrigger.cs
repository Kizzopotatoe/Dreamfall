using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    [Header("Set True if Start Trigger")]
    [SerializeField] private bool setEnemyActive = false; 

    private void Start()
    {
        enemy.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out PlayerController player))
        {
            if (enemy != null)
            {
                // If player hits the start trigger
                if (setEnemyActive)
                {
                    enemy.SetActive(true);
                }
                // if player hits the end trigger
                else
                {
                    Destroy(enemy);
                }
            }
        }
    }
}
