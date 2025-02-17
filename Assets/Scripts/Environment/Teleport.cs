using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform destination;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out PlayerController player))
        {
            player.canMove = false;
            Debug.Log("Teleported");
            other.gameObject.transform.position = destination.position;
        }
    }
}
