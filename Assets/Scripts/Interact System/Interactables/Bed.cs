using System;
using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    public event EventHandler OnBedAnimation;
    public Score score;

    void Start()
    {
        score = FindObjectOfType<Score>();
        if(score.morning == true)
        {
            Destroy(this.GetComponent<BoxCollider>());
        }
    }

    public void Interact()
    {
        Debug.Log("Going to sleep...");
        OnBedAnimation?.Invoke(this, EventArgs.Empty);
    }
}
