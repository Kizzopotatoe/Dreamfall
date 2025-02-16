using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float maxTime = 1f;
    [SerializeField] private float maxDistance = 1f;

    private NavMeshAgent agent;
    private float timer = 0f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Refreshes movement over max time
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            float sqDistance = (target.position - agent.destination).sqrMagnitude;
            if(sqDistance > maxDistance * maxDistance)
            {
                agent.destination = target.position;
            }
            timer = maxTime;
        }
    }
}
