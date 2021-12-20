using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    //Skrypt przypisany do obiektu PLAYER

    public Canvas CanvasMenuPause;

    void Update()
    {
        MenuPauseCanvas();
    }

    void MenuPauseCanvas()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CanvasMenuPause.enabled = true;
        }
    }

}
