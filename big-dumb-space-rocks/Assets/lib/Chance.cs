﻿using System.Collections;
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

    public static Vector3 SomewhereOnScreen()
    {
        float spawnX = Random.Range(ScreenBounds.Instance.bounds.xMin, ScreenBounds.Instance.bounds.xMax);
        float spawnY = Random.Range(ScreenBounds.Instance.bounds.yMin, ScreenBounds.Instance.bounds.yMax);

        return new Vector3(spawnX, spawnY, 0.0f);
    }

    public enum Axis
    {
        X,
        Y,
        Z
    }

    public static Axis RandomAxis()
    {
        int dir = Chance.RandomIntegerInRange(1, 3);

        if (dir == 1)
        {
            return Axis.X;
        }
        else if (dir == 2)
        {
            return Axis.Y;
        }
        else
        {
            return Axis.Z;
        }
    }

    public enum RotationDirection
    {
        Clockwise,
        AntiClockwise
    }

    public static RotationDirection RandomRotationDirection()
    {
        int dir = Chance.RandomIntegerInRange(1, 2);

        if (dir == 1)
        {
            return RotationDirection.Clockwise;
        }
        else
        {
            return RotationDirection.AntiClockwise;
        }
    }

    public enum Direction
    {
        North,
        West,
        South,
        East
    }

    public static Direction RandomDirection()
    {
        int dir = Chance.RandomIntegerInRange(1, 4);

        if (dir == 1)
        {
            return Direction.North;
        }
        else if (dir == 2)
        {
            return Direction.West;
        }
        else if (dir == 3)
        {
            return Direction.South;
        }
        else
        {
            return Direction.East;
        }
    }

    public static Vector3 SomewhereOffScreen()
    {
        Direction dir = Chance.RandomDirection();

        if (dir == Direction.North)
        {
            return new Vector3(Random.Range(ScreenBounds.Instance.bounds.xMin, ScreenBounds.Instance.bounds.xMax), ScreenBounds.Instance.boundsWithMargin.yMax, 0.0f);
        }
        else if (dir == Direction.West)
        {
            return new Vector3(ScreenBounds.Instance.boundsWithMargin.xMin, Random.Range(ScreenBounds.Instance.bounds.yMin, ScreenBounds.Instance.bounds.yMax), 0.0f);
        }
        else if (dir == Direction.South)
        {
            return new Vector3(Random.Range(ScreenBounds.Instance.bounds.xMin, ScreenBounds.Instance.bounds.xMax), ScreenBounds.Instance.boundsWithMargin.yMin, 0.0f);
        }
        else
        {
            return new Vector3(ScreenBounds.Instance.boundsWithMargin.xMax, Random.Range(ScreenBounds.Instance.bounds.yMin, ScreenBounds.Instance.bounds.yMax), 0.0f);
        }
    }

    private static float Randomise(float angle)
    {
        float spread = 70.0f;

        return Random.Range(angle - spread, angle + spread);
    }

    public static Vector2 DirectionOnScreenFrom(Vector3 from)
    {
        if (from.y > ScreenBounds.Instance.bounds.yMax)
        {
            return Quaternion.AngleAxis(Randomise(180.0f), Vector3.forward) * Vector3.up;
        }

        if (from.y < ScreenBounds.Instance.bounds.yMin)
        {
            return Quaternion.AngleAxis(Randomise(0.0f), Vector3.forward) * Vector3.up;
        }

        if (from.x > ScreenBounds.Instance.bounds.xMax)
        {
            return Quaternion.AngleAxis(Randomise(270.0f), Vector3.forward) * Vector3.up;
        }

        if (from.x < ScreenBounds.Instance.bounds.xMin)
        {
            return Quaternion.AngleAxis(Randomise(90.0f), Vector3.forward) * Vector3.up;
        }

        throw new System.Exception();

        //return new Vector2(0, 0);
    }

    public static PowerUps.Prize RandomPrize()
    {
        int prize = Chance.RandomIntegerInRange(1, System.Enum.GetNames(typeof(PowerUps.Prize)).Length);

        if (prize == 1)
        {
            return PowerUps.Prize.Faster;
        }
        else if (prize == 2)
        {
            return PowerUps.Prize.MorePowerful;
        }
        else if (prize == 3)
        {
            return PowerUps.Prize.BigBoom;
        }
        else if (prize == 4)
        {
            return PowerUps.Prize.MultiPass;
        }
        else if (prize == 5)
        {
            return PowerUps.Prize.Shield;
        }
        else
        {
            return PowerUps.Prize.SuperFast;
        }
    }
}
