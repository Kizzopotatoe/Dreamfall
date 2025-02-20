using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsMenuPanel;

    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button backButton;

    [Header("Volume Settings")]
    [SerializeField] private TextMeshProUGUI volumeTextValue;
    [SerializeField] private Slider volumeSlider;

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
        SceneManager.LoadScene("Bedroom");
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

    public void SetVolume(float volume)
    {
        // Temp
        AudioListener.volume = volume;
    }
}
