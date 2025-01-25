using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressAnyKeyMenu : MonoBehaviour
{
    public string sceneName; // The name of the scene to load

    /// Update method for detecting any key press
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("A key or mouse click has been detected in Update");
            LoadScene();
        }
    }

    // Function to load the scene (can be called by a UI button)
    public void OnButtonPress()
    {
        Debug.Log("Button pressed to load the scene");
        LoadScene();
    }

    // Centralized method to load the scene
    private void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene name is not set in the inspector!");
        }
    }
}
