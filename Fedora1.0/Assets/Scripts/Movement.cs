using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    bool jumpSkill;
    bool jumpCooldown;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 4;
        jumpForce = 8;
        jumpSkill = true;
        jumpCooldown = true;
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
    }
}
