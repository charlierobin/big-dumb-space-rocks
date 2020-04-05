using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour
{
    private float power = 5.0f;

    private bool on;

    private void ShieldUp()
    {
        if (this.power <= 0) return;

        this.on = true;
        this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    private void ShieldDown()
    {
        this.on = false;
        this.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    }

    private void Update()
    {
        if (this.on)
        {
            this.power = this.power - 0.01f;

            if (this.power < 0)
            {
                this.power = 0.0f;
                this.ShieldDown();
            }
        }
    }

    private void PowerUp(PowerUp powerUp)
    {
        if (powerUp.prize == Prize.Shield)
        {
            this.power = this.power + 1.0f;
        }
    }

    public string consoleMessage()
    {
        return "Shield: " + this.power;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.on)
        {
            collision.gameObject.SendMessage("ShieldHit", SendMessageOptions.DontRequireReceiver);
        }
    }
}
