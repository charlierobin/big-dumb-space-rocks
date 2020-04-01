using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoomExplosion : MonoBehaviour
{
    public GameObject shrapnelPrefab;

    private void Start()
    {
        Destroy(this.gameObject, 2.5f);

        for (int i = 0; i < 18; i++)
        {
            GameObject bit = Instantiate(this.shrapnelPrefab, this.transform.position, Quaternion.identity);
            bit.SetActive(true);
            Rigidbody2D rb = bit.GetComponent<Rigidbody2D>();
            Vector3 direction = this.transform.up;
            direction = Quaternion.Euler(0, 0, i * 20.0f) * direction;
            rb.AddForce(direction * 5.0f, ForceMode2D.Impulse);
        }
    }

    private void Update()
    {
        //this.GetComponent<CircleCollider2D>().radius = this.GetComponent<CircleCollider2D>().radius + 0.02f;






    }

    private void OnDestroy()
    {
        //Debug.Log(this.GetComponent<CircleCollider2D>().radius);
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    //Debug.Log(other.name);

    //    if (other.tag == "bullet") return;

    //    other.gameObject.SendMessage("Hit", this.gameObject, SendMessageOptions.DontRequireReceiver);
    //}
}

