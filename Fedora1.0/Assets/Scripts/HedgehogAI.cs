using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogAI : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    int side = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveBy = side * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TurnPoint")
        {
            side = side * -1;
        }
    }

}
