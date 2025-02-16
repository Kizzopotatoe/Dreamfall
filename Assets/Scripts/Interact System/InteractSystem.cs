using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    [SerializeField] private Transform interactSource;
    [SerializeField] private float interactRange;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(interactSource.position, interactSource.forward);
            
            if(Physics.Raycast(ray, out RaycastHit hitInfo, interactRange))
            {
                if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact();
                }
            }
        }
    }
}
