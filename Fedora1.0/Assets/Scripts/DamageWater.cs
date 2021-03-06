using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageWater : MonoBehaviour
{
    // Skrypt przypisany do obiektów o tagu WATER
    // Gdy gracz wejdzie do wody, a nie ma umiejętności Oddychanie Pod Wodą, traci HP

    Rigidbody2D rb;
    GameObject player;

    public GameObject gameOverHUD;

    public Text HealthAmmount;
   
    public AudioSource audioSource;
    public AudioClip healthDownSE;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (GameData.swimming == false)
            {
                GameData.healthPoints--;
                //Dźwięk utracenia życia
                audioSource.GetComponent<AudioSource>().PlayOneShot(healthDownSE);
                //Wyświetlanie / zaktualizowanie ilości życia
                HealthAmmount.text = (GameData.healthPoints).ToString() + " / " + (GameData.maxHealthPoints).ToString();


                if (GameData.healthPoints <= 0)
                {
                    Time.timeScale = 0;
                    gameOverHUD.SetActive(true);
                }
            }
        }
    }

}
