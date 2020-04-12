using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSaucers : Singleton<FlyingSaucers>, IPingable
{
    public GameObject flyingSaucerPrefab;

    public void ping()
    {
        GameObject newFlyingSaucer = Instantiate(this.flyingSaucerPrefab, Chance.SomewhereOffScreen(), Quaternion.identity);

        newFlyingSaucer.GetComponent<FlyingSaucer>().Initialise(Chance.DirectionOnScreenFrom(newFlyingSaucer.transform.position));
    }
}
