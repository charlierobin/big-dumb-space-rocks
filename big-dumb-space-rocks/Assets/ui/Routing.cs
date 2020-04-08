using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Routing : MonoBehaviour
{
    public GameObject introUIPrefab;
    public GameObject highScoresUIPrefab;
    public GameObject selectDifficultyUIPrefab;

    public GameObject gamePrefab;

    private static Routing instance;

    public static bool Handle(GameObject sender, string message)
    {
        return Routing.instance.instance_Handle(sender, message);
    }

    private void Start()
    {
        if (Routing.instance == null)
        {
            Routing.instance = this;
        }
        else
        {
            throw new System.Exception("You can only launch one instance of the behaviour “" + this.GetType().Name + "”");
        }
    }

    private bool instance_Handle(GameObject sender, string message)
    {
        bool handled = false;

        switch (message)
        {
            case "introUI/PlayButton":

                Instantiate(this.selectDifficultyUIPrefab);
                handled = true;
                break;

            case "introUI/HighScoresButton":

                Instantiate(this.highScoresUIPrefab);
                handled = true;
                break;

            case "selectDifficultyUI/Level1Button":

                Instantiate(this.gamePrefab);
                handled = true;
                break;

            case "selectDifficultyUI/Level2Button":

                Instantiate(this.gamePrefab);
                handled = true;
                break;

            case "selectDifficultyUI/Level3Button":

                Instantiate(this.gamePrefab);
                handled = true;
                break;

            case "selectDifficultyUI/Level4Button":

                Instantiate(this.gamePrefab);
                handled = true;
                break;

            case "selectDifficultyUI/CancelButton":

                Instantiate(this.introUIPrefab);
                handled = true;
                break;

            case "highScoresUI/PlayButton":

                Instantiate(this.selectDifficultyUIPrefab);
                handled = true;
                break;

            case "highScoresUI/BackButton":

                Instantiate(this.introUIPrefab);
                handled = true;
                break;
        }

        return handled;
    }
}


