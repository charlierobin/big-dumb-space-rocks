using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    public GameObject uiToLaunchAtStart;

    void Start()
    {
        Resources.LoadAll("");

        Instantiate(this.uiToLaunchAtStart);
    }
}
