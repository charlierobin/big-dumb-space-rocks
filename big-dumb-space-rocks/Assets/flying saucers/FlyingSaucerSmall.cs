using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSaucerSmall : FlyingSaucer
{
    public GameObject bulletPrefab;

    private bool active;

    private void Start()
    {
        this.value = 5000;

        this.active = true;
    }

    private void Update()
    {
        if (!Globals.Instance.GameRunning() || !this.active) return;

        // TODO sometimes single shots, sometimes a salvo
        // Can take player's power ups? ... gets a "super salvo" weapon if the player allows it to?

        if (Chance.OneIn(50))
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();

            GameObject newBullet = Instantiate(this.bulletPrefab, this.transform.position, Quaternion.identity);

            newBullet.GetComponent<BulletFromFlyingSaucer>().Fire(this.transform, 3.0f + rb.velocity.magnitude);
        }

        if (Chance.OneIn(500))
        {
            Vector3 test = Random.insideUnitCircle;

            Vector3 target = test + this.transform.position;


            Rigidbody rb = this.GetComponent<Rigidbody>();

            Vector3 direction = target - this.transform.position;


            rb.AddForce(direction * Random.Range(0.5f, 2.0f), ForceMode.Impulse);
        }
    }

    new protected void EndGame()
    {
        base.EndGame();

        this.active = false;
    }

}
