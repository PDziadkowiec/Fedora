using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetJump : MonoBehaviour
{
    //Skrypt przypisany do obiektu JUMP POWER UP

    public AudioSource audioSource;
    public AudioClip powerUpSE;
    public Image JumpSkillImage;
    public Canvas NewAbilityCanvas;
    public Text AbilityName;
    public Text AbilityDesc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Gracz posiada umiejętność skok
            GameData.jump = true;
            audioSource.GetComponent<AudioSource>().PlayOneShot(powerUpSE);
            Destroy(gameObject);
            Time.timeScale = 0;
            AbilityName.text = "Zdobyto umiejętność:\nSKOK";
            AbilityDesc.text = "Rocco może teraz skakać. \nUżyj tej umiejętności, by dostać się do nowych miejsc!";
            NewAbilityCanvas.gameObject.SetActive(true);

            JumpSkillImage.gameObject.SetActive(true);
        }
    }

}
