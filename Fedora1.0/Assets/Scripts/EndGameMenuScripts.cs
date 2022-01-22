using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameMenuScripts : MonoBehaviour
{
    //Skrypt przypisany do END GAME MENU SCRIPTS
    //Skrypt obsługujący ostatnią scene tj. ekran przejścia gry

    public Text coins;

    void Start()
    {
        coins.text = (GameData.coins).ToString();
    }   

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
