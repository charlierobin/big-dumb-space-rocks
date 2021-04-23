using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    void Update()
    {
        this.transform.Rotate(new Vector3(0, 1.0f * Time.timeScale, 0));
    }
}

