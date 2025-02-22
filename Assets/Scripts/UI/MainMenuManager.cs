using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance { get; private set; }

    public event EventHandler OnChangeSensitivity;

    [Header("Menus")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsMenuPanel;
    [SerializeField] private GameObject audioSettingsMenu;
    [SerializeField] private GameObject confirmationPrompt;

    [Header("Volume Settings")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private TextMeshProUGUI musicVolumeTextValue;
    [SerializeField] private TextMeshProUGUI sfxVolumeTextValue;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private float defaultVolume = 1f;
    private float musicVolume;
    private float sfxVolume;

    [Header("Gameplay Settings")]
    [SerializeField] private TextMeshProUGUI controllerSensitivityTextValue;
    [SerializeField] private Slider controllerSensitivitySlider;
    [SerializeField] private int defaultSensitivity = 4;
    public int mainControllerSensitivity = 4;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        mainMenuPanel.SetActive(true);
        optionsMenuPanel.SetActive(false);

        // Save Music + SFX Volume
        float savedMusicVolume = PlayerPrefs.GetFloat("musicVolume", defaultVolume);
        float savedSFXVolume = PlayerPrefs.GetFloat("sfxVolume", defaultVolume);
        // Apply saved values
        audioMixer.SetFloat("Music", savedMusicVolume);
        audioMixer.SetFloat("SFX", savedSFXVolume);

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Dream");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OptionsButton()
    {
        mainMenuPanel.SetActive(false);
        optionsMenuPanel.SetActive(true);
    }

    public void SoundButton()
    {
        optionsMenuPanel.SetActive(false);
        audioSettingsMenu.SetActive(true);
    }

    public void SetVolume(float volume)
    {
        musicVolume = Mathf.Log10(volume) * 20f;
        audioMixer.SetFloat("Music", musicVolume);

        musicVolumeTextValue.text = volume.ToString("0.0");
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Log10(volume) * 20f;
        audioMixer.SetFloat("SFX", sfxVolume);

        sfxVolumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);

        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);

        StartCoroutine(ConfirmationBox());
    }

    public void SetControllerSensitivity(float sensitivity)
    {
        mainControllerSensitivity = Mathf.RoundToInt(sensitivity);
        controllerSensitivityTextValue.text = sensitivity.ToString("0");

        OnChangeSensitivity?.Invoke(this, EventArgs.Empty);
    }

    public void GameplayApply()
    {
        PlayerPrefs.SetFloat("masterSensitivity", mainControllerSensitivity);
        StartCoroutine(ConfirmationBox());

        OnChangeSensitivity?.Invoke(this, EventArgs.Empty);
    }

    public void ResetButton(string menuType)
    {
        if(menuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            musicVolumeTextValue.text = defaultVolume.ToString("0.0");
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
