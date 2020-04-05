using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoomExplosion : MonoBehaviour
{
    public GameObject blast;

    private void Start()
    {
        Destroy(this.gameObject, 2.5f);
    }

    private void Update()
    {
        this.GetComponent<CircleCollider2D>().radius = this.GetComponent<CircleCollider2D>().radius + 0.02f;
        Vector3 newScale = new Vector3(this.GetComponent<CircleCollider2D>().radius / 2.0f, this.GetComponent<CircleCollider2D>().radius / 2.0f, 1.0f);
        this.blast.transform.localScale = newScale;
        Color colour = this.blast.GetComponent<SpriteRenderer>().color;
        colour = new Color(colour.r, colour.g, colour.b, colour.a - 0.003f);
        this.blast.GetComponent<SpriteRenderer>().color = colour;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet") return;

        other.gameObject.SendMessage("BigBoomHit", this.gameObject, SendMessageOptions.DontRequireReceiver);
    }
}

