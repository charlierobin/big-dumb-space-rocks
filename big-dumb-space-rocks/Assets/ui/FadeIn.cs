using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    private bool fading;
    private float alpha = 0.0f;

    private void StartFadeIn()
    {
        this.fading = true;
    }

    private void Start()
    {
        this.GetComponent<UnityEngine.CanvasGroup>().alpha = this.alpha;
        this.fading = true;
    }

    private void Update()
    {
        if (this.fading)
        {
            this.alpha = this.alpha + 0.005f;

            if (this.alpha > 1.0f)
            {
                this.gameObject.SendMessage("FadeInDone", SendMessageOptions.DontRequireReceiver);
                this.fading = false;
            }
            else
            {
                this.GetComponent<UnityEngine.CanvasGroup>().alpha = this.alpha;
            }
        }
    }
}
