using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosion : MonoBehaviour
{
    public float lifetime = 3.0f;

    private void Start()
    {
        Destroy(this.gameObject, this.lifetime);
    }
}
