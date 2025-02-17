using System;
using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    public event EventHandler OnBedAnimation;

    public void Interact()
    {
        Debug.Log("Going to sleep...");
        OnBedAnimation?.Invoke(this, EventArgs.Empty);
    }
}
