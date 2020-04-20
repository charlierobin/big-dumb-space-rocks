using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSub : MonoBehaviour
{
    private float xAngle, yAngle, zAngle;

    private void Start()
    {
        this.xAngle = Random.Range(-1.0f, 1.0f);
        this.yAngle = Random.Range(-1.0f, 1.0f);
        this.zAngle = Random.Range(-1.0f, 1.0f);




    }

    private void Update()
    {
        this.transform.Rotate(this.xAngle * Time.timeScale, this.yAngle * Time.timeScale, this.zAngle * Time.timeScale, Space.Self);
    }

    //private void FixedUpdate()
    //{

    //}
}

