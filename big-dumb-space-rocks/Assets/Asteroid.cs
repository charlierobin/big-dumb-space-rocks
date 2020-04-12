using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private int factor = 1; // 1,2,3,4 -> largest asteroid, scale / 1, to smallest asteroid, scale / 4

    private GameObject bullet;

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
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * Random.Range(0.5f, 2.0f), ForceMode2D.Impulse);
    }

    private void Hit(GameObject sender)
    {
        if (sender == this.bullet)
        {
            //Debug.Log("same bullet");
            return;
        }

        Destroy(GetComponent<CircleCollider2D>());

        if (this.factor < 4)
        {
            int numberOfBits = Chance.RandomIntegerInRange(2, 4);

            for (int i = 0; i < numberOfBits; i++)
            {
                GameObject newAsteroid = Instantiate(Asteroids.Instance.asteroidPrefab, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
                newAsteroid.GetComponent<Asteroid>().Initialise(this.factor + 1, sender);
            }
            Explosions.Instance.sparksAt(sender.gameObject);
        }
        else
        {
            Explosions.Instance.littleExplosionAt(this.transform);
        }
        Game.Instance.addToScore(100 * this.factor);
        Destroy(this.gameObject);
    }

    private void ShieldHit()
    {
        Destroy(GetComponent<CircleCollider2D>());
        Explosions.Instance.newAt(this.transform);
        Game.Instance.addToScore(100 * this.factor);
        Destroy(this.gameObject);
    }

    private void BigBoomHit()
    {
        this.ShieldHit();
    }

    private void PlayerHit()
    {
        this.ShieldHit();
    }
}
