using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoomBullet : MonoBehaviour
{
    public GameObject explosionPrefab;

    public void Fire(Transform shooter, float force)
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(shooter.up * force, ForceMode2D.Impulse);
        this.transform.rotation = shooter.rotation;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "hittable") return;

        //Explosions.Instance.bigBoomAt(this.transform);

        other.gameObject.SendMessage("BigBoomHit", this.gameObject, SendMessageOptions.DontRequireReceiver);

        this.explosion();

        Destroy(this.gameObject);
    }

    public void ExplodedByUser()
    {
        //Explosions.Instance.bigBoomAt(this.transform);

        this.explosion();

        Destroy(this.gameObject);
    }

    private void explosion()
    {
        Instantiate(this.explosionPrefab, new Vector3(this.transform.position.x, this.transform.position.y, -4.0f), Quaternion.identity);
    }
}
