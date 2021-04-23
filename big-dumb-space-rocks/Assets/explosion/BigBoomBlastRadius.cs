using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoomBlastRadius : MonoBehaviour
{
    //public Gradient colour;

    //private float startScale = 0.0f;

    //private float rate = 1.3f;

    private float lifetime;
    private float endTime;

    public float targetRadius = 1.0f;

    private void Start()
    {
        //this.transform.localPosition = new Vector3(0, 0, -ZLayers.Instance.particles);

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, ZLayers.Instance.objects);

        //this.lifetime = this.gameObject.GetComponentInParent<Destroyer>().lifetime;

        this.lifetime = 2.0f;

        this.endTime = Time.time + this.lifetime;



        //this.transform.localScale = new Vector3(this.startScale, this.startScale, this.startScale);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet") return;

        other.gameObject.SendMessage("BigBoomBlastHit", this.gameObject, SendMessageOptions.DontRequireReceiver);
    }

    private void Update()
    {
        if (this.GetComponent<SphereCollider>().radius > this.targetRadius)
        {
            //this.GetComponent<SphereCollider>().enabled = false;
            //this.enabled = false;

            this.gameObject.SetActive(false);

            return;
        }

        //float newScale = this.transform.localScale.x + (rate * Time.deltaTime);

        //this.transform.localScale = new Vector3(newScale, newScale, newScale);

        //this.GetComponent<SpriteRenderer>().color = this.colour.Evaluate(1.0f - ((this.endTime - Time.time) / this.lifetime));


        this.GetComponent<SphereCollider>().radius = GetComponent<SphereCollider>().radius + 0.05f;
    }



    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, this.GetComponent<SphereCollider>().radius * this.transform.localScale.x);

#if UNITY_EDITOR

        Gizmos.color = new Color(1, 0, 0, 0.2f);
        Gizmos.DrawWireSphere(this.transform.position, this.targetRadius);

#endif
    }


}
