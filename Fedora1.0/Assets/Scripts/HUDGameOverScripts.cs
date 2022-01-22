using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDGameOverScripts : MonoBehaviour
{

    //Skrypt przypisany do GAME OVER HUD SCRIPTS

    Canvas gameOverHud;

    //Pobranie danych z ostatniego zapisu
    public void loadCheckpoint()
    {
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

            Time.timeScale = 1;
        }
        else
        {
            //Brak zapisanego stanu gry
        }
    }

    //Rozpoczęcie gry na nowo i przypisanie domyślnych zmiennych
    public void startGameAllOverAgain()
    {
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

        Time.timeScale = 1;
    }
    public void MenuExit()
    {
        SceneManager.LoadScene(0);
    }

    public void gameOverExit()
    {
        Application.Quit();
    }
}
