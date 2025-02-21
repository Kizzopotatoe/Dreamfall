using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsMenuPanel;
    [SerializeField] private GameObject audioSettingsMenu;
    [SerializeField] private GameObject confirmationPrompt;

    [Header("Main Menu Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button backButton;

    [Header("Volume Settings")]
    [SerializeField] private TextMeshProUGUI volumeTextValue;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private float defaultVolume = 1f;

    [Header("Gameplay Settings")]
    [SerializeField] private TextMeshProUGUI controllerSensitivityTextValue;
    [SerializeField] private Slider controllerSensitivitySlider;
    [SerializeField] private int defaultSensitivity = 4;
    public int mainControllerSensitivity = 4;

    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
        optionsButton.onClick.AddListener(OptionsButton);
        backButton.onClick.AddListener(BackButton);

        mainMenuPanel.SetActive(true);
        optionsMenuPanel.SetActive(false);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("Dream");
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void OptionsButton()
    {
        mainMenuPanel.SetActive(false);
        optionsMenuPanel.SetActive(true);
    }

    private void BackButton()
    {
        optionsMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void SoundButton()
    {
        optionsMenuPanel.SetActive(false);
        audioSettingsMenu.SetActive(true);
    }

    public void SetVolume(float volume)
    {
        // Temp
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    public void SetControllerSensitivity(float sensitivity)
    {
        mainControllerSensitivity = Mathf.RoundToInt(sensitivity);
        controllerSensitivityTextValue.text = sensitivity.ToString("0");
    }

    public void GameplayApply()
    {
        PlayerPrefs.SetFloat("masterSensitivity", mainControllerSensitivity);
        StartCoroutine(ConfirmationBox());
    }

    public void ResetButton(string menuType)
    {
        if(menuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeTextValue.text = defaultVolume.ToString("0.0");
            VolumeApply();
        }

        if(menuType == "Gameplay")
        {
            controllerSensitivityTextValue.text = defaultSensitivity.ToString("0");
            controllerSensitivitySlider.value = defaultSensitivity;
            mainControllerSensitivity = defaultSensitivity;
        }
    }

    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2f);
        confirmationPrompt.SetActive(false);
    }
}
