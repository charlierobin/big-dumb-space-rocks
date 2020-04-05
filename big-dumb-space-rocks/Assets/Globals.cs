using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public GameObject introMenuPrefab;
    public GameObject gamePrefab;

    private void Start()
    {
        Instantiate(this.introMenuPrefab);
    }

    private void StartGame()
    {
        Instantiate(this.gamePrefab);
    }
}

