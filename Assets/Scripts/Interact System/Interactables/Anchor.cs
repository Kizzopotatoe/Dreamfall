using System.Collections;
using UnityEngine;

public class Anchor : MonoBehaviour, IInteractable
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gravityFallTime = 0.1f;
    [SerializeField] private float anchorForce = 10f;

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

            player.canMove = false;
            player.DisableGravity(0f);
            yield return null;
        }
        player.transform.position = targetPosition;
        yield return new WaitForSeconds(gravityFallTime);
        player.canMove = true;
        player.EnableGravity();
        player.AddForce(new Vector3(0f, anchorForce, 0f));
    }

}
