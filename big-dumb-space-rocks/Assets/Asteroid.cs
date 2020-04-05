using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public void Initialise()
    {
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
        //Destroy(GetComponent<CircleCollider2D>());

        if (this.transform.localScale.x > 0.2f)
        {
            //int numberOfBits = (int)(Random.Range(2.0f, 10.0f) * this.transform.localScale.x);

            int numberOfBits = Chance.RandomIntegerInRange(2, 4);

            for (int i = 0; i < numberOfBits; i++)
            {
                GameObject newAsteroid = Instantiate(Asteroids.Instance.asteroidPrefab, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
                newAsteroid.transform.localScale = this.transform.localScale * 0.5f;
                newAsteroid.GetComponent<Asteroid>().Initialise();
            }

            Explosions.Instance.sparksAt(sender.transform, sender.gameObject);
        }
        else
        {
            Explosions.Instance.littleExplosionAt(this.transform);
        }
        Destroy(this.gameObject);
    }

    private void ShieldHit()
    {
        //Destroy(GetComponent<CircleCollider2D>());

        Destroy(this.gameObject);

        Explosions.Instance.newAt(this.transform);

        //Destroy(this.gameObject);
    }

    private void BigBoomHit()
    {
        Explosions.Instance.newAt(this.transform);
        Destroy(this.gameObject);
    }

}
