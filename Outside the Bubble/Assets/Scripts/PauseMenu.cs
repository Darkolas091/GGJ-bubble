using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [SerializeField] private GameObject pauseMenuUI; // Ensures this field shows in the Inspector

    void Update()
    {
        // Detect the Escape key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Resume the game and hide the pause menu
    public void Resume()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
        else
        {
            Debug.LogError("PauseMenuUI is not assigned in the Inspector!");
        }
    }

    // Pause the game and show the pause menu
    private void Pause()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
        else
        {
            Debug.LogError("PauseMenuUI is not assigned in the Inspector!");
        }
    }

    // Load the main menu scene
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    // Exit the game
    public void ExitGame()
    {
        Debug.Log("You exited the game");
        Application.Quit();
    }

    // Start a new game (load the next scene in the build index)
    public void StartGame()
    {
        Debug.Log("You started the game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
