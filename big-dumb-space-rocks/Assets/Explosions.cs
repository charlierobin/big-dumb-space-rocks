using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : Singleton<Explosions>
{
    public GameObject explosion1;
    public GameObject explosion2;

    public GameObject littleExplosionPrefab;

    public GameObject sparksPrefab;

    public void newAt(Transform transform)
    {
        GameObject explosionPrefab = null;

        if(Chance.CoinToss())
        {
            explosionPrefab = this.explosion1;
        }
        else
        {
            explosionPrefab = this.explosion2;
        }

        GameObject newExplosion = Instantiate(explosionPrefab, new Vector3(transform.position.x, transform.position.y, -4.0f), Quaternion.identity);

        newExplosion.SetActive(true);
    }

    public void littleExplosionAt(Transform transform)
    {
        GameObject newExplosion = Instantiate(this.littleExplosionPrefab, new Vector3(transform.position.x, transform.position.y, -4.0f), Quaternion.identity);

        newExplosion.SetActive(true);
    }

    public void sparksAt(Transform transform, GameObject bullet)
    {
        GameObject sparks = Instantiate(sparksPrefab, new Vector3(transform.position.x, transform.position.y, -4.0f), bullet.transform.rotation);

        sparks.SetActive(true);
    }
}

