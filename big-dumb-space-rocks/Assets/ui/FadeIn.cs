using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : Fade
{
    public void Begin()
    {
        this.fading = true;
        this.started = Time.realtimeSinceStartup;

        this.alpha = 0.0f;

        this.gameObject.GetComponent<UnityEngine.CanvasGroup>().alpha = this.alpha;
    }

    private void Update()
    {
        if (this.fading)
        {
            this.alpha = Mathf.Lerp(0.0f, 1.0f, (Time.realtimeSinceStartup - this.started) / this.duration);

            this.apply();

            if (this.alpha >= 1.0f)
            {
                if (this.sendMessage)
                {
                    this.gameObject.SendMessageUpwards("FadeInDone", SendMessageOptions.DontRequireReceiver);
                }

                this.fading = false;
            }
        }
    }
}
