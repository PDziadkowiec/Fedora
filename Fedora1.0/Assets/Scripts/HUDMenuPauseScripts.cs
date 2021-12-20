using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDMenuPauseScripts : MonoBehaviour
{
    //Skrypt przypisany do obiektu GAME PAUSE HUD SCRIPTS
    public Canvas CanvasMenuPause;

    public void BackToGame()
    {
        CanvasMenuPause.enabled = false;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}