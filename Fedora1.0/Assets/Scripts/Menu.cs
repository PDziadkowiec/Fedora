
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class Menu : MonoBehaviour
{

    //Skrypt do obsługi Menu Głównego, w tym ustawień

    public Canvas canvasMainMenu, canvasSettings;
    public Slider musicSlider,seSlider;
    public AudioMixer audioMixer;

    public AudioSource audioSource;
    public AudioClip mainMenuMusic;

    private void Start()
    {
        audioSource.GetComponent<AudioSource>().PlayOneShot(mainMenuMusic);
    }

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

    public void startNewGame()
    {

        //Przy starcie nowej gry przypisanie do PlayerPrefs "domyślnych" wartości
        PlayerPrefs.SetInt("healthPoints", 3);
        PlayerPrefs.SetInt("maxHealthPoints", 3);
        PlayerPrefs.SetInt("coins", 0);
        PlayerPrefs.SetInt("maxCoins", 100);

        PlayerPrefs.SetInt("jump", 0);
        PlayerPrefs.SetInt("grapple", 0);
        PlayerPrefs.SetInt("swimming", 0);

        PlayerPrefs.SetInt("hasGrape", 0);
        PlayerPrefs.SetInt("hasBasil", 0);
        PlayerPrefs.SetInt("hasWater", 0);
        PlayerPrefs.SetInt("hasCrystal", 0);

        PlayerPrefs.SetString("quest", "Dowiedz się, jak zmienić się z powrotem w człowieka.");

        PlayerPrefs.SetString("location", "Las");
        PlayerPrefs.SetInt("sceneIndex", 1);

        PlayerPrefs.SetInt("firstForestLadySnailDialogue", 1);

        SceneManager.LoadScene(PlayerPrefs.GetInt("sceneIndex"));

        GameData.healthPoints = PlayerPrefs.GetInt("healthPoints");
        GameData.maxHealthPoints = PlayerPrefs.GetInt("maxHealthPoints");
        GameData.coins = PlayerPrefs.GetInt("coins");
        GameData.maxCoins = PlayerPrefs.GetInt("maxCoins");
        GameData.jump = Convert.ToBoolean(PlayerPrefs.GetInt("jump"));
        GameData.grapple = Convert.ToBoolean(PlayerPrefs.GetInt("grapple"));
        GameData.swimming = Convert.ToBoolean(PlayerPrefs.GetInt("swimming"));
        GameData.hasGrape = Convert.ToBoolean(PlayerPrefs.GetInt("hasGrape"));
        GameData.hasBasil = Convert.ToBoolean(PlayerPrefs.GetInt("hasBasil"));
        GameData.hasWater = Convert.ToBoolean(PlayerPrefs.GetInt("hasWater"));
        GameData.hasCrystal = Convert.ToBoolean(PlayerPrefs.GetInt("hasCrystal"));
        GameData.listOfQuests = PlayerPrefs.GetString("quest");
        GameData.location = PlayerPrefs.GetString("location");
        GameData.firstForestLadySnailDialogue = Convert.ToBoolean(PlayerPrefs.GetInt("firstForestLadySnailDialogue"));
    }

    public void continueGame()
    {
        //Zabezpieczenie jeżeli PlayerPrefs.sceneIndex poza zakresu scen to nie ładuje się gra

        if (PlayerPrefs.GetInt("sceneIndex") > 0 && PlayerPrefs.GetInt("sceneIndex") <= 4)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("sceneIndex"));

            GameData.healthPoints = PlayerPrefs.GetInt("healthPoints");
            GameData.maxHealthPoints = PlayerPrefs.GetInt("maxHealthPoints");
            GameData.coins = PlayerPrefs.GetInt("coins");
            GameData.maxCoins = PlayerPrefs.GetInt("maxCoins");
            GameData.jump = Convert.ToBoolean(PlayerPrefs.GetInt("jump"));
            GameData.grapple = Convert.ToBoolean(PlayerPrefs.GetInt("grapple"));
            GameData.swimming = Convert.ToBoolean(PlayerPrefs.GetInt("swimming"));
            GameData.hasGrape = Convert.ToBoolean(PlayerPrefs.GetInt("hasGrape"));
            GameData.hasBasil = Convert.ToBoolean(PlayerPrefs.GetInt("hasBasil"));
            GameData.hasWater = Convert.ToBoolean(PlayerPrefs.GetInt("hasWater"));
            GameData.hasCrystal = Convert.ToBoolean(PlayerPrefs.GetInt("hasCrystal"));
            GameData.listOfQuests = PlayerPrefs.GetString("quest");
            GameData.location = PlayerPrefs.GetString("location");
            GameData.firstForestLadySnailDialogue = Convert.ToBoolean(PlayerPrefs.GetInt("firstForestLadySnailDialogue"));
        }
        else
        {
            //Brak obecnie zapisanego stanu gry
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void FullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    
    public void VolumeChange(float v)
    {
        audioMixer.SetFloat("volume", v);
    }

}
