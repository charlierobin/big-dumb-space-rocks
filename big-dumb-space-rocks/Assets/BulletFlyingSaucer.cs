using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlyingSaucer : MonoBehaviour
{
    public GameObject explosionPrefab;

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
            Instantiate(this.explosionPrefab, new Vector3(this.transform.position.x, this.transform.position.y, SpawnLevels.Instance.particlesZ), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
