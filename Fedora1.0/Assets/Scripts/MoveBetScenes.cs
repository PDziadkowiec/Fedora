using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBetScenes : MonoBehaviour
{
    [SerializeField] private string nextLevel;
    //Przypisać ręcznie nazwę lokacji
    public string locationName;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextLevel);
            //Pobranie nazwy lokacji
            GameData.location = locationName;
        }
    }
}
