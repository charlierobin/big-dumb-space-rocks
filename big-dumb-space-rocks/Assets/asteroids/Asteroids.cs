using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : Singleton<Asteroids>
{
    public GameObject asteroidPrefab;

    public void create()
    {
        GameObject newAsteroid = Instantiate(this.asteroidPrefab, Chance.SomewhereOffScreen(ZLayers.Instance.objects), Quaternion.identity);

        newAsteroid.GetComponent<Asteroid>().Initialise(Chance.DirectionOnScreenFrom(newAsteroid.transform.position));
    }

    public void create(Vector2 position, int factor, GameObject bullet)
    {
        GameObject newAsteroid = Instantiate(this.asteroidPrefab, new Vector3(position.x, position.y, ZLayers.Instance.objects), Quaternion.identity);

        newAsteroid.GetComponent<Asteroid>().Initialise(factor, bullet);
    }

    public void GUI()
    {
        if (GUILayout.Button("Create asteroid"))
        {
            this.create();
        }
    }
}

