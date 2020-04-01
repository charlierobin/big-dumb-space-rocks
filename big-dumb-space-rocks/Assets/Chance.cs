using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chance
{
    public static bool CoinToss()
    {
        return Random.Range(0, 2) == 0;
    }

    public static int RandomIntegerInRange(int from, int to)
    {
        return Random.Range(from, to + 1);
    }

    public static bool OneIn(int range)
    {
        if (Chance.RandomIntegerInRange(1, range) > 1) return false;
        return true;
    }

    public static Vector2 SomewhereOnScreen()
    {
        float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        return new Vector2(spawnX, spawnY);
    }

    public static (Vector2 position, Vector2 direction) SomewhereOffScreen()
    {
        float vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;
        float horizExtent = vertExtent * Screen.width / Screen.height;

        float margin = 0.5f;

        vertExtent = vertExtent + margin;
        horizExtent = horizExtent + margin;

        float x;
        float y;

        int sector = Random.Range(1, 5);

        switch (sector)
        {
            case 1:  // north

                y = vertExtent;
                x = Random.Range(-horizExtent, horizExtent);

                break;

            case 2:  // south

                y = -vertExtent;
                x = Random.Range(-horizExtent, horizExtent);

                break;

            case 3:  // west

                y = Random.Range(-vertExtent, vertExtent);
                x = -horizExtent;

                break;

            case 4:  // east

                y = Random.Range(-vertExtent, vertExtent);
                x = horizExtent;

                break;

            default:

                throw new System.Exception("Unrecognised sector");
        }

        Vector2 direction;

        switch (sector)
        {
            case 1:  // north

                direction = new Vector2(0, -Random.Range(0.5f, 1.0f));

                break;

            case 2:  // south

                direction = new Vector2(0, Random.Range(0.5f, 1.0f));

                break;

            case 3:  // west

                direction = new Vector2(Random.Range(0.5f, 1.0f), 0);

                break;

            case 4:  // east

                direction = new Vector2(-Random.Range(0.5f, 1.0f), 0);

                break;

            default:

                throw new System.Exception("Unrecognised sector");
        }

        return (new Vector2(x, y), direction);
    }

    public static Prize RandomPrize()
    {
        int prize = Chance.RandomIntegerInRange(1, 5);

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
        else
        {
            return Prize.Shield;
        }
    }
}
