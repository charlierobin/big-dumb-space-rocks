using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : Singleton<Pause>
{
    public float delta = 0.05f;

    private bool pausing;
    private bool paused;

    private bool unpausing;

    private float timeScale;

    private void Start()
    {
        this.timeScale = Time.timeScale;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!this.pausing && !this.paused)
            {
                this.pausing = true;
                UI.Instance.ShowPause();
            }
            else if (this.paused)
            {
                this.unpausing = true;
                UI.Instance.HidePause();
            }
        }

        if (this.pausing)
        {
            if (this.timeScale > 0.0f)
            {
                this.timeScale = this.timeScale - this.delta;
                this.timeScale = Mathf.Max(this.timeScale, 0.0f);
                Time.timeScale = this.timeScale;
            }
            else
            {
                this.pausing = false;
                this.paused = true;
            }
        }
        else if (this.unpausing)
        {
            if (this.timeScale < 1.0f)
            {
                this.timeScale = this.timeScale + this.delta;
                this.timeScale = Mathf.Min(this.timeScale, 1.0f);
                Time.timeScale = this.timeScale;
            }
            else
            {
                this.unpausing = false;
                this.paused = false;
            }
        }
    }

    public void UnPause()
    {
        this.unpausing = true;
    }
}
