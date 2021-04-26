using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteKey("highScores");
    }
}
