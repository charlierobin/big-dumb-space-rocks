using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoomExplosionShrapnel : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet") return;

        other.gameObject.SendMessage("Hit", this.gameObject, SendMessageOptions.DontRequireReceiver);

    }
}
