using System.Collections;
using UnityEngine;

public class TestForInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private float moveSpeed = 5f;

    private PlayerController player;

    private void Start()
    {
        player = PlayerController.Instance;
    }

    public void Interact()
    {
        StartCoroutine(MoveToPosition(transform.position));
        
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        float distance = Vector3.Distance(player.transform.position, targetPosition);
        while (distance > 1f)
        {
            player.transform.position = Vector3.Lerp(

                player.transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime / distance

                );
            distance = Vector3.Distance(player.transform.position, targetPosition);

            player.DisableGravity();
            yield return null;
        }
        player.transform.position = targetPosition;
        player.EnableGravity();
    }
}
