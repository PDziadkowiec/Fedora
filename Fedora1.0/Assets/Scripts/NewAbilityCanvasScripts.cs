using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewAbilityCanvasScripts : MonoBehaviour
{
    // Skrypt przypisany do NEW ABILITY CANVAS
    public Canvas NewAbilityCanvvas;

    public void BackToGame()
    {
        NewAbilityCanvvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}
