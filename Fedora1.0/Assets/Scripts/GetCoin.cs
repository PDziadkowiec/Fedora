using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCoin : MonoBehaviour
{

    //Skrypt przypisany do obiektu COIN
    //Skrypt wywoływany podczas podnoszenia monety

    public AudioSource audioSource;
    public AudioClip coinSE;
    public Text CoinAmmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Dźwięk podniesienia monety
            audioSource.GetComponent<AudioSource>().PlayOneShot(coinSE);
            GameData.coins++;
            Destroy(gameObject);
            //Wyświetlanie / zaktualizowanie liczby monet
            CoinAmmount.text = (GameData.coins).ToString() + " / " + (GameData.maxCoins).ToString();
        }
    }
}
