using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSaucer : MonoBehaviour
{
    public GameObject explosionPrefab;

    protected int value;
    protected bool gameOver = false;

    public void Initialise(Vector2 direction)
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.AddForce(direction * Random.Range(0.5f, 2.0f), ForceMode.Impulse);
    }

    // TODO at the moment, bullet detects collision, sends hit ...
    // change: each detects, handles their own way ... no hit messages?

    public void Hit()
    {
        Instantiate(this.explosionPrefab, new Vector3(this.transform.position.x, this.transform.position.y, SpawnLevels.Instance.particlesZ), Quaternion.identity);

        Game.Instance.addToScore(this.value);
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

    public void GameIsOver()
    {
        Destroy(GetComponent<WrapAroundScreen>());
        this.gameObject.AddComponent<DestroyOffScreen>();
        this.gameOver = true;
    }
}
