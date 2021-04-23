using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int powerCount;

    public void Initialise(Transform shooter, float force, int powerCount)
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.AddForce(shooter.up * force, ForceMode.Impulse);

        this.transform.rotation = shooter.rotation;
        this.powerCount = powerCount;
    }

    private void OnTriggerEnter(Collider other)
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
