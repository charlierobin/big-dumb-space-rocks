using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSaucerLittle : FlyingSaucer
{
    public GameObject bulletPrefab;

    private void Start()
    {
        this.value = 5000;
    }

    private void Update()
    {
        if (this.gameOver) return;

        // TODO sometimes single shots, sometimes a salvo
        // Can take player's power ups? ... gets a "super salvo" weapon if the player allows it to?

        if (!Player.Instance) return;

        if (Chance.OneIn(50))
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();

            GameObject newBullet = Instantiate(this.bulletPrefab, this.transform.position, Quaternion.identity);

            newBullet.GetComponent<BulletFlyingSaucer>().Fire(this.transform, 3.0f + rb.velocity.magnitude);
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
}
