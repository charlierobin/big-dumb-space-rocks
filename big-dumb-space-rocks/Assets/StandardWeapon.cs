using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;

    private float timer;
    private float interval = 0.25f;

    private int powerCount = 2;

    private void Fire()
    {
        if (Time.time < this.timer) return;


        Rigidbody2D rb = this.GetComponentInParent<Rigidbody2D>();


        GameObject newBullet = Instantiate(this.bulletPrefab, this.bulletSpawnPoint.transform.position, Quaternion.identity);


        newBullet.GetComponent<Bullet>().Fire(this.transform, 3.0f + rb.velocity.magnitude, this.powerCount);

        this.timer = Time.time + this.interval;
    }

    private void PowerUp(PowerUp powerUp)
    {
        if (powerUp.prize == Prize.MorePowerful)
        {
            this.powerCount++;
        }
        else if (powerUp.prize == Prize.Faster)
        {
            this.interval = this.interval - 0.05f;
            if (this.interval < 0.05f) this.interval = 0.05f;
        }
    }

    public string consoleMessage()
    {
        return "Interval: " + this.interval + "\n" + "Power: " + this.powerCount + "\n";
    }

}
