using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shrine : MonoBehaviour
{

    //SKRYPT PRZYPISANY DO SHRINE (KAPLICZKI)

    public Text PressToHealSave;
    public Text NumberOfHealth;
    public Text GameSaved;
    public AudioSource audioSource;
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    public AudioClip HealthUpSE;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Pokazanie napisu co zrobić aby się wyleczyć/zapisać
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
                audioSource.volume = PlayerPrefs.GetFloat(SoundEffectsPref);
                audioSource.GetComponent<AudioSource>().PlayOneShot(HealthUpSE);
            }
            //Jeśli naciśnięto klawisz odpowiedzialny za zapis
            if (Input.GetKeyDown(KeyCode.Q))
            {
                //Zapisanie danych do PlayerPrefs
                PlayerPrefs.SetInt("healthPoints", GameData.healthPoints);
                PlayerPrefs.SetInt("maxHealthPoints", GameData.maxHealthPoints);
                PlayerPrefs.SetInt("coins", GameData.coins);
                PlayerPrefs.SetInt("maxCoins", GameData.maxCoins);
                PlayerPrefs.SetString("quest", GameData.listOfQuests);

                PlayerPrefs.SetInt("jump", GameData.boolToInt(GameData.jump));
                PlayerPrefs.SetInt("grapple", GameData.boolToInt(GameData.grapple));
                PlayerPrefs.SetInt("swimming", GameData.boolToInt(GameData.swimming));

                PlayerPrefs.SetInt("hasGrape", GameData.boolToInt(GameData.hasGrape));
                PlayerPrefs.SetInt("hasBasil", GameData.boolToInt(GameData.hasBasil));
                PlayerPrefs.SetInt("hasWater", GameData.boolToInt(GameData.hasWater));
                PlayerPrefs.SetInt("hasCrystal", GameData.boolToInt(GameData.hasCrystal));

                PlayerPrefs.SetInt("firstForestLadySnailDialogue", GameData.boolToInt(GameData.firstForestLadySnailDialogue));

                Scene currentScene = SceneManager.GetActiveScene();

                PlayerPrefs.SetInt("sceneIndex", currentScene.buildIndex);

                PlayerPrefs.SetString("location", GameData.location);

                //Nie ma potrzeby podawania koordynatów gracza,
                //bo jedna zapisująca kapliczka na poziom?

                //Wyświetlenie komunikatu, że zapisano grę
                GameSaved.gameObject.SetActive(true);

            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Zniknięcie napisów co zrobić aby się wyleczyć/zapisać
            PressToHealSave.gameObject.SetActive(false);
            GameSaved.gameObject.SetActive(false);
        }
    }
}
