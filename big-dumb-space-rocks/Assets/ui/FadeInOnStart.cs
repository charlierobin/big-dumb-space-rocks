using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOnStart : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.GetComponent<UIScreenController>().Show();
    }
}
