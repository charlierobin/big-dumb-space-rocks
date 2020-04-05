using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScreenBounds : Singleton<ScreenBounds>
{
    public Rect bounds;
    public Rect boundsWithMargin;

    private void Start()
    {
        float vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;
        float horizExtent = vertExtent * ((Screen.width * 1.0f) / Screen.height);

        this.bounds = new Rect(-horizExtent, -vertExtent, horizExtent * 2, vertExtent * 2);

        float margin = 0.5f;

        this.boundsWithMargin = new Rect(-horizExtent - margin, -vertExtent - margin, (horizExtent * 2) + margin + margin, (vertExtent * 2) + margin + margin);
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

        float margin = 0.5f;

        Rect cameraBoundsWithMargin = new Rect(-horizExtent - margin, -vertExtent - margin, (horizExtent * 2) + margin + margin, (vertExtent * 2) + margin + margin);

        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(Camera.main.transform.position, new Vector3(cameraBoundsWithMargin.width, cameraBoundsWithMargin.height, 1.0f));
        Handles.Label(cameraBoundsWithMargin.position, "Margin");
    }

#endif
}
