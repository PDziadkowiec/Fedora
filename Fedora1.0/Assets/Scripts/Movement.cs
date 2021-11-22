using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    bool jumpSkill = false;
    bool jumpCooldown = false;

    public AudioSource audioSource;
    public AudioClip coinSE;
    public AudioClip jumpSE;
    public AudioClip healthUpSE;
    public AudioClip healthDownSE;
    public AudioClip ladySnailEncounterSE;
    public AudioClip powerUpSE;

    //jumpSkill i GameData.cs jump można połączyć w jedno?

    //Implementacja przeniesiona do GameData.cs
    //public int healthPoints;
    //public int coins;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }
    void Jump()
    {
        if (jumpSkill == true && jumpCooldown==false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                //Dźwięk skoku
                audioSource.GetComponent<AudioSource>().PlayOneShot(jumpSE);
                jumpCooldown = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Ground")
        {
            jumpCooldown = false;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            GameData.healthPoints--;
            //Dźwięk utracenia życia
            audioSource.GetComponent<AudioSource>().PlayOneShot(healthDownSE);
            if (GameData.healthPoints <= 0)
            {
                // zaimplementować kod na śmierć gracza
                // Dodać ekran końca gry z zapytaniem czy wyjść/wczytać
                if (gameObject.tag == "Player")
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "JumpPowerUp")
        {
            jumpSkill = true;
            //Gracz posiada umiejętność skok
            GameData.jump = true;
            audioSource.GetComponent<AudioSource>().PlayOneShot(powerUpSE);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Coin")
        {
            //Dźwięk podniesienia monety
            audioSource.GetComponent<AudioSource>().PlayOneShot(coinSE);
            GameData.coins++;
            Destroy(collision.gameObject);
        }
        //Zdobycie dodatkowego życia
        if(collision.gameObject.tag=="HealthUp")
        {
            GameData.maxHealthPoints += 1;
            GameData.healthPoints += 1;
            //Dźwięk podniesienia życia
            audioSource.GetComponent<AudioSource>().PlayOneShot(healthUpSE);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag=="NPC")
        {
            //Pojawia się dialog
            //Dźwięk rozpoczęcia dialogu
            audioSource.GetComponent<AudioSource>().PlayOneShot(ladySnailEncounterSE);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            //Znika dialog
        }
    }
}
