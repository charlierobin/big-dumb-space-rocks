using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private static void Quit()
    {
        Application.Quit();
    }

    public static int test;

    public static void show(Screens screen)
    {
        if (screen == Screens.MainMenu)
        {


        }
        else
        {
            throw new System.Exception("Unrecognised Screens enumeration");
        }
    }

    public enum Screens
    {
        MainMenu
    }
}


