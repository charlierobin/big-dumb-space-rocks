using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShotLauncher : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;

    private float timer = 0.0f;
    private float interval = 0.15f;

    public int powerCount = 1;

    private void Start()
    {
        Destroy(this.gameObject, 2.00f);
    }

    private void Update()
    {
        if (Time.time < this.timer) return;

        GameObject newBullet = Instantiate(this.bulletPrefab, this.spawnPoint.position, Quaternion.identity);
        newBullet.GetComponent<Bullet>().Initialise(this.transform, 4.0f, this.powerCount);

        this.timer = Time.time + this.interval;
    }
}
