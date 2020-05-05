using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : Singleton<PowerUps>
{
    public GameObject powerUpPrefab;

    public void create()
    {
        GameObject newPowerUp = Instantiate(this.powerUpPrefab, Chance.SomewhereOnScreen(), Quaternion.identity);

        newPowerUp.GetComponent<PowerUp>().Initialise(Chance.RandomPrize());
    }

    public enum Prize
    {
        Faster,
        MorePowerful,
        BigBoom,
        MultiPass,
        Shield,
        SuperFast
    }
}

