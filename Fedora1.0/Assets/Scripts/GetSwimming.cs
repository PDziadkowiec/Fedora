using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSwimming : MonoBehaviour
{
    // Skrypt przypisany do SWIMMING POWER UP

    public AudioSource audioSource;
    public AudioClip powerUpSE;

    public Canvas NewAbilityCanvas;
    public Text AbilityName;
    public Text AbilityDesc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Gracz posiada umiejętność grapple
            GameData.swimming = true;
            audioSource.GetComponent<AudioSource>().PlayOneShot(powerUpSE);
            Destroy(gameObject);
            Time.timeScale = 0;
            AbilityName.text = "Zdobyto umiejętność:\nPŁYWANIE";
            AbilityDesc.text = "Rocco potrafi teraz pływać w wodzie.\nUżyj tej umiejętności, by dostać się do nowych miejsc!";
            NewAbilityCanvas.gameObject.SetActive(true);

            //GrappleSkillImage.gameObject.SetActive(true);
        }
    }
}
