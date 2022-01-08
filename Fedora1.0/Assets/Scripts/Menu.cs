
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    //Skrypt do obsługi Menu Głównego

    public Canvas canvasMainMenu, canvasSettings;
    public AudioSource[] music;
    public AudioSource[] soundEffects;
    public Slider musicSlider,seSlider;

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

    public void FullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

}
