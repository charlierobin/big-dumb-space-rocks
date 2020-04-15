using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    private void Update()
    {
        if (!ScreenBounds.Instance.bounds.Contains(this.transform.position))
        {
            Destroy(this.gameObject);
        }
    }
}
