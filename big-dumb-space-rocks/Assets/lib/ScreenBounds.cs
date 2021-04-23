using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScreenBounds : Singleton<ScreenBounds>
{
    public Rect bounds;

    public Rect boundsWrap;
    public Rect boundsSpawn;

    public float wrapMargin;
    public float spawnMargin;

    private void Start()
    {
        float vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;
        float horizExtent = vertExtent * ((Screen.width * 1.0f) / Screen.height);

        this.bounds = new Rect(-horizExtent, -vertExtent, horizExtent * 2, vertExtent * 2);

        this.boundsSpawn = new Rect(-horizExtent - this.spawnMargin, -vertExtent - this.spawnMargin, (horizExtent * 2) + this.spawnMargin + this.spawnMargin, (vertExtent * 2) + this.spawnMargin + this.spawnMargin);

        this.boundsWrap = new Rect(-horizExtent - this.wrapMargin, -vertExtent - this.wrapMargin, (horizExtent * 2) + this.wrapMargin + this.wrapMargin, (vertExtent * 2) + this.wrapMargin + this.wrapMargin);
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        if (Camera.current.name == "Main Camera") return;

        float vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;
        float horizExtent = vertExtent * Camera.main.GetComponent<Camera>().aspect;

        Rect cameraBounds = new Rect(-horizExtent, -vertExtent, horizExtent * 2, vertExtent * 2);

        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(Camera.main.transform.position + new Vector3(0, 0, 10), new Vector3(cameraBounds.width, cameraBounds.height, 1.0f));
        Handles.Label(cameraBounds.position, "View");

        Rect cameraBoundsWithMargin = new Rect(-horizExtent - this.spawnMargin, -vertExtent - this.spawnMargin, (horizExtent * 2) + this.spawnMargin + this.spawnMargin, (vertExtent * 2) + this.spawnMargin + this.spawnMargin);

        Gizmos.color = Color.yellow;

        Gizmos.DrawWireCube(Camera.main.transform.position + new Vector3(0, 0, 10), new Vector3(cameraBoundsWithMargin.width, cameraBoundsWithMargin.height, 1.0f));
        Handles.Label(cameraBoundsWithMargin.position, "Spawn margin");

        cameraBoundsWithMargin = new Rect(-horizExtent - this.wrapMargin, -vertExtent - this.wrapMargin, (horizExtent * 2) + this.wrapMargin + this.wrapMargin, (vertExtent * 2) + this.wrapMargin + this.wrapMargin);

        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(Camera.main.transform.position + new Vector3(0, 0, 10), new Vector3(cameraBoundsWithMargin.width, cameraBoundsWithMargin.height, 1.0f));
        Handles.Label(cameraBoundsWithMargin.position, "Wrap margin");

    }

#endif

}
