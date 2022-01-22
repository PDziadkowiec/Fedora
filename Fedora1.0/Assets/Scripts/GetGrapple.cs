using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetGrapple : MonoBehaviour
{
    // Skrypt przypisany do GRAPPLE POWER UP
    // Skrypt wywołuje się po podniesieniu "zalążka magii"
    // Umożliwia na uzywanie Lepkiego Języka

    public AudioSource audioSource;
    public AudioClip powerUpSE;
    public Image GrappleSkillImage;
    public Canvas NewAbilityCanvas;
    public Text AbilityName;
    public Text AbilityDesc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Gracz posiada umiejętność grapple
            GameData.grapple = true;
            audioSource.GetComponent<AudioSource>().PlayOneShot(powerUpSE);
            Destroy(gameObject);
            Time.timeScale = 0;
            AbilityName.text = "Zdobyto umiejętność:\nLEPKI JĘZYK";
            AbilityDesc.text = "Użyj tej umiejętności, by dostać się do nowych miejsc!\nNaciśnij F, aby przyciągnąć się do odpowiednich obiektów.";
            NewAbilityCanvas.gameObject.SetActive(true);

            GrappleSkillImage.gameObject.SetActive(true);
        }
    }

}
