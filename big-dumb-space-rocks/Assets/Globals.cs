using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public List<int> highScores;

    private void Start()
    {
        int[] scores = PlayerPrefsX.GetIntArray("highScores");

        foreach (int score in scores)
        {
            this.highScores.Add(score);
        }

        Debug.Log("highScores: " + this.highScores.Count);
    }

    public void Quit()
    {
        int[] toWrite = this.highScores.ToArray();

        PlayerPrefsX.SetIntArray("highScores", toWrite);

        Application.Quit();
    }
}

