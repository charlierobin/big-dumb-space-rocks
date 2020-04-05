using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroUI : MonoBehaviour
{
    private void StartGame()
    {
        GameObject globals = GameObject.Find("/Globals");

        globals.SendMessage("StartGame");

        this.gameObject.SendMessage("StartFadeOut");

        Destroy(this.gameObject, 2.0f);
    }
}
