using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightPlayer : MonoBehaviour
{
    private int pointer = 0;
    private int limit = 99;

    private List<Sprite> frames;

    private bool wait;

    private void Start()
    {
        this.frames = new List<Sprite>();

        for (int i = 0; i <= this.limit; i++)
        {
            this.frames.Add(Resources.Load<Sprite>("shockwave/shockwave_" + i.ToString("00000")));
        }
    }

    private void Update()
    {
        UnityEngine.UI.Image image = this.GetComponent<UnityEngine.UI.Image>();

        //if (this.pointer < 3)
        //{
        //    image.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        //}
        //else
        //{
        //    image.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        //}

        if (!this.wait)
        {
            if (this.pointer <= this.limit)
            {
                image.sprite = this.frames[this.pointer];

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
