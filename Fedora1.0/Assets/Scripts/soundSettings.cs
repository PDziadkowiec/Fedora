using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundSettings : MonoBehaviour
{
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private float soundEffectsFloat;
    public AudioSource[] soundEffectsAudio;
    void Awake()
    {
        ContinueSettings();

    }

    private void ContinueSettings()
    {
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsFloat;
        }
    }

}
