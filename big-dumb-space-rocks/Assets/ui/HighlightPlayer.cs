using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightPlayer : MonoBehaviour
{
    public Gradient colourOverTime;

    private int pointer = 0;
    private int limit = 99;

    private static List<Sprite> frames;

    private bool wait;

    private void Start()
    {
        if (HighlightPlayer.frames == null)
        {
            HighlightPlayer.frames = new List<Sprite>();

            for (int i = 0; i <= this.limit; i++)
            {
                HighlightPlayer.frames.Add(Resources.Load<Sprite>("shockwave/shockwave_" + i.ToString("00000")));
            }
        }
    }

    private void Update()
    {
        UnityEngine.UI.Image image = this.GetComponent<UnityEngine.UI.Image>();

        image.color = this.colourOverTime.Evaluate((1.0f * this.pointer) / this.limit);

        if (!this.wait)
        {
            if (this.pointer <= this.limit)
            {
                image.sprite = HighlightPlayer.frames[this.pointer];

                this.pointer++;

                this.wait = true;
            }
        }
        else
        {
            this.wait = false;

            if (this.pointer > this.limit)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
