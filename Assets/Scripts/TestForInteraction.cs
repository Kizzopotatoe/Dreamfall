using UnityEngine;

public class TestForInteraction : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("YOU ARE INTERACTING WITH: " + transform.name);
    }
}
