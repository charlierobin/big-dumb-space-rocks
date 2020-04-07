using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public void SendToRouting(string message)
    {
        if (Routing.Handle(this.gameObject, message))
        {
            this.gameObject.SendMessage("StartFadeOut");
            Destroy(this.gameObject, 2.5f);
        }
    }
}
