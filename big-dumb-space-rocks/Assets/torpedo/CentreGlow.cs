using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentreGlow : MonoBehaviour
{
    private void Update()
    {
        float newScale = Random.Range(1.0f, 1.2f);

        this.transform.localScale = new Vector3(newScale, newScale, 1.0f);
    }
}
