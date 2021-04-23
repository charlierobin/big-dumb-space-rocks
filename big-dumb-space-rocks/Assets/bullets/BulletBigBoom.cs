using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBigBoom : MonoBehaviour
{
    public GameObject explosionPrefab;

    public Transform sprite;

    //private Light globalLighting;

    private void Start()
    {
        //GameObject test = GameObject.Find("Directional Light");

        //this.globalLighting = test.GetComponent<Light>();

        //this.globalLighting.enabled = false;
    }

    public void Fire(Transform shooter, float force)
    {
        //this.sprite.localPosition = new Vector3(0, 0, ZLayers.Instance.particles);

        this.sprite.position = new Vector3(this.sprite.position.x, this.sprite.position.y, ZLayers.Instance.particles);

        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.AddForce(shooter.up * force, ForceMode.Impulse);
        this.transform.rotation = shooter.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "hittable") return;

        other.gameObject.SendMessage("BigBoomHit", this.gameObject, SendMessageOptions.DontRequireReceiver);

        this.ExplodedByUser();
    }

    public void ExplodedByUser()
    {
        //this.globalLighting.enabled = true;

        Instantiate(this.explosionPrefab, new Vector3(this.transform.position.x, this.transform.position.y, ZLayers.Instance.particles), Quaternion.identity);

        Destroy(this.gameObject);
    }

    //private void OnDestroy()
    //{
        //this.globalLighting.enabled = true;
    //}
}
