using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float knockbackStrength;
    //jumpSkill i GameData.cs jump można połączyć w jedno?
    //bool jumpSkill = false;
    bool jumpCooldown = false;
    bool knockbacked = false;
    float hitTimer;
    public float postHitInvincibility;

    public AudioSource audioSource;
    public AudioClip coinSE;
    public AudioClip jumpSE;
    public AudioClip healthUpSE;
    public AudioClip healthDownSE;
    public AudioClip ladySnailEncounterSE;
    public AudioClip powerUpSE;

    public GameObject gameOverHUD;
    public GameObject HUD;

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
        if (knockbacked == false) //wyłącza funkcje poruszania się na czas działania knockbacku
        {
            float x = Input.GetAxisRaw("Horizontal");
            float moveBy = x * speed;
            rb.velocity = new Vector2(moveBy, rb.velocity.y);
        }
        else hitTimer += Time.deltaTime;
        if (hitTimer >= postHitInvincibility)
        {
            knockbacked = false;
            hitTimer = 0;
        }
    }
    void Jump()
    {
        if (GameData.jump == true && jumpCooldown==false)
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
            if (knockbacked == false) //gracz pod wpływem knockbacku jest niewrażliwy na obrażenia - można dodać jakiś efekt mrugania do postaci żeby było widoczne kiedy efekt sie kończy
            {
                knockbacked = true;
                jumpCooldown = true;
                HedgehogAI enemy = collision.gameObject.GetComponent<HedgehogAI>();
                rb.velocity = new Vector2(knockbackStrength * enemy.side, knockbackStrength); // skrypt sprawdza w którą stronę przeciwnik się aktualnie przemieszcza i w tą samą
                                                                                              // stronę odpycha gracza
                GameData.healthPoints--;
                //Dźwięk utracenia życia
                audioSource.GetComponent<AudioSource>().PlayOneShot(healthDownSE);
            }
            if (GameData.healthPoints <= 0)
            {
                // zaimplementować kod na śmierć gracza
                // Dodać ekran końca gry z zapytaniem czy wyjść/wczytać
                if (gameObject.tag == "Player")
                {
                    //Time.timeScale = 0;
                    gameOverHUD.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "JumpPowerUp")
        {
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
        if(collision.gameObject.tag=="LadySnail")
        {
            //Pojawia możliwość rozpoczęcia
            GameData.triggerLadySnail = true;
            //Dźwięk Pani Ślimak
            audioSource.GetComponent<AudioSource>().PlayOneShot(ladySnailEncounterSE);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC" || collision.gameObject.tag == "LadySnail")
        {
            //Znika możliwość rozpoczęcia dialogu
            GameData.triggerLadySnail = false;
        }
    }
}
