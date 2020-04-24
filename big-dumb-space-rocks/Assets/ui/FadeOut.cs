using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : Fade
{
    public void Begin()
    {
        this.fading = true;
        this.started = Time.realtimeSinceStartup;
    }

    private void Update()
    {
        if (this.fading)
        {
            this.alpha = Mathf.Lerp(1.0f, 0.0f, (Time.realtimeSinceStartup - this.started) / this.duration);

            this.apply();

            if (this.alpha <= 0.0f)
            {
                if (this.sendMessage)
                {
                    this.gameObject.SendMessageUpwards("FadeOutDone", SendMessageOptions.DontRequireReceiver);
                }

                this.fading = false;

                if (this.deactivateOnDone)
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}
