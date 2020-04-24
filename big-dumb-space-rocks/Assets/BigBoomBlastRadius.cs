using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoomBlastRadius : MonoBehaviour
{
    public Gradient colour;

    private float startScale = 0.0f;

    private float rate = 1.3f;

    private float lifetime;
    private float endTime;

    private void Start()
    {
        this.lifetime = this.gameObject.GetComponentInParent<BigBoomExplosion>().lifetime;
        this.endTime = Time.time + this.lifetime;
        this.transform.localScale = new Vector3(this.startScale, this.startScale, this.startScale);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet") return;

        other.gameObject.SendMessage("BigBoomHit", this.gameObject, SendMessageOptions.DontRequireReceiver);
    }

    private void Update()
    {
        float newScale = this.transform.localScale.x + (rate * Time.deltaTime);

        this.transform.localScale = new Vector3(newScale, newScale, newScale);

        this.GetComponent<SpriteRenderer>().color = this.colour.Evaluate(1.0f - ((this.endTime - Time.time) / this.lifetime));
    }

#if UNITY_EDITOR

    private float targetRadius = 6.0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, this.GetComponent<CircleCollider2D>().radius * this.transform.localScale.x);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.targetRadius);
    }

#endif
}
