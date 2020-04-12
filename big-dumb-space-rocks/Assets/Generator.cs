using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int rate = 1;

    public float period = 10.0f;

    public MonoBehaviour target;
    private IPingable _target;

    private float time;

    void Start()
    {
        this._target = (IPingable)this.target;

        this.time = Time.time + this.period;
    }

    void Update()
    {
        if (Time.time >= this.time)
        {
            for (int i = 0; i < this.rate; i++)
            {
                this._target.ping();
            }

            this.time = Time.time + this.period;
        }
    }
}

interface IPingable
{
    void ping();
}
