using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : Singleton<PowerUps>
{
    public GameObject powerUpPrefab;

    public void create()
    {
        this.create(Chance.RandomPrize());
    }

    public void create(Prize type)
    {
        GameObject newPowerUp = Instantiate(this.powerUpPrefab, Chance.SomewhereOnScreen(), Quaternion.identity);

        newPowerUp.GetComponent<PowerUp>().Initialise(type);
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

