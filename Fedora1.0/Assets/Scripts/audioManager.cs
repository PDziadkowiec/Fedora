using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioManager : MonoBehaviour
{
    //Skrypt przypisany do sound effect slider'a

    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private int firstPlayInt;
    public Slider soundEffectsSlider;
    private float soundEffectsFloat;
    public AudioSource[] soundEffectsAudio;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if (firstPlayInt == 0) //warunek wykonuje sie przy pierwszym uruchomieniu gry
        {
            soundEffectsFloat = .75f;
            soundEffectsSlider.value = soundEffectsFloat;
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1); //przy następnym uruchomieniu gry ten warunek sie nie wykona
        }
        else
        {
            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            soundEffectsSlider.value = soundEffectsFloat;
        }
    }

    //metoda do zapisania wybranej przez gracza glosnosci
    public void SaveSound() 
    {
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSlider.value);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveSound();
        }
    }
    public void UpdateSound()
    {
        for(int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value;
        }
    }
}
