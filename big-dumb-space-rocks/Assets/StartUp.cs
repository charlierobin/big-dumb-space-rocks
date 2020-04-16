using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    void Start()
    {
        Resources.LoadAll("");
        UI.Instance.MainMenu();
    }
}
