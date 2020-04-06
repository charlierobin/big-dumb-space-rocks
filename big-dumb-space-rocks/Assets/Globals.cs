using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public GameObject introMenuPrefab;
    public GameObject gamePrefab;

    public List<int> highScores;

    private void Start()
    {
        Resources.LoadAll("");

        //Debug.Log(PlayerPrefs.HasKey("test"));

        //Debug.Log(PlayerPrefsX.GetIntArray( "test" ));


        Instantiate(this.introMenuPrefab);
    }

    private void StartGame()
    {
        Instantiate(this.gamePrefab);
    }
}

