using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfield : MonoBehaviour
{
    private Rigidbody rb;

    private float range = 0.05f;
    private float minimum = 0.02f;

    private float limit = 0.01f;

    private void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rb.angularVelocity.x < limit && rb.angularVelocity.y < limit && rb.angularVelocity.z < limit)
        {
            rb.AddRelativeTorque(this.random(), this.random(), this.random(), ForceMode.Impulse);
        }
    }

    private float random()
    {
        float value = Random.Range(-range, range);

        if (value > 0)
        {
            value = Mathf.Max(minimum, value);
        }
        else
        {
            value = Mathf.Max(-minimum, value);
        }

        return value;
    }
}
