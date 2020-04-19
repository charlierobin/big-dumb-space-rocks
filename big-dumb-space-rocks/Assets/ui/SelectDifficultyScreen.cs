using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDifficultyScreen : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject highScores;

    private GameObject returnScreen;

    public void SetReturnToMain()
    {
        this.returnScreen = this.mainMenu;
    }

    public void SetReturnToHighScores()
    {
        this.returnScreen = this.highScores;
    }

    public void Return()
    {
        this.gameObject.GetComponent<UIScreenController>().Hide();
        this.returnScreen.GetComponent<UIScreenController>().Show();
    }
}
