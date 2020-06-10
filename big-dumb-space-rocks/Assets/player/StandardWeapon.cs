using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;

    private float timer;
    private float interval;
    private float minimumInterval = 0.2f;
    private float maximumInterval = 0.75f;

    private float superFastInterval = 0.05f;
    private float superFastAmmo;
    private float superFastAmmoMax;
    private bool superFastEnabled;

    private float superFastConsumptionRate = 0.005f;

    private float intervalDecrement = 0.05f;

    private int powerCount = 0;
    private int maxPowerCount = 4;

    private void Start()
    {
        this.interval = this.minimumInterval;

        GameUI.SendMessage("UpdateRateOfFireBar", (1.0f - ((this.interval - this.minimumInterval) / (this.maximumInterval - this.minimumInterval))));

        GameUI.SendMessage("UpdateBulletPowerBar", (this.powerCount * 1.0f) / this.maxPowerCount);

        GameUI.SendMessage("SuperFast", false);
    }

    private void Fire()
    {
        if (Time.time < this.timer) return;

        Rigidbody rb = this.GetComponentInParent<Rigidbody>();

        GameObject newBullet = Instantiate(this.bulletPrefab, this.bulletSpawnPoint.transform.position, Quaternion.identity);

        newBullet.GetComponent<Bullet>().Fire(this.transform, 3.0f + rb.velocity.magnitude, this.powerCount);

        if (this.superFastEnabled)
        {
            this.timer = Time.time + this.superFastInterval;
            this.superFastAmmo = this.superFastAmmo - this.superFastConsumptionRate;

            this.superFastAmmo = Mathf.Max(this.superFastAmmo, 0.0f);

            GameUI.SendMessage("UpdateSuperFastBar", this.superFastAmmo / this.superFastAmmoMax);

            if (this.superFastAmmo == 0.0f)
            {
                this.superFastEnabled = false;
                GameUI.SendMessage("SuperFast", false);
            }
        }
        else
        {
            this.timer = Time.time + this.interval;
        }
    }

    private void PowerUp(PowerUp powerUp)
    {
        if (powerUp.prize == PowerUps.Prize.MorePowerful)
        {
            this.powerCount++;
            this.powerCount = Mathf.Min(this.maxPowerCount, this.powerCount);

            GameUI.SendMessage("UpdateBulletPowerBar", (this.powerCount * 1.0f) / this.maxPowerCount);
        }
        else if (powerUp.prize == PowerUps.Prize.Faster)
        {
            this.interval = this.interval - this.intervalDecrement;
            this.interval = Mathf.Max(this.minimumInterval, this.interval);

            GameUI.SendMessage("UpdateRateOfFireBar", (1.0f - ((this.interval - this.minimumInterval) / (this.maximumInterval - this.minimumInterval))));
        }
        else if (powerUp.prize == PowerUps.Prize.SuperFast)
        {
            if (this.superFastEnabled)
            {
                this.superFastAmmo = this.superFastAmmo + 1.0f;
            }
            else
            {
                this.superFastAmmo = 1.0f;
                this.superFastEnabled = true;
                GameUI.SendMessage("SuperFast", true);
            }
            this.superFastAmmoMax = this.superFastAmmo;
            GameUI.SendMessage("UpdateSuperFastBar", this.superFastAmmo / this.superFastAmmoMax);
        }
    }
}
