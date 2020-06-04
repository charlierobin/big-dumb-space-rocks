using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUI : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 250, 30), "Create asteroid"))
        {
            Asteroids.Instance.create();
        }

        if (GUI.Button(new Rect(10, 50, 250, 30), "Create large flying saucer"))
        {
            FlyingSaucers.Instance.createBig();
        }

        if (GUI.Button(new Rect(10, 90, 250, 30), "Create small flying saucer"))
        {
            FlyingSaucers.Instance.createSmall();
        }

        if (GUI.Button(new Rect(10, 130, 250, 30), "Create Faster power up"))
        {
            PowerUps.Instance.create(PowerUps.Prize.Faster);
        }

        if (GUI.Button(new Rect(10, 170, 250, 30), "Create MorePowerful power up"))
        {
            PowerUps.Instance.create(PowerUps.Prize.MorePowerful);
        }

        if (GUI.Button(new Rect(10, 210, 250, 30), "Create BigBoom power up"))
        {
            PowerUps.Instance.create(PowerUps.Prize.BigBoom);
        }

        if (GUI.Button(new Rect(10, 250, 250, 30), "Create MultiPass power up"))
        {
            PowerUps.Instance.create(PowerUps.Prize.MultiPass);
        }

        if (GUI.Button(new Rect(10, 290, 250, 30), "Create Shield power up"))
        {
            PowerUps.Instance.create(PowerUps.Prize.Shield);
        }

        if (GUI.Button(new Rect(10, 330, 250, 30), "Create SuperFast power up"))
        {
            PowerUps.Instance.create(PowerUps.Prize.SuperFast);
        }

        if (GUI.Button(new Rect(10, 370, 250, 30), "Create random power up"))
        {
            PowerUps.Instance.create();
        }
    }
}
