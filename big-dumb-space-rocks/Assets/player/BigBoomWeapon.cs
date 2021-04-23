using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoomWeapon : MonoBehaviour
{
    public GameObject bigBoomPrefab;
    public GameObject bulletSpawnPoint;

    //private Light globalLighting;

    private float timer;
    private float interval = 0.25f;

    private float keyDownTimer = 0.0f;
    private float keyDownSensitivity = 0.5f;

    private int count = 10;

    private GameObject newBullet;

    private void Start()
    {
        //this.globalLighting = F


        //GameUI.SendMessage("UpdateBigBoomCount", this.count);
    }

    private void FireBigBoom()
    {
        if (this.count == 0) return;
        if (Time.time < this.timer) return;

        this.newBullet = Instantiate(this.bigBoomPrefab, this.bulletSpawnPoint.transform.position, Quaternion.identity);
        this.newBullet.GetComponent<BulletBigBoom>().Fire(this.transform, 5.0f);

        this.count--;

        this.timer = Time.time + this.interval;
        this.keyDownTimer = Time.time + this.keyDownSensitivity;

        //GameUI.SendMessage("UpdateBigBoomCount", this.count);
    }

    private void Update()
    {
        if (Time.timeScale == 0) return;

        if (Input.GetButtonUp("Fire2"))
        {
            if (Time.time > this.keyDownTimer)
            {
                if (this.newBullet != null)
                {
                    this.newBullet.GetComponent<BulletBigBoom>().ExplodedByUser();
                }
            }
            this.newBullet = null;
        }
    }

    private void PowerUp(PowerUp powerUp)
    {
        if (powerUp.prize == PowerUps.Prize.BigBoom)
        {
            this.count++;
            //GameUI.SendMessage("UpdateBigBoomCount", this.count);
        }
    }

    private void GUI()
    {
        GUILayout.BeginVertical(GUILayout.Width(150));

        if (GUILayout.Button("BBW + (" + this.count.ToString() + ")"))
        {
            this.count = this.count + 1;
        }

        GUILayout.EndVertical();
    }
}


