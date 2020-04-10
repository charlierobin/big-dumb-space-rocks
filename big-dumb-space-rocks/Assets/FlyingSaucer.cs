using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSaucer : MonoBehaviour
{
    public void Initialise(Vector2 direction)
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * Random.Range(0.5f, 2.0f), ForceMode2D.Impulse);
    }

    public void Hit()
    {
        Destroy(GetComponent<CircleCollider2D>());
        Explosions.Instance.newAt(this.transform);
        Game.Instance.addToScore(1000);
        Destroy(this.gameObject, 0.1f);
    }

    private void ShieldHit()
    {
        this.Hit();
    }

    private void BigBoomHit()
    {
        this.Hit();
    }

    private void PlayerHit()
    {
        this.Hit();
    }
}
