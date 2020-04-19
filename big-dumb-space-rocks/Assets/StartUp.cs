using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    private void Start()
    {
        Invoke("test", 2.0f);

        //Resources.LoadAll("");
    }

    private void test()
    {
        Resources.LoadAll("");
    }
}
