using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSaucers : MonoBehaviour
{
    public GameObject flyingSaucerPrefab;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Random.Range(1, 1500) == 1)
        {
            var offScreenPositionAndDirection = Chance.SomewhereOffScreen();

            GameObject newFlyingSaucer = Instantiate(this.flyingSaucerPrefab, offScreenPositionAndDirection.position, Quaternion.identity);

            newFlyingSaucer.GetComponent<FlyingSaucer>().Initialise(offScreenPositionAndDirection.direction);
        }
    }


   

}
