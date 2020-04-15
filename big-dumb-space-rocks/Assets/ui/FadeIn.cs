using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public float duration = 1.0f;

    private float started;

    private bool fading;
    private float alpha = 0.0f;

    private void StartFadeIn()
    {
        this.fading = true;
        this.started = Time.time;
    }

    private void Start()
    {
        this.GetComponent<UnityEngine.CanvasGroup>().alpha = this.alpha;
        this.StartFadeIn();
    }

    private void Update()
    {
        if (this.fading)
        {
            this.alpha = Mathf.Lerp(0.0f, 1.0f, (Time.time - this.started) / this.duration);
            this.GetComponent<UnityEngine.CanvasGroup>().alpha = this.alpha;

            if (this.alpha >= 1.0f)
            {
                this.gameObject.SendMessageUpwards("FadeInDone", SendMessageOptions.DontRequireReceiver);
                this.fading = false;
            }
        }
    }
}
