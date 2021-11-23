using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLevitation : MonoBehaviour
{
    public float degreesPerSecond = 10.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    //Zmienne do określenia pozycji
    Vector2 posOffset = new Vector2();
    Vector2 tempPosition = new Vector2();

    void Start()
    {
        //Pozycja startowa
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // Unoszenie się i spadanie za pomocą Sin()
        tempPosition = posOffset;
        tempPosition.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPosition;
    }
}
