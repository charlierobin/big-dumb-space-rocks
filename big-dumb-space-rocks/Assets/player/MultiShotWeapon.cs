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

    private void Start()
    {
        GameUI.SendMessage("UpdateMultiShotCount", this.count);
    }

    private void FireMultiShot()
    {
        if (this.count == 0) return;
        if (Time.time < this.timer) return;

        GameObject launcherLeft = Instantiate(this.launcherPrefab, this.launcherSpawnLeft.position, Quaternion.identity);
        
        Rigidbody rb = launcherLeft.GetComponent<Rigidbody>();
        rb.AddForce(this.transform.right * -1.0f, ForceMode.Impulse);
        //rb.AddForce(this.transform.up * 2.0f, ForceMode2D.Impulse);
        launcherLeft.transform.rotation = this.transform.rotation;

        GameObject launcherRight = Instantiate(this.launcherPrefab, this.launcherSpawnRight.position, Quaternion.identity);
  
        rb = launcherRight.GetComponent<Rigidbody>();
        rb.AddForce(this.transform.right * 1.0f, ForceMode.Impulse);
        //rb.AddForce(this.transform.up * 2.0f, ForceMode2D.Impulse);
        launcherRight.transform.rotation = this.transform.rotation;

        this.count--;
        this.timer = Time.time + this.interval;
        GameUI.SendMessage("UpdateMultiShotCount", this.count);
    }

    private void PowerUp(PowerUp powerUp)
    {
        if (powerUp.prize == PowerUps.Prize.MultiPass)
        {
            this.count++;
            GameUI.SendMessage("UpdateMultiShotCount", this.count);
        }
    }
}
