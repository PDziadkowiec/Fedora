using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomofWater : MonoBehaviour
{

    //Skrypt przypisany do obiektów BOTTOM OF WATER

    public float position_x;
    public float position_y;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.position = new Vector2(position_x, position_y);
        }
    }
}
