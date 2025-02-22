using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;

    private MainMenuManager mainMenuManager;

    private bool isGamePaused = false;

    private void Awake()
    {
        mainMenuManager = GetComponent<MainMenuManager>();
    }

    private void Start()
    {
        GameInput.Instance.OnPausePerformed += GameInput_OnPausePerformed;

        pauseMenuPanel.SetActive(false);
    }

    private void GameInput_OnPausePerformed(object sender, System.EventArgs e)
    {
        TogglePauseGame();
    }

    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            Time.timeScale = 0f;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            pauseMenuPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            pauseMenuPanel.SetActive(false);
        }
    }

    public void ResumeButton()
    {
        pauseMenuPanel.SetActive(false);
        TogglePauseGame();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
