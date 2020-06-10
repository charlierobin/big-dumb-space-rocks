using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBigBoom : MonoBehaviour
{
    public GameObject explosionPrefab;

    public void Fire(Transform shooter, float force)
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.AddForce(shooter.up * force, ForceMode.Impulse);
        this.transform.rotation = shooter.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "hittable") return;

        other.gameObject.SendMessage("BigBoomHit", this.gameObject, SendMessageOptions.DontRequireReceiver);

        this.explosion();

        Destroy(this.gameObject);
    }

    public void ExplodedByUser()
    {
        this.explosion();

        Destroy(this.gameObject);
    }

    private void explosion()
    {
        Instantiate(this.explosionPrefab, new Vector3(this.transform.position.x, this.transform.position.y, SpawnLevels.Instance.particlesZ), Quaternion.identity);
    }
}
