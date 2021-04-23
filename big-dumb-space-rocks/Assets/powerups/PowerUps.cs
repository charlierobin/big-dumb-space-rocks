using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : Singleton<PowerUps>
{
    public GameObject powerUpPrefab;

    public void create()
    {
        this.create(this.random());
    }

    public void create(Prize type)
    {
        GameObject newPowerUp = Instantiate(this.powerUpPrefab, Chance.SomewhereOnScreen(ZLayers.Instance.objects), Quaternion.identity);

        newPowerUp.GetComponent<PowerUp>().Initialise(type);
    }

    private Prize random()
    {
        int prize = Chance.RandomIntegerInRange(1, System.Enum.GetNames(typeof(Prize)).Length);

        if (prize == 1)
        {
            return Prize.Faster;
        }
        else if (prize == 2)
        {
            return Prize.MorePowerful;
        }
        else if (prize == 3)
        {
            return Prize.BigBoom;
        }
        else if (prize == 4)
        {
            return Prize.MultiPass;
        }
        else if (prize == 5)
        {
            return Prize.Shield;
        }
        else
        {
            return Prize.SuperFast;
        }
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

    public void GUI()
    {
        if (GUILayout.Button("Create random powerup"))
        {
            this.create();
        }

        GUILayout.Space(5);

        if (GUILayout.Button("Create Faster"))
        {
            this.create(PowerUps.Prize.Faster);
        }

        if (GUILayout.Button("Create MorePowerful"))
        {
            this.create(PowerUps.Prize.MorePowerful);
        }

        if (GUILayout.Button("Create BigBoom"))
        {
            this.create(PowerUps.Prize.BigBoom);
        }

        if (GUILayout.Button("Create MultiPass"))
        {
            this.create(PowerUps.Prize.MultiPass);
        }

        if (GUILayout.Button("Create Shield"))
        {
            this.create(PowerUps.Prize.Shield);
        }

        if (GUILayout.Button("Create SuperFast"))
        {
            this.create(PowerUps.Prize.SuperFast);
        }
    }
}

