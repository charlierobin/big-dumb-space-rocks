﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : Singleton<Game>
{
    public GameObject playerPrefab;

    public int score;
    private bool scoreDirty;

    public int lives = 2;

    private int level;

    private void Start()
    {
        Instantiate(this.playerPrefab, new Vector3(), Quaternion.identity);
        this.scoreDirty = true;
        Debug.Log("Start lives: " + this.lives);
    }

    private void Update()
    {
        if (this.scoreDirty)
        {
            GameUI.SendMessage("UpdateScoreDisplay", this.score);
            this.scoreDirty = false;
        }
    }

    public void addToScore(int value)
    {
        this.score = this.score + value;
        this.scoreDirty = true;
    }

    private void PlayerKilled()
    {
        this.lives--;

        Debug.Log("PlayerKilled lives: " + this.lives);

        if (this.lives > 0)
        {
            Instantiate(this.playerPrefab, new Vector3(), Quaternion.identity);
        }
        else
        {
            Globals.Instance.PlayerKilled(this.score);
            Destroy(this.gameObject);
        }
    }

    public void SetDifficulty(int level)
    {
        this.level = level;
    }

    public void PlayerGaveUp()
    {
        //Destroy(Player.Instance.gameObject);
        //Destroy(this.gameObject);

        // TODO asteroids and flying saucers
        // they just continue off screen and never re-appear?
    }
}

