using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageWater : MonoBehaviour
{
    // Skrypt przypisany do obiektów o tagu WATER

    public GameObject gameOverHUD;

    public Text HealthAmmount;
   
    public AudioSource audioSource;
    public AudioClip healthDownSE;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameData.healthPoints--;
            //Dźwięk utracenia życia
            audioSource.GetComponent<AudioSource>().PlayOneShot(healthDownSE);
            //Wyświetlanie / zaktualizowanie ilości życia
            HealthAmmount.text = (GameData.healthPoints).ToString() + " / " + (GameData.maxHealthPoints).ToString();
        }
        if (GameData.healthPoints <= 0)
        {
            Time.timeScale = 0;
            gameOverHUD.SetActive(true);
        }

    }

}
