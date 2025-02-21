using UnityEngine;
using UnityEngine.SceneManagement;
public class HotelDoors : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        SceneManager.LoadScene(3);
    }

}
