﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : Singleton<UI>
{
    public GameObject startScreen;
    public GameObject pauseScreen;

    public void ShowPause()
    {
        pauseScreen.GetComponent<UIScreenController>().Show();
    }

    public void HidePause()
    {
        pauseScreen.GetComponent<UIScreenController>().Hide();
    }

    private void Start()
    {
        startScreen.GetComponent<UIScreenController>().Show();
    }
}
