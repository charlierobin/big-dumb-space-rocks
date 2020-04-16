using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : Singleton<UI>
{
    public GameObject mainMenu;
    public GameObject highScores;
    public GameObject selectDifficulty;
    public GameObject pause;

    private void Awake()
    {
        this.mainMenu.SetActive(false);
        this.highScores.SetActive(false);
        this.selectDifficulty.SetActive(false);
        this.pause.SetActive(false);
    }

    public void MainMenu()
    {
        this.mainMenu.SetActive(true);
    }

    public void HighScores()
    {
        this.highScores.SetActive(true);
    }

    public void SelectDifficultyFromMain()
    {
        this.selectDifficulty.SetActive(true);
    }

    public void SelectDifficultyFromHighScores()
    {
        this.selectDifficulty.SetActive(true);
    }

    public void CancelSelectDifficulty()
    {
       
    }

    public void SelectDifficulty_1()
    {
       
    }

    public void SelectDifficulty_2()
    {
       
    }

    public void SelectDifficulty_3()
    {
       
    }

    public void SelectDifficulty_4()
    {
       
    }

    public void Resume()
    {

    }

    public void GiveUp()
    {

    }
}


