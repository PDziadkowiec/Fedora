using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shrine : MonoBehaviour
{
    public Text PressToHealSave;
    public Text NumberOfHealth;
    public AudioSource audioSource;
    public AudioClip HealthUpSE;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Pokażą się napisy co zrobić aby się wyleczyć/zapisać
            PressToHealSave.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Jeśli naciśnięto klawisz odpowiedzialny za uleczenie się
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameData.healthPoints = GameData.maxHealthPoints;
                NumberOfHealth.text = (GameData.healthPoints).ToString() + " / " + (GameData.maxHealthPoints).ToString();
                audioSource.GetComponent<AudioSource>().PlayOneShot(HealthUpSE);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                //zapis stanu gry
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Znikną napisy co zrobić aby się wyleczyć/zapisać
            PressToHealSave.gameObject.SetActive(false);

        }
    }
}
