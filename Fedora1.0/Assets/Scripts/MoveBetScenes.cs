using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBetScenes : MonoBehaviour
{

    //Skrypt przypisany do miejsc, będących przejściem do innych lokacji

    [SerializeField] private string nextLevel;
    //Przypisać ręcznie nazwę lokacji
    public string locationName;
    //Pozycja gracza po załadowaniu się nowe sceny;
    public float position_x = 0.0f;
    public float position_y = 0.0f;
    GameObject player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextLevel);
            //Pobranie nazwy lokacji
            GameData.location = locationName;
            player = GameObject.Find("Player");

            //Nie działa
            player.transform.position = new Vector2(position_x, position_y);
        }
    }
}
