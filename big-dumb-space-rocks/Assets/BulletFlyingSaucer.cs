using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlyingSaucer : MonoBehaviour
{
    public void Fire(Transform shooter, float force)
    {
        Vector2 pos = Player.Instance.transform.position;

        Vector3 target = Random.insideUnitCircle + pos;



        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();

        Vector3 heading = target - this.transform.position;

        float distance = heading.magnitude;
        Vector3 direction = heading / distance;

        rb.AddForce(direction * force, ForceMode2D.Impulse);

        this.transform.up = rb.velocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // TODO flying saucer bullets could be like player's, with a power, and they also shoot up asteroids?
        // added at a later level to add difficulty?

        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
