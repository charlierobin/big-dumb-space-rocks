using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAroundScreen : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (this.transform.position.y >= ScreenBounds.Instance.bounds.yMax)
        {
            this.transform.position = new Vector2(this.transform.position.x, ScreenBounds.Instance.bounds.yMin);
        }
        else if (this.transform.position.y <= ScreenBounds.Instance.bounds.yMin)
        {
            this.transform.position = new Vector2(this.transform.position.x, ScreenBounds.Instance.bounds.yMax);
        }

        if (this.transform.position.x >= ScreenBounds.Instance.bounds.xMax)
        {
            this.transform.position = new Vector2(ScreenBounds.Instance.bounds.xMin, this.transform.position.y);
        }
        else if (this.transform.position.x <= ScreenBounds.Instance.bounds.xMin)
        {
            this.transform.position = new Vector2(ScreenBounds.Instance.bounds.xMax, this.transform.position.y);
        }
    }
}
