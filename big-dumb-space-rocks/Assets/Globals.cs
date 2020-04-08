﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public List<int> highScores;

    private void Start()
    {
        foreach (int score in PlayerPrefsX.GetIntArray("highScores"))
        {
            this.highScores.Add(score);
        }

        //Debug.Log("highScores: " + this.highScores.Count);
    }
}

