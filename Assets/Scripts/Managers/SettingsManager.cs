using UnityEngine;

public class SettingsManager : MonoBehaviour
{

    private void Start()
    {
        if(PlayerController.Instance != null)
        {
            PlayerController.Instance.GetComponentInChildren<CameraController>().mouseSensitivity = PlayerPrefs.GetFloat("masterSensitivity");
        }
    }

}
