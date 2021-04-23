using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DisplayInSceneEditor : MonoBehaviour
{
#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        if (Camera.current.name == "Main Camera") return;

        Handles.Label(transform.position + new Vector3(0.1f, -0.1f), this.name);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }

#endif

}
