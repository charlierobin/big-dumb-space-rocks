using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : Singleton<Players>
{
    public GameObject playerPrefab;

    private void Start()
    {
        Instantiate(this.playerPrefab);
    }
}

