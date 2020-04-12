using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSaucers : Singleton<FlyingSaucers>
{
    public GameObject flyingSaucerPrefab;

    public void create()
    {
        GameObject newFlyingSaucer = Instantiate(this.flyingSaucerPrefab, Chance.SomewhereOffScreen(), Quaternion.identity);

        newFlyingSaucer.GetComponent<FlyingSaucer>().Initialise(Chance.DirectionOnScreenFrom(newFlyingSaucer.transform.position));
    }
}
