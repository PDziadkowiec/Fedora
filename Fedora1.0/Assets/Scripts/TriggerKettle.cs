using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerKettle : MonoBehaviour
{

    //SKRYPT PRZYPISANY DO OBIEKTU KETTLE (KOCIOŁKA)

    public Text DrinkText;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && GameData.endGame == true)
        {
            //Jeżeli gracz wchodzi na trigger, pojawia się informacja o możliwości wypicia eliksiru
            DrinkText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && GameData.endGame == true)
        {
            //Jeśli naciśnięto klawisz odpowiedzialny za interakcję
            if (Input.GetKeyDown(KeyCode.E))
            {
                DrinkText.gameObject.SetActive(false);
                SceneManager.LoadScene(5);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DrinkText.gameObject.SetActive(false);
    }
}
