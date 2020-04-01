using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : Singleton<Asteroids>
{
    public GameObject asteroidPrefab;

    private void Update()
    {
        if (!Chance.OneIn(500)) return;

        var offScreenPositionAndDirection = Chance.SomewhereOffScreen();

        GameObject newAsteroid = Instantiate(Asteroids.Instance.asteroidPrefab, offScreenPositionAndDirection.position, Quaternion.identity);

        newAsteroid.GetComponent<Asteroid>().Initialise(offScreenPositionAndDirection.direction);
    }
}
