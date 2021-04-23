using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonTorpedo : MonoBehaviour
{
    public GameObject libCentreGlow;
    public GameObject libSpike;
    public GameObject libSpikeWider;
    public GameObject libChromaFan;
    public GameObject libCentreSpikes;

    public AnimationCurve startCurve;

    public float startTimeSpan = 0.15f;

    private float timeOffSet = 0.0f;
    private float startTime;

    private void Start()
    {
        this.startTime = Time.time;

        Instantiate<GameObject>(this.libCentreGlow, this.transform);
        Instantiate<GameObject>(this.libCentreSpikes, this.transform);
        Instantiate<GameObject>(this.libCentreSpikes, this.transform);

        Instantiate<GameObject>(this.libChromaFan, this.transform);

        this.updateScale();
    }

    private void Update()
    {
        if (Time.timeScale == 0.0f) return;

        if (Chance.OneIn(20))
        {
            if (Chance.CoinToss())
            {
                Instantiate<GameObject>(this.libSpike, this.transform);
            }
            else
            {
                Instantiate<GameObject>(this.libSpikeWider, this.transform);
            }
        }

        this.timeOffSet = Time.time - this.startTime;
        this.updateScale();
    }

    private void updateScale()
    {
        if (this.timeOffSet > this.startTimeSpan) return;
        float factor = this.startCurve.Evaluate(this.timeOffSet / this.startTimeSpan);
        this.transform.localScale = new Vector3(factor, factor, factor);
    }
}
