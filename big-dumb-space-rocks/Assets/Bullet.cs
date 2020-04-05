using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int powerCount;

    public void Fire(Transform shooter, float force, int powerCount)
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(shooter.up * force, ForceMode2D.Impulse);
        this.transform.rotation = shooter.rotation;
        this.powerCount = powerCount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "hittable") return;

        other.gameObject.SendMessage("Hit", this.gameObject, SendMessageOptions.DontRequireReceiver);

        if (this.powerCount == 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.powerCount--;
        }
    }
}
