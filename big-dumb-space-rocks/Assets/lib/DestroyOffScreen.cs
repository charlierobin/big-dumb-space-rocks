using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (!ScreenBounds.Instance.boundsWrap.Contains(this.transform.position))
        {
            Destroy(this.gameObject);
        }
    }
}
