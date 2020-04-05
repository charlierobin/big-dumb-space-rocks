using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSaucers : MonoBehaviour
{
    public GameObject flyingSaucerPrefab;

    private void Update()
    {
        if (Random.Range(1, 1500) == 1)
        {
            GameObject newFlyingSaucer = Instantiate(this.flyingSaucerPrefab, Chance.SomewhereOffScreen(), Quaternion.identity);

            newFlyingSaucer.GetComponent<FlyingSaucer>().Initialise(Chance.DirectionOnScreenFrom(newFlyingSaucer.transform.position));
        }
    }


}
