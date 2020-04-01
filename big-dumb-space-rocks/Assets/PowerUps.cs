using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameObject powerUpPrefab;

    private void Update()
    {
        if (!Chance.OneIn(500)) return;

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

