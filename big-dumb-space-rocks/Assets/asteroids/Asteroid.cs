using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private int factor = 1;     // 1,2,3,4 -> largest asteroid, scale / 1, to smallest asteroid, scale / 4

    private GameObject bullet;
    public GameObject sparksPrefab;
    public GameObject explosionPrefab;

    private void Start()
    {
        if (!Globals.Instance.GameRunning())
        {
            this.EndGame();
        }

        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.AddRelativeTorque(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), ForceMode.Impulse);
    }

    public void Initialise(int factor, GameObject bullet)
    {
        this.bullet = bullet;

        this.factor = factor;
        this.transform.localScale = new Vector3(1.0f / this.factor, 1.0f / this.factor, 1.0f / this.factor);
        Vector2 direction = Random.insideUnitCircle;
        direction.Normalize();
        this.Initialise(direction);
    }

    public void Initialise(Vector2 direction)
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.AddForce(direction * Random.Range(0.5f, 2.0f), ForceMode.Impulse);
    }

    private void EndGame()
    {
        this.GetComponent<WrapAroundScreen>().enabled = false;
        this.GetComponent<DestroyOffScreen>().enabled = true;
    }

    private void Hit(GameObject sender)
    {
        if (sender == this.bullet) return;

        if (this.factor < 4)
        {
            int numberOfBits = Chance.RandomIntegerInRange(2, 4);

            for (int i = 0; i < numberOfBits; i++)
            {
                Asteroids.Instance.create(this.transform.position, this.factor + 1, sender);
            }
            Instantiate(this.sparksPrefab, new Vector3(sender.transform.position.x, sender.transform.position.y, ZLayers.Instance.particles), sender.transform.rotation);
        }
        else
        {
            Instantiate(this.explosionPrefab, new Vector3(sender.transform.position.x, sender.transform.position.y, ZLayers.Instance.particles), Quaternion.identity);
        }

        Globals.Instance.addToScore(100 * this.factor);

        Destroy(this.gameObject);
    }

    private void BigBoomHit()
    {
        Globals.Instance.addToScore(100 * this.factor);

        Destroy(this.gameObject);
    }

    private void BigBoomBlastHit()
    {
        Globals.Instance.addToScore(100 * this.factor);

        Instantiate(this.explosionPrefab, new Vector3(this.transform.position.x, this.transform.position.y, ZLayers.Instance.particles), Quaternion.identity);

        Destroy(this.gameObject);
    }

    private void ShieldHit()
    {
        Globals.Instance.addToScore(100 * this.factor);

        Instantiate(this.explosionPrefab, new Vector3(this.transform.position.x, this.transform.position.y, ZLayers.Instance.particles), Quaternion.identity);

        Destroy(this.gameObject);
    }
}
