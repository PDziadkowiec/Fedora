using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewItemCanvasScripts : MonoBehaviour
{
    // Skrypt przypisany do NEW ITEM CANVAS SCRIPTS
    public Canvas NewItemCanvvas;

    public void BackToGame()
    {
        NewItemCanvvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
