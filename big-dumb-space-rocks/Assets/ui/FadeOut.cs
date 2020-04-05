using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public UnityEngine.UI.Image[] elements;

    private bool fadingOut;
    private float alpha = 1.0f;

    private void StartFadeOut()
    {
        this.fadingOut = true;
    }

    private void Update()
    {
        if (this.fadingOut)
        {
            this.alpha = this.alpha - 0.005f;

            if (this.alpha < 0.0f)
            {
                this.gameObject.SendMessage("FadeOutDone", SendMessageOptions.DontRequireReceiver);
                this.fadingOut = false;
            }
            else
            {
                foreach (UnityEngine.UI.Image element in this.elements)
                {
                    element.color = new Color(element.color.r, element.color.g, element.color.b, this.alpha);
                }
            }
        }
    }
}
