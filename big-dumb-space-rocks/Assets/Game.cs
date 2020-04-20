using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : Singleton<Game>
{
    public GameObject playerPrefab;

    public int score;
    private bool scoreDirty;

    private int level;

    private bool pausing;
    private bool paused;

    private bool unpausing;

    private float timeScale;

    private void Start()
    {
        Instantiate(this.playerPrefab, new Vector3(), Quaternion.identity);
        this.scoreDirty = true;
        this.timeScale = Time.timeScale;
    }

    private void Update()
    {
        if (this.scoreDirty)
        {
            GameUI.Instance.SendMessage("UpdateScoreDisplay", this.score);
            this.scoreDirty = false;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            if (!this.pausing && !this.paused)
            {
                this.pausing = true;
            }
            else if (this.paused)
            {
                this.unpausing = true;
            }
        }

        if (this.pausing)
        {
            if (this.timeScale > 0.0f)
            {
                this.timeScale = this.timeScale - 0.05f;
                this.timeScale = Mathf.Max(this.timeScale, 0.0f);
                Time.timeScale = this.timeScale;
            }
            else
            {
                this.pausing = false;
                this.paused = true;
            }
        }
        else if (this.unpausing)
        {
            if (this.timeScale < 1.0f)
            {
                this.timeScale = this.timeScale + 0.05f;
                this.timeScale = Mathf.Min(this.timeScale, 1.0f);
                Time.timeScale = this.timeScale;
            }
            else
            {
                this.unpausing = false;
                this.paused = false;
            }
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

    public void AbandonGameDEAD()
    {


    }

    public void SetDifficulty(int level)
    {
        this.level = level;
    }
}

