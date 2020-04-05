﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : Singleton<Game>
{
    public GameObject uiPrefab;
    private GameObject ui;

    public int score;
    private bool scoreDirty;

    private void Start()
    {
        this.ui = Instantiate(this.uiPrefab);
        // send "startFadeIn" separately? (in on start at the moment)
    }

    private void Update()
    {
        if (this.scoreDirty)
        {
            this.ui.BroadcastMessage("Score", this.score);
            this.scoreDirty = false;
        }
    }

    public void addToScore(int value)
    {
        this.score = this.score + value;
        this.scoreDirty = true;
        //this.ui.BroadcastMessage("Score", this.score);
    }
}

