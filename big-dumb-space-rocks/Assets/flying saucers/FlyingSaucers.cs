using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSaucers : Singleton<FlyingSaucers>
{
    public GameObject bigFlyingSaucerPrefab;
    public GameObject littleFlyingSaucerPrefab;

    public void createBig()
    {
        GameObject newFlyingSaucer = Instantiate(this.bigFlyingSaucerPrefab, Chance.SomewhereOffScreen(ZLayers.Instance.objects), Quaternion.identity);

        newFlyingSaucer.GetComponent<FlyingSaucer>().Initialise(Chance.DirectionOnScreenFrom(newFlyingSaucer.transform.position));
    }

    public void createSmall()
    {
        GameObject newFlyingSaucer = Instantiate(this.littleFlyingSaucerPrefab, Chance.SomewhereOffScreen(ZLayers.Instance.objects), Quaternion.identity);

        newFlyingSaucer.GetComponent<FlyingSaucer>().Initialise(Chance.DirectionOnScreenFrom(newFlyingSaucer.transform.position));
    }

    public void GUI()
    {
        if (GUILayout.Button("Create big flying saucer"))
        {
            this.createBig();
        }

        if (GUILayout.Button("Create small flying saucer"))
        {
            this.createSmall();
        }
    }
}
