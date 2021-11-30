
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Canvas canvasMainMenu, canvasSettings;

    public void showSettings()
    {
        canvasMainMenu.enabled = false;
        canvasSettings.enabled = true;
    }
    public void showMenu()
    {
        canvasMainMenu.enabled = true;
        canvasSettings.enabled = false;
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
