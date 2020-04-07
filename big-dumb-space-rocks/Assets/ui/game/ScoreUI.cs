using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private void Score(int value)
    {
        this.GetComponent<UnityEngine.UI.Text>().text = "Score: " + value;
    }
}
