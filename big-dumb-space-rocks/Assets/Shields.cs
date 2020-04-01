using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour
{
    private float power = 5.0f;

    private void Shield()
    {
        this.power = this.power - 0.01f;
    }

    private void PowerUp(PowerUp powerUp)
    {
        if (powerUp.prize==Prize.Shield)
        {
            this.power = this.power + 1.0f;
        }
    }

    public string consoleMessage()
    {
        return "Shield: " + this.power;
    }
}
