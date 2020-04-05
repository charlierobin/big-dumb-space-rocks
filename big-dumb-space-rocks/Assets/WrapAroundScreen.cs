using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAroundScreen : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (this.transform.position.y > ScreenBounds.Instance.boundsWithMargin.yMax)
        {
            this.transform.position = new Vector2(this.transform.position.x, ScreenBounds.Instance.boundsWithMargin.yMin);
        }
        else if (this.transform.position.y < ScreenBounds.Instance.boundsWithMargin.yMin)
        {
            this.transform.position = new Vector2(this.transform.position.x, ScreenBounds.Instance.boundsWithMargin.yMax);
        }

        if (this.transform.position.x > ScreenBounds.Instance.boundsWithMargin.xMax)
        {
            this.transform.position = new Vector2(ScreenBounds.Instance.boundsWithMargin.xMin, this.transform.position.y);
        }
        else if (this.transform.position.x < ScreenBounds.Instance.boundsWithMargin.xMin)
        {
            this.transform.position = new Vector2(ScreenBounds.Instance.boundsWithMargin.xMax, this.transform.position.y);
        }
    }
}
