
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Canvas canvasMainMenu, canvasSettings;
    public AudioSource[] music;
    public AudioSource[] soundEffects;
    public Slider musicSlider,seSlider;
    public Dropdown dropdown;
    public void showSettings()
    {
        canvasMainMenu.enabled = false;
        canvasSettings.enabled = true;
    }
    public void changeMusicVolume()
    {
        music = GetComponents<AudioSource>();
        for(int i = 0; i < music.Length; i++)
        {
            music[i].volume = musicSlider.value;
            music[i].clip = GetComponent<AudioClip>();
        }

    }
    public void changeSEVolume()
    {
        soundEffects = GetComponents<AudioSource>();
        for (int i = 0; i < music.Length; i++)
        {
            soundEffects[i].volume = seSlider.value;
            soundEffects[i].clip = GetComponent<AudioClip>();
        }

    }

    public void DropdownOptions()
    {
        dropdown.itemText.text = "800x600";
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

}
