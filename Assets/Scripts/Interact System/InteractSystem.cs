using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    [SerializeField] private Transform interactSource;
    [SerializeField] private float interactRange;
    public GameObject interactUI;

    private void Update()
    {
        Ray ray = new Ray(interactSource.position, interactSource.forward);

        if (Input.GetMouseButtonDown(0))
        {   
            if(Physics.Raycast(ray, out RaycastHit hitInfo, interactRange))
            {
                if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact();
                }
            }
        }

        interactUI.SetActive(false);

        if(Physics.Raycast(ray, out RaycastHit hoverInfo, interactRange))
        {
            if(hoverInfo.collider.gameObject.CompareTag("Interactable"))
            {
                interactUI.SetActive(true);
            }
        }
    }
}
