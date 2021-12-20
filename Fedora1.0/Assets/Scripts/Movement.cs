﻿using System.Collections;
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

    public Text HealthAmmount;

    public AudioSource audioSource;
    public AudioClip jumpSE;
    public AudioClip healthDownSE;

    public GameObject gameOverHUD;
    public GameObject HUD;

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
                rb.velocity = grappleDir * 10;
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
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrappleField")
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
