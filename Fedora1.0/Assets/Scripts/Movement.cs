using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public int healthPoints;
    public int coins;
    bool jumpSkill = false;
    bool jumpCooldown = false;



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
            healthPoints--;
            if (healthPoints <= 0)
            {
                // zaimplementować kod na śmierć gracza
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
            coins++;
            Destroy(collision.gameObject);
        }
    }
}
