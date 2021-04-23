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

    private float intervalDecrement = 0.05f;

    private float superFastInterval = 0.1f;
    private float superFastAmmo;
    private float superFastAmmoMax = 5.0f;
    private bool superFastEnabled;

    private float superFastConsumptionRate = 0.005f;

    private int powerCount = 0;
    private int maxPowerCount = 4;

    private Rigidbody rb;

    private void Start()
    {
        this.interval = this.maximumInterval;
        this.rb = this.GetComponentInParent<Rigidbody>();
    }

    private void Fire()
    {
        if (Time.time < this.timer) return;



        GameObject newBullet = Instantiate(this.bulletPrefab, this.bulletSpawnPoint.transform.position, Quaternion.identity);

        newBullet.GetComponent<Bullet>().Initialise(this.transform, 3.0f + this.rb.velocity.magnitude, this.powerCount);



        if (this.superFastEnabled)
        {
            this.timer = Time.time + this.superFastInterval;
            this.superFastAmmo = this.superFastAmmo - this.superFastConsumptionRate;

            this.superFastAmmo = Mathf.Max(this.superFastAmmo, 0.0f);

            //Globals.Instance.SendMessage("UpdateSuperFastBar", this.superFastAmmo / this.superFastAmmoMax);

            if (this.superFastAmmo == 0.0f)
            {
                this.superFastEnabled = false;
                //Globals.Instance.SendMessage("SuperFast", false);
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

            //GameUI.SendMessage("UpdateBulletPowerBar", (this.powerCount * 1.0f) / this.maxPowerCount);
        }
        else if (powerUp.prize == PowerUps.Prize.Faster)
        {
            this.interval = this.interval - this.intervalDecrement;
            this.interval = Mathf.Max(this.minimumInterval, this.interval);

            //GameUI.SendMessage("UpdateRateOfFireBar", (1.0f - ((this.interval - this.minimumInterval) / (this.maximumInterval - this.minimumInterval))));
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
                //GameUI.SendMessage("SuperFast", true);
            }
            this.superFastAmmoMax = this.superFastAmmo;
            //GameUI.SendMessage("UpdateSuperFastBar", this.superFastAmmo / this.superFastAmmoMax);
        }
    }

    private void GUI()
    {
        GUILayout.BeginVertical(GUILayout.Width(150));

        {
            if (GUILayout.Button("Powercount +1"))
            {
                //this.superFastEnabled = true;
                this.powerCount = this.powerCount + 1;
                this.powerCount = Mathf.Min(this.maxPowerCount, this.powerCount);
            }

            if (GUILayout.Button("Powercount -1"))
            {
                //this.superFastEnabled = true;
                this.powerCount = this.powerCount - 1;
                this.powerCount = Mathf.Max(0, this.powerCount);
            }

            GUILayout.Label("Powercount: " + this.powerCount.ToString());
        }

        GUILayout.Space(5);

        {
            if (GUILayout.Button("Interval +"))
            {
                this.interval = this.interval + this.intervalDecrement;
                this.interval = Mathf.Min(this.maximumInterval, this.interval);
            }

            if (GUILayout.Button("Interval -"))
            {
                this.interval = this.interval - this.intervalDecrement;
                this.interval = Mathf.Max(this.minimumInterval, this.interval);
            }

            GUILayout.Label("Interval: " + this.interval.ToString());
        }

        GUILayout.Space(5);

        {
            if (GUILayout.Button("Superfast + (" + this.superFastAmmo.ToString() + ")"))
            {
                this.superFastEnabled = true;
                this.superFastAmmo = this.superFastAmmo + 1.0f;
                this.superFastAmmo = Mathf.Min(this.superFastAmmoMax, this.superFastAmmo);
            }
        }
        GUILayout.EndVertical();
    }
}
