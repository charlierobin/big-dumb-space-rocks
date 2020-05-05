using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScreenBounds : Singleton<ScreenBounds>
{
    public Rect bounds;
    public Rect boundsWithMargin;
    public float margin;

    private void Start()
    {
        float vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;
        float horizExtent = vertExtent * ((Screen.width * 1.0f) / Screen.height);

        this.bounds = new Rect(-horizExtent, -vertExtent, horizExtent * 2, vertExtent * 2);

        this.boundsWithMargin = new Rect(-horizExtent - this.margin, -vertExtent - this.margin, (horizExtent * 2) + this.margin + this.margin, (vertExtent * 2) + this.margin + this.margin);
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        float vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;
        float horizExtent = vertExtent * Camera.main.GetComponent<Camera>().aspect;

        Rect cameraBounds = new Rect(-horizExtent, -vertExtent, horizExtent * 2, vertExtent * 2);

        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(Camera.main.transform.position, new Vector3(cameraBounds.width, cameraBounds.height, 1.0f));
        Handles.Label(cameraBounds.position, "View");

        Rect cameraBoundsWithMargin = new Rect(-horizExtent - margin, -vertExtent - this.margin, (horizExtent * 2) + this.margin + this.margin, (vertExtent * 2) + this.margin + this.margin);

        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(Camera.main.transform.position, new Vector3(cameraBoundsWithMargin.width, cameraBoundsWithMargin.height, 1.0f));
        Handles.Label(cameraBoundsWithMargin.position, "Margin");
    }

#endif
}
