using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : Singleton<Globals>
{
    public List<int> highScores;

    public GameObject gamePrefab;

    private void Start()
    {
        int[] scores = PlayerPrefsX.GetIntArray("highScores");

        foreach (int score in scores)
        {
            this.highScores.Add(score);
        }

        Debug.Log("highScores: " + this.highScores.Count);
    }

    private void newGame(int level)
    {
        Instantiate(this.gamePrefab);

        Game.Instance.SetDifficulty(level);
    }

    public void NewGameWithDifficulty1()
    {
        this.newGame(1);
    }

    public void NewGameWithDifficulty2()
    {
        this.newGame(2);
    }

    public void NewGameWithDifficulty3()
    {
        this.newGame(3);
    }

    public void NewGameWithDifficulty4()
    {
        this.newGame(4);
    }

    public void Quit()
    {
        int[] toWrite = this.highScores.ToArray();

        PlayerPrefsX.SetIntArray("highScores", toWrite);

        Application.Quit();
    }








    public void Resume()
    {
        Pause.Instance.UnPause();
    }

    public void GiveUp()
    {
        Game.Instance.PlayerGaveUp();
        Time.timeScale = 1.0f;
    }

    public void PlayerKilled(int score)
    {






    }

    
}

