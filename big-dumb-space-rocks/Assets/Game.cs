using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject ui;

    private void Start()
    {
        Instantiate(this.ui);
    }

    private void Update()
    {
        
    }
}
