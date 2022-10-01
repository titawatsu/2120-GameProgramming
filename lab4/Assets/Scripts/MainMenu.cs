using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        LoadGameplay();
    }

    
    public void QuitGame()
    {
        QuitApp();
    }

    #region FUNCTION
    private void LoadGameplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void QuitApp()
    {
        Debug.Log("Application has Quit");
        Application.Quit();
    }
    #endregion
}
