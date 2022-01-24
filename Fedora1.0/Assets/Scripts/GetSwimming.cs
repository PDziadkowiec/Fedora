﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSwimming : MonoBehaviour
{
    // Skrypt przypisany do SWIMMING POWER UP
    // Skrypt wywołuje się po podniesieniu "zalążka magii"
    // Pozwala Oddychać Pod Wodą
    private static readonly string SoundEffectsPref = "SoundEffectsPref";

    public AudioSource audioSource;
    public AudioClip powerUpSE;
    public Image SwimmingSkillImage;
    public Canvas NewAbilityCanvas;
    public Text AbilityName;
    public Text AbilityDesc;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Gracz posiada umiejętność grapple
            GameData.swimming = true;
            audioSource.volume = PlayerPrefs.GetFloat(SoundEffectsPref);
            audioSource.GetComponent<AudioSource>().PlayOneShot(powerUpSE);
            Destroy(gameObject);
            Time.timeScale = 0;
            AbilityName.text = "Zdobyto umiejętność:\nODDYCHANIE POD WODĄ";
            AbilityDesc.text = "Rocco potrafi teraz poruszać się w wodzie.\nUżyj tej umiejętności, by dostać się do nowych miejsc!";
            NewAbilityCanvas.gameObject.SetActive(true);

            SwimmingSkillImage.gameObject.SetActive(true);
        }
    }
}
