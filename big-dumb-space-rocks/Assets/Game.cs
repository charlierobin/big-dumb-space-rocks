using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : Singleton<Game>
{
    public GameObject uiPrefab;
    public GameObject playerPrefab;

    public int score;
    private bool scoreDirty;

    private void Start()
    {
        Instantiate(this.uiPrefab);
        Instantiate(this.playerPrefab, new Vector3(), Quaternion.identity);
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

    private void PlayerKilled()
    {
        Instantiate(this.playerPrefab, new Vector3(), Quaternion.identity);
    }

    public void AbandonGame() {
        
        
    }
}

