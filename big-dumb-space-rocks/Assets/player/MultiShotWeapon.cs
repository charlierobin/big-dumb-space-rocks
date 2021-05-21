using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShotWeapon : MonoBehaviour
{
    public GameObject launcherPrefab;
    public Transform launcherSpawnLeft;
    public Transform launcherSpawnRight;

    private float timer;
    private float interval = 3.0f;

    private int count = 12;

    private int powerCount = 1;
    private int maxPowerCount = 4;

    private void Start()
    {
        //GameUI.SendMessage("UpdateMultiShotCount", this.count);
    }

    private void FireMultiShot()
    {
        if (this.count == 0) return;
        if (Time.time < this.timer) return;

        GameObject launcherLeft = Instantiate(this.launcherPrefab, this.launcherSpawnLeft.position, Quaternion.identity);

        launcherLeft.gameObject.GetComponent<MultiShotLauncher>().powerCount = this.powerCount;

        Rigidbody rb = launcherLeft.GetComponent<Rigidbody>();

        rb.AddForce(this.transform.right * -1.0f, ForceMode.Impulse);
        //rb.AddForce(this.transform.up * 2.0f, ForceMode2D.Impulse);

        launcherLeft.transform.rotation = this.transform.rotation;

        GameObject launcherRight = Instantiate(this.launcherPrefab, this.launcherSpawnRight.position, Quaternion.identity);

        launcherRight.gameObject.GetComponent<MultiShotLauncher>().powerCount = this.powerCount;

        rb = launcherRight.GetComponent<Rigidbody>();

        rb.AddForce(this.transform.right * 1.0f, ForceMode.Impulse);
        //rb.AddForce(this.transform.up * 2.0f, ForceMode2D.Impulse);

        launcherRight.transform.rotation = this.transform.rotation;

        this.count--;
        this.timer = Time.time + this.interval;
        //GameUI.SendMessage("UpdateMultiShotCount", this.count);
    }

    private void PowerUp(PowerUp powerUp)
    {
        if (powerUp.prize == PowerUps.Prize.MultiPass)
        {
            this.count++;
            //GameUI.SendMessage("UpdateMultiShotCount", this.count);
        }
    }

    public void IncrementPower()
    {
        this.powerCount++;
        this.powerCount = Mathf.Min(this.maxPowerCount, this.powerCount);
    }

    private void GUI()
    {
        GUILayout.BeginVertical(GUILayout.Width(150));

        if (GUILayout.Button("MS + (" + this.count.ToString() + ")"))
        {
            this.count = this.count + 1;
        }

        if (GUILayout.Button("Powercount +1"))
        {
            this.powerCount = this.powerCount + 1;
            this.powerCount = Mathf.Min(this.maxPowerCount, this.powerCount);
        }

        if (GUILayout.Button("Powercount -1"))
        {
            this.powerCount = this.powerCount - 1;
            this.powerCount = Mathf.Max(0, this.powerCount);
        }

        GUILayout.Label("Powercount: " + this.powerCount.ToString());

        GUILayout.EndVertical();
    }

}
