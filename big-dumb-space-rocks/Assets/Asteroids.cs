using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : Singleton<Asteroids>, IPingable
{
    public GameObject asteroidPrefab;

    public void ping()
    {
        GameObject newAsteroid = Instantiate(Asteroids.Instance.asteroidPrefab, Chance.SomewhereOffScreen(), Quaternion.identity);

        newAsteroid.GetComponent<Asteroid>().Initialise(Chance.DirectionOnScreenFrom(newAsteroid.transform.position));
    }
}
