using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentreSpikes : MonoBehaviour
{
    private float rate = 0.0f;

    void Start()
    {
        this.transform.Rotate(0, 0, Random.Range(0.0f, 360.0f));

        this.rate = Random.Range(0.0f, 20.0f);

        if (Chance.RandomRotationDirection() == Chance.RotationDirection.AntiClockwise)
        {
            this.rate = -this.rate;
        }

        float newScale = Random.Range(0.5f, 2.5f);

        this.transform.localScale = new Vector3(newScale, newScale, 1.0f);
    }

    private void Update()
    {
        this.transform.Rotate(0, 0, this.rate * Time.deltaTime);
    }
}



