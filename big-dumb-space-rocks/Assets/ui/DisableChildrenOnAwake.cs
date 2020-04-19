using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableChildrenOnAwake : MonoBehaviour
{
    private void Awake()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
    }
}
