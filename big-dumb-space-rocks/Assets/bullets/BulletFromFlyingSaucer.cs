using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFromFlyingSaucer : MonoBehaviour
{
    public GameObject sparksPrefab;

    private float power = 0.1f;

    public void Fire(Transform shooter, float force)
    {
        Vector2 pos = Player.Instance.transform.position;

        Vector3 target = Random.insideUnitCircle + pos;


        Rigidbody rb = this.GetComponent<Rigidbody>();

        Vector3 heading = target - this.transform.position;

        float distance = heading.magnitude;
        Vector3 direction = heading / distance;

        rb.AddForce(direction * force, ForceMode.Impulse);

        this.transform.up = heading;
        //Debug.Log(rb.velocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        // TODO flying saucer bullets could be like player's, with a power, and they also shoot up asteroids?
        // added at a later level to add difficulty?

        //Debug.Log("Bullet: " + other.gameObject.name);

        if (other.tag == "Player")
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();

            Instantiate(this.sparksPrefab, new Vector3(this.transform.position.x, this.transform.position.y, ZLayers.Instance.particles), rb.rotation);

            Player.Instance.reduceHealth(power);

            Destroy(this.gameObject);
        }
        else if (other.tag == "shield")
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();

            Instantiate(this.sparksPrefab, new Vector3(this.transform.position.x, this.transform.position.y, ZLayers.Instance.particles), rb.rotation);

            Destroy(this.gameObject);
        }
    }
}
