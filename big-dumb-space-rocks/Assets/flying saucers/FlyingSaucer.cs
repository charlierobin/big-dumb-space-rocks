using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSaucer : MonoBehaviour
{
    public GameObject explosionPrefab;

    protected int value;

    public void Initialise(Vector2 direction)
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();

        rb.AddForce(direction * Random.Range(0.5f, 2.0f), ForceMode.Impulse);
    }

   

    public void Hit()
    {
        //Destroy(GetComponent<CircleCollider2D>());

        //Explosions.Instance.newAt(this.transform);
        //Game.Instance.addToScore(this.value);

        Instantiate(this.explosionPrefab, new Vector3(this.transform.position.x, this.transform.position.y, ZLayers.Instance.particles), Quaternion.identity);

        Globals.Instance.addToScore(this.value);

        Destroy(this.gameObject);
    }

    protected void EndGame()
    {
        this.GetComponent<WrapAroundScreen>().enabled = false;
        this.GetComponent<DestroyOffScreen>().enabled = true;
    }


}
