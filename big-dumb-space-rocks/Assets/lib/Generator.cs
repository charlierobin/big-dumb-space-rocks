using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Generator : MonoBehaviour
{
    public int rate = 1;
    public float period = 10.0f;
    public float variation = 0.0f;

    [ReadOnly] public string summary;

    private int _rate = 1;
    private float _period = 10.0f;
    private float _variation = 0.0f;

    public bool manual = false;

    public bool manualOnly = false;

    public UnityEvent targets;

    private float time;
    private float originTime;

    private float normalisedPeriod;

    private void Start()
    {
        this._rate = this.rate;
        this._period = this.period;
        this._variation = this.variation;

        this.normalisedPeriod = this.period / this.rate;

        this.summary = "Every " + this.normalisedPeriod + " seconds";

        this.originTime = Time.time;
        this.time = this.originTime + (this.normalisedPeriod + Random.Range(-this.variation, this.variation));
    }

    private void Update()
    {
        if (this.manual)
        {
            this.manual = false;
            this.targets.Invoke();
            this.generate();
            return;
        }

        if (this.manualOnly) return;

        if (Time.time >= this.time)
        {
            this.targets.Invoke();
            this.generate();

            this.originTime = Time.time;
            this.time = this.originTime + (this.normalisedPeriod + Random.Range(-this.variation, this.variation));
        }
    }

    private void OnValidate()
    {
        bool dirty = false;

        if (this.rate != this._rate)
        {
            this._rate = this.rate;
            dirty = true;
        }

        if (this.period != this._period)
        {
            this._period = this.period;
            dirty = true;
        }

        if (this.variation != this._variation)
        {
            this._variation = this.variation;
            dirty = true;
        }

        if (dirty)
        {
            this.normalisedPeriod = this.period / this.rate;

            this.summary = "Every " + this.normalisedPeriod + " seconds";

            this.time = this.originTime + (this.normalisedPeriod + Random.Range(-this.variation, this.variation));
        }
    }

    protected virtual void generate()
    {
        // override in subclass
    }
}

