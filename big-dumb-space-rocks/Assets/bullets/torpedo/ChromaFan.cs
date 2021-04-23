using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromaFan : MonoBehaviour
{
    private Vector3 initialScale;

    private void Start()
    {
        this.initialScale = this.transform.localScale;
    }

    private void Update()
    {
        //if (Time.timeScale == 0.0f) return;

        // TODO not quite right!

        float variation = Time.timeScale * Random.Range(0.8f, 1.2f);

        if (Chance.CoinToss()) variation = -variation;

        this.transform.localScale = new Vector3(this.initialScale.x * variation, this.initialScale.y * variation, 1.0f);
    }
}

