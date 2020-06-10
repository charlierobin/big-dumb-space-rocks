using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAroundScreen : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (this.transform.position.y > ScreenBounds.Instance.boundsWrap.yMax)
        {
            this.transform.position = new Vector2(this.transform.position.x, ScreenBounds.Instance.boundsSpawn.yMin);
        }
        else if (this.transform.position.y < ScreenBounds.Instance.boundsWrap.yMin)
        {
            this.transform.position = new Vector2(this.transform.position.x, ScreenBounds.Instance.boundsSpawn.yMax);
        }

        if (this.transform.position.x > ScreenBounds.Instance.boundsWrap.xMax)
        {
            this.transform.position = new Vector2(ScreenBounds.Instance.boundsSpawn.xMin, this.transform.position.y);
        }
        else if (this.transform.position.x < ScreenBounds.Instance.boundsWrap.xMin)
        {
            this.transform.position = new Vector2(ScreenBounds.Instance.boundsSpawn.xMax, this.transform.position.y);
        }
    }
}
