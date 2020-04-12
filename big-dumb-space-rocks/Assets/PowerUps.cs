using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : Singleton<FlyingSaucers>, IPingable
{
    public GameObject powerUpPrefab;

    public void ping()
    {
        GameObject newPowerUp = Instantiate(this.powerUpPrefab, Chance.SomewhereOnScreen(), Quaternion.identity);

        newPowerUp.GetComponent<PowerUp>().Initialise(Chance.RandomPrize());
    }
}

public enum Prize
{
    Faster,
    MorePowerful,
    BigBoom,
    MultiPass,
    Shield
}

