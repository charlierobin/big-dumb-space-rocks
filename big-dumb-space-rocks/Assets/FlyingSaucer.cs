using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSaucer : MonoBehaviour
{
    public void Initialise(Vector2 direction)
    {
        this.gameObject.SetActive(true);
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * Random.Range(0.5f, 2.0f), ForceMode2D.Impulse);
    }

    public void Hit(GameObject sender)
    {
        Destroy(GetComponent<CircleCollider2D>());

        Explosions.Instance.newAt(this.transform);

        Destroy(this.gameObject, 0.25f);
    }
}
