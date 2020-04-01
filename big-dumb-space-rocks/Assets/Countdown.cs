using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    private float timer;

    public GameObject _5;
    public GameObject _4;
    public GameObject _3;
    public GameObject _2;
    public GameObject _1;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (this.timer - 1.0f < Time.time)
        {
            _1.SetActive(true);
            _2.SetActive(false);
        }
        else if (this.timer - 2.0f < Time.time)
        {
            _2.SetActive(true);
            _3.SetActive(false);
        }
        else if (this.timer - 3.0f < Time.time)
        {
            _3.SetActive(true);
            _4.SetActive(false);
        }
        else if (this.timer - 4.0f < Time.time)
        {
            _4.SetActive(true);
            _5.SetActive(false);
        }
        else if (this.timer - 5.0f < Time.time)
        {
            _5.SetActive(true);
        }
    }

    private void OnEnable()
    {
        this.timer = Time.time + 5.0f;
    }
}
