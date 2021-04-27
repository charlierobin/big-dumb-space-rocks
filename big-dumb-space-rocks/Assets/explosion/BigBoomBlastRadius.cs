using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoomBlastRadius : MonoBehaviour
{
    public Gradient colour;

    public SpriteRenderer sprite;

    private float startScale;

    private float endScale = 50.0f;
    public float rate = 1.0f;

    private void Start()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, ZLayers.Instance.objects);
        this.startScale = this.transform.localScale.x;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet") return;

        other.gameObject.SendMessage("BigBoomBlastHit", this.gameObject, SendMessageOptions.DontRequireReceiver);
    }

    private void Update()
    {
        if (this.transform.localScale.x >= this.endScale)
        {
            this.gameObject.SetActive(false);

            return;
        }

        float newScale = this.transform.localScale.x + (this.rate * Time.deltaTime);

        this.transform.localScale = new Vector3(newScale, newScale, newScale);

        float t = newScale / (this.endScale - this.startScale);

        this.sprite.color = this.colour.Evaluate(t);
    }
}
