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
        float horizExtent = vertExtent * Screen.width / Screen.height;

        this.bounds = new Rect(-horizExtent, -vertExtent, horizExtent * 2, vertExtent * 2);

        float margin = 0.5f;

        this.boundsWithMargin = new Rect(-horizExtent - margin, -vertExtent - margin, (horizExtent * 2) + margin + margin, (vertExtent * 2) + margin + margin);
    }

    #if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        float vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;
        float horizExtent = vertExtent * Screen.width / Screen.height;

        Gizmos.color = Color.green;
        
        Rect bounds = new Rect(-horizExtent, -vertExtent, horizExtent * 2, vertExtent * 2);

        Gizmos.DrawWireCube(this.transform.position, new Vector3(bounds.width, bounds.height, 1.0f));
        Handles.Label(bounds.position, "View");

        float margin = 0.5f;

        Rect boundsWithMargin = new Rect(-horizExtent - margin, -vertExtent - margin, (horizExtent * 2) + margin + margin, (vertExtent * 2) + margin + margin);

        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(this.transform.position, new Vector3(boundsWithMargin.width, boundsWithMargin.height, 1.0f));
        Handles.Label(boundsWithMargin.position, "Margin");


    }

    #endif
}
