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
                //this.GetComponent<AudioSource>().PlayOneShot(fileName);
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
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Coin")
        {
            GameData.coins++;
            //Dźwięk podniesienia monety
            //this.GetComponent<AudioSource>().PlayOneShot(fileName);
            Destroy(collision.gameObject);
        }
    }
}
