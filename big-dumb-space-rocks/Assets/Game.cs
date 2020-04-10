using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : Singleton<Game>
{
    public GameObject uiPrefab;

    public int score;
    private bool scoreDirty;

    private void Start()
    {
        Instantiate(this.uiPrefab);
        this.scoreDirty = true;
    }

    private void Update()
    {
        if (this.scoreDirty)
        {
            GameUI.Instance.SendMessage("UpdateScoreDisplay", this.score);
            this.scoreDirty = false;
        }
    }

    public void addToScore(int value)
    {
        this.score = this.score + value;
        this.scoreDirty = true;
    }
}

