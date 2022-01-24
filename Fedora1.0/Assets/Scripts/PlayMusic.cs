using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour
{

    //Skrypt przypisany do GRACZA
    //Skrypt odpowiedzialny za muzykę

    public AudioSource audioSource;
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    public AudioClip forestMusic;
    public AudioClip provinceMusic;
    public AudioClip cityMusic;
    public AudioClip mountainMusic;
    public AudioClip menuMusic;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        int sceneIndex = currentScene.buildIndex;

        //Las
        if(sceneIndex==1)
        {
            audioSource.volume = PlayerPrefs.GetFloat(SoundEffectsPref);
            audioSource.GetComponent<AudioSource>().PlayOneShot(forestMusic);
        }
        //Prowincja
        else if (sceneIndex==2)
        {
            audioSource.volume = PlayerPrefs.GetFloat(SoundEffectsPref);
            audioSource.GetComponent<AudioSource>().PlayOneShot(provinceMusic);
        }
        //Miasto
        else if (sceneIndex == 3)
        {
            audioSource.volume = PlayerPrefs.GetFloat(SoundEffectsPref);

            audioSource.GetComponent<AudioSource>().PlayOneShot(cityMusic);
        }
        //Góry
        else if (sceneIndex == 4)
        {
            audioSource.volume = PlayerPrefs.GetFloat(SoundEffectsPref);

            audioSource.GetComponent<AudioSource>().PlayOneShot(mountainMusic);
        }
        //Menu
        else if (sceneIndex == 5)
        {
            audioSource.volume = PlayerPrefs.GetFloat(SoundEffectsPref);

            audioSource.GetComponent<AudioSource>().PlayOneShot(menuMusic);
        }
    }

}
