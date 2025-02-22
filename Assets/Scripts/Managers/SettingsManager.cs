using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private void Start()
    {
        if(PlayerController.Instance != null)
        {
            PlayerController.Instance.GetComponentInChildren<CameraController>().mouseSensitivity = PlayerPrefs.GetFloat("masterSensitivity");
        }

        MainMenuManager.Instance.OnChangeSensitivity += Instance_OnChangeSensitivity;
    }

    private void Instance_OnChangeSensitivity(object sender, System.EventArgs e)
    {
        PlayerController.Instance.GetComponentInChildren<CameraController>().mouseSensitivity = PlayerPrefs.GetFloat("masterSensitivity");
    }
}
