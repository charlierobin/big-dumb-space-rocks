using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoomBullet : MonoBehaviour
{
    public void Fire(Transform shooter, float force)
    {
        this.gameObject.SetActive(true);
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(shooter.up * force, ForceMode2D.Impulse);
        this.transform.rotation = shooter.rotation;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "hittable") return;

        Explosions.Instance.bigBoomAt(this.transform);

        other.gameObject.SendMessage("Hit", this.gameObject, SendMessageOptions.DontRequireReceiver);

        Destroy(this.gameObject);
    }

    public void ExplodedByUser()
    {
        Explosions.Instance.bigBoomAt(this.transform);

        Destroy(this.gameObject);
    }
}
