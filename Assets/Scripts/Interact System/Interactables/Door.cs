using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private float rotationSpeed = 10f;

    private Quaternion targetRotation;
    private bool isRotating = false;
    private bool isOpen = false;
    public AudioSource source;
    public AudioClip clip;

    private void Start()
    {
        targetRotation = transform.rotation * Quaternion.Euler(0, -90f, 0);
    }

    private void Update()
    {
        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if(transform.rotation == targetRotation)
            {
                isRotating = false;
            }
        }
    }

    public void Interact()
    {
        if(!isRotating)
        {
            if (isOpen)
            {
                targetRotation = transform.rotation * Quaternion.Euler(0f, 90f, 0f);
            }
            else
            {
                targetRotation = transform.rotation * Quaternion.Euler(0f, -90f, 0f);
            }

            isRotating = true;
            isOpen = !isOpen;

            source.PlayOneShot(clip);
        }
    }
}
