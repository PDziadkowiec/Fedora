using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomofWater : MonoBehaviour
{

    //Skrypt przypisany do obiektów BOTTOM OF WATER
    //Służy do cofania gracza na ląd gdy zanurzy się w wodzie bez umiejętności Oddychanie Pod Wodą (swimming)

    public float position_x;
    public float position_y;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GameData.swimming == false)
        {
            collision.transform.position = new Vector2(position_x, position_y);
        }
    }
}
