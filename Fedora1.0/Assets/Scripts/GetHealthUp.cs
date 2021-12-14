using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHealthUp : MonoBehaviour
{

    //Skrypt przypisany do obiektu HealthUp

    public AudioSource audioSource;
    public AudioClip healthUpSE;
    public Text HealthAmmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameData.maxHealthPoints += 1;
            GameData.healthPoints += 1;
            //Dźwięk podniesienia życia
            audioSource.GetComponent<AudioSource>().PlayOneShot(healthUpSE);
            Destroy(gameObject);
            //Wyświetlanie / zaktualizowanie ilości życia
            HealthAmmount.text = (GameData.healthPoints).ToString() + " / " + (GameData.maxHealthPoints).ToString();
        }
    }
}
