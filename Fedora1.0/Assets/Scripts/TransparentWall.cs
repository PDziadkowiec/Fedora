using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentWall : MonoBehaviour
{

    //Skrypt przypisany do ścian, które po wejściu w Trigger mają być półprzeźroczyste (sekretów)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        }
    }
    //Wyjście z triggera przywraca brak przeźroczystości
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

    }
}
