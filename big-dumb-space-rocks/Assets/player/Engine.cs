using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    private void EngineOn()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x, 0.3f, 1.0f);
    }

    private void EngineOff()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x, 0.0f, 1.0f);
    }
}
