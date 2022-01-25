 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAI : MonoBehaviour
//Skrypt przypisany do obiektu FROG ENEMY
{
    Rigidbody2D rb;
    float jumpTimer;
    float jumpTimerTarget = 3;
    bool jumpCooldown = true;
    public float speed=4;
    internal int side = 1; // internal - inne skrypty mogą pobrać wartość zmienniej + zmienna nie pojawia się w opcjach dostosowywania obiektu, co wydaje się dobrym rozwiązaniem.
                           // Potrzebne do knockbacku
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (jumpCooldown == false)
        {
            side = side * -1;
            Move();
            jumpTimer = 0;          
            jumpCooldown = true;
        }
        else jumpTimer += Time.deltaTime;
        if (jumpTimer >= jumpTimerTarget)
        {
            jumpCooldown = false;
        }

    }

    void Move()
    {
        float moveBy = side * speed;
        rb.velocity = new Vector2(moveBy, speed);
    }


}
