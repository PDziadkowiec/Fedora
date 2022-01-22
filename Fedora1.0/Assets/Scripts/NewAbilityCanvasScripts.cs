using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewAbilityCanvasScripts : MonoBehaviour
{
    // Skrypt przypisany do NEW ABILITY CANVAS
    // Skrypt do obsługi New Ability Canvas

    public Canvas NewAbilityCanvvas;

    public void BackToGame()
    {
        NewAbilityCanvvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}
