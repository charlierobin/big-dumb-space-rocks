using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Generator : MonoBehaviour
{
    public int rate = 1;

    public float period = 10.0f;

    public float variation = 0.0f;

    [ReadOnly]
    public string summary;

    public UnityEvent targets;

    private float time;

    private float originTime;

    private float normalisedPeriod;

    private void Start()
    {
        this.enabled = false;

        this.normalisedPeriod = this.period / this.rate;

        //this.summary = "Every " + this.normalisedPeriod + " seconds";

        this.originTime = Time.time;
        this.time = this.originTime + (this.normalisedPeriod + Random.Range(-this.variation, this.variation));
    }

    private void EndGame()
    {
        this.enabled = false;
    }

    private void StartGame()
    {
        this.enabled = true;
    }

    private void InvokeTargets()
    {
        if (this.targets.GetPersistentEventCount() > 0)
        {
            this.targets.Invoke();
        }
        else
        {
            //Debug.Log("Invoke " + this.gameObject.name);
        }
    }

    private void Update()
    {
        if (Time.time >= this.time)
        {
            this.InvokeTargets();
            this.originTime = Time.time;
            this.time = this.originTime + (this.normalisedPeriod + Random.Range(-this.variation, this.variation));
        }
    }

    private void OnValidate()
    {
        this.normalisedPeriod = this.period / this.rate;

        this.summary = "Every " + this.normalisedPeriod + " seconds";

        this.time = this.originTime + (this.normalisedPeriod + Random.Range(-this.variation, this.variation));
    }
}
