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
        // TODO sometimes single shots, sometimes a salvo
        // Can take player's power ups? ... gets a "super salvo" weapon if the player allows it to?

        if ( Chance.OneIn(50) )
        {
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();

            GameObject newBullet = Instantiate(this.bulletPrefab, this.transform.position, Quaternion.identity);

            newBullet.GetComponent<BulletFlyingSaucer>().Fire(this.transform, 3.0f + rb.velocity.magnitude);
        }
    }
}
