using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfield : MonoBehaviour
{
    void Update()
    {
        this.transform.Rotate(new Vector3(1, 0, 0), 0.01f);
    }
}
