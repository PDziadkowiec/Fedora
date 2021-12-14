using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetJump : MonoBehaviour
{
    //Skrypt przypisany do obiektu JUMP POWER UP

    public AudioSource audioSource;
    public AudioClip powerUpSE;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Gracz posiada umiejętność skok
            GameData.jump = true;
            audioSource.GetComponent<AudioSource>().PlayOneShot(powerUpSE);
            Destroy(gameObject);
        }
    }

}
