﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSaucers : Singleton<FlyingSaucers>
{
    public GameObject bigFlyingSaucerPrefab;
    public GameObject littleFlyingSaucerPrefab;

    public void createBig()
    {
        GameObject newFlyingSaucer = Instantiate(this.bigFlyingSaucerPrefab, Chance.SomewhereOffScreen(), Quaternion.identity);

        newFlyingSaucer.GetComponent<FlyingSaucer>().Initialise(Chance.DirectionOnScreenFrom(newFlyingSaucer.transform.position));
    }

    public void createLittle()
    {
        GameObject newFlyingSaucer = Instantiate(this.littleFlyingSaucerPrefab, Chance.SomewhereOffScreen(), Quaternion.identity);

        newFlyingSaucer.GetComponent<FlyingSaucer>().Initialise(Chance.DirectionOnScreenFrom(newFlyingSaucer.transform.position));
    }

}