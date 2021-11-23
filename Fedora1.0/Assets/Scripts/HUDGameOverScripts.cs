using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDGameOverScripts : MonoBehaviour
{

    Canvas gameOverHud;

    public void startLevelAllOverAgain()
    {
        //Nie działa poprawnie
        SceneManager.LoadScene(1);
    }

    public void gameOverExit()
    {
        Application.Quit();
    }
}
