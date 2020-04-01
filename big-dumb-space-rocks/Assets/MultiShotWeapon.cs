﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShotWeapon : MonoBehaviour
{
    public GameObject launcherPrefab;
    public Transform launcherSpawnLeft;
    public Transform launcherSpawnRight;

    private float timer;
    private float interval = 3.0f;

    private int count = 10;

    private void FireMultiShot()
    {
        if (this.count == 0) return;
        if (Time.time < this.timer) return;

        GameObject launcherLeft = Instantiate(this.launcherPrefab, this.launcherSpawnLeft.position, Quaternion.identity);
        launcherLeft.SetActive(true);

        Rigidbody2D rb = launcherLeft.GetComponent<Rigidbody2D>();
        rb.AddForce(this.transform.right * -1.0f, ForceMode2D.Impulse);
        //rb.AddForce(this.transform.up * 2.0f, ForceMode2D.Impulse);
        launcherLeft.transform.rotation = this.transform.rotation;

        GameObject launcherRight = Instantiate(this.launcherPrefab, this.launcherSpawnRight.position, Quaternion.identity);
        launcherRight.SetActive(true);

        rb = launcherRight.GetComponent<Rigidbody2D>();
        rb.AddForce(this.transform.right * 1.0f, ForceMode2D.Impulse);
        //rb.AddForce(this.transform.up * 2.0f, ForceMode2D.Impulse);
        launcherRight.transform.rotation = this.transform.rotation;

        this.count--;
        this.timer = Time.time + this.interval;
    }

    private void PowerUp(PowerUp powerUp)
    {
        if (powerUp.prize == Prize.MultiPass)
        {
            this.count++;
        }
    }

    public string consoleMessage()
    {
        return "Multishots: " + this.count + "\n";
    }
}