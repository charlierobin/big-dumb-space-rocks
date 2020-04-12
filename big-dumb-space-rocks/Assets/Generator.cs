using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Generator : MonoBehaviour
{
    public int rate = 1;

    public float period = 10.0f;

    public UnityEvent watchers;

    private float time;

    void Start()
    {
        this.time = Time.time + this.period;
    }

    void Update()
    {
        if (Time.time >= this.time)
        {
            for (int i = 0; i < this.rate; i++)
            {
                this.watchers.Invoke();
            }

            this.time = Time.time + this.period;
        }
    }
}

