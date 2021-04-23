using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfield : MonoBehaviour
{
    private Rigidbody rb;

    public float range = 0.05f;
    public float minimum = 0.02f;

    public float limit = 0.02f;

    private float timer;

    private void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Time.time <= timer) return;

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

            timer = Time.time + 5.0f;
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
            value = Mathf.Min(-minimum, value);
        }

        return value;
    }
}
