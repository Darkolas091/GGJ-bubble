using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void MainMenu ()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Debug.Log("You exited the game");
        Application.Quit();
    }

    public void StartGame()
    {
        Debug.Log("You started the game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
