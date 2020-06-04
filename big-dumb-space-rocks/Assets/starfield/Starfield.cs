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
            Chance.Axis axis = Chance.RandomAxis();

            if (axis == Chance.Axis.X)
            {
                rb.AddRelativeTorque(this.random(), 0.0f, 0.0f, ForceMode.Impulse);
            }
            else if (axis == Chance.Axis.Y)
            {
                rb.AddRelativeTorque(0.0f, this.random(), 0.0f, ForceMode.Impulse);
            }
            else
            {
                rb.AddRelativeTorque(0.0f, 0.0f, this.random(), ForceMode.Impulse);
            }
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
