using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private float rate = 0.0f;
    private float deathTime = 0.0f;

    void Start()
    {
        this.transform.Rotate(0, 0, Random.Range(0.0f, 360.0f));

        this.deathTime = Random.Range(0.2f, 1.0f) + Time.time;

        this.rate = Random.Range(50.0f, 500.0f);

        if (Chance.RandomRotationDirection() == Chance.RotationDirection.AntiClockwise)
        {
            this.rate = -this.rate;
        }

        // x is "fatness", y is length

        this.transform.localScale = new Vector3(Random.Range(0.5f, 1.5f), Random.Range(0.5f, 2.0f), 1.0f);
    }

    void Update()
    {
        this.transform.Rotate(0, 0, this.rate * Time.deltaTime);

        if (Time.time > this.deathTime)
        {
            Destroy(this.gameObject);
        }
    }
}
