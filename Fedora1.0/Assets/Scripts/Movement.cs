using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    //Skrypt przypisany do obiektu PLAYER
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float knockbackStrength;

    bool jumpCooldown = false;
    bool knockbacked = false;
    bool grappleInRange = false;
    Transform grappleTarget;
    float hitTimer;
    public float postHitInvincibility;
    int side;

    public Text HealthAmmount;

    public AudioSource audioSource;
    public AudioClip jumpSE;
    public AudioClip healthDownSE;

    public GameObject gameOverHUD;
    public GameObject HUD;

    private static readonly string SoundEffectsPref = "SoundEffectsPref";


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Move();
        Jump();
        Grapple();
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
                audioSource.volume = PlayerPrefs.GetFloat(SoundEffectsPref);
                audioSource.GetComponent<AudioSource>().PlayOneShot(jumpSE);
                jumpCooldown = true;
            }
        }
    }
    void Grapple()
    {
        if (GameData.grapple == true && grappleInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {              
                knockbacked = true;
                Vector2 grappleDir = (grappleTarget.position - rb.transform.position).normalized;
                rb.velocity = grappleDir * 15;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case ("Ground"):
                jumpCooldown = false;
                break;
            case ("Enemy"):
                if (knockbacked == false) //gracz pod wpływem knockbacku jest niewrażliwy na obrażenia - można dodać jakiś efekt mrugania do postaci żeby było widoczne kiedy efekt sie kończy
                {
                    knockbacked = true;
                    jumpCooldown = true;
                    if (TryGetComponent<HedgehogAI>(out HedgehogAI h) == true)
                    {
                        h = collision.gameObject.GetComponent<HedgehogAI>();
                        side = h.side;
                    }
                    if(TryGetComponent<FrogAI>(out FrogAI f) == true)
                    {
                        f = collision.gameObject.GetComponent<FrogAI>();
                        side = f.side;
                    }                       
                        rb.velocity = new Vector2(knockbackStrength * side, knockbackStrength); // skrypt sprawdza w którą stronę przeciwnik się aktualnie przemieszcza i w tą samą
                                                                                                              // stronę odpycha gracz
                    GameData.healthPoints--;
                    //Dźwięk utracenia życia
                    audioSource.volume = PlayerPrefs.GetFloat(SoundEffectsPref);

                    audioSource.GetComponent<AudioSource>().PlayOneShot(healthDownSE);
                    //Wyświetlanie / zaktualizowanie ilości życia
                    HealthAmmount.text = (GameData.healthPoints).ToString() + " / " + (GameData.maxHealthPoints).ToString();
                }
                if (GameData.healthPoints <= 0)
                {
                    if (gameObject.tag == "Player")
                    {
                        Time.timeScale = 0;
                        gameOverHUD.SetActive(true);
                    }
                }
                break;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrappleField") // Prefab GrapplePole - zmieniajcie skale rozmiaru GrappleField jak wam pasuje - im mniejsze GrappleField tym bardziej precyzyjnie powinien trafiać
        {
            // wejście  w zasięg kotwiczki
            grappleInRange = true;
            grappleTarget = collision.gameObject.GetComponentInChildren<Transform>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrappleField")
        {
            // opuszczenie zasięgu kotwiczki
            grappleInRange = false;
        }
    }
}
