using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float timer;
    public Prize prize;

    public GameObject countdown;

    private void Start()
    {
        this.timer = Time.time + Random.Range(15.0f, 25.0f);
    }

    public void Initialise(Prize prize)
    {
        this.prize = prize;
    }

    private void Update()
    {
        if (Time.time > this.timer)
        {
            Destroy(this.gameObject);
        }
        else if (this.timer - 5.0f < Time.time)
        {
            this.countdown.SetActive(true);
        }
    }

    private void Hit()
    {
        Destroy(GetComponent<CircleCollider2D>());
        Explosions.Instance.newAt(this.transform);
        Player.Instance.gameObject.BroadcastMessage("PowerUp", this, SendMessageOptions.DontRequireReceiver);
        Destroy(this.gameObject, 0.1f);
    }

    private void ShieldHit()
    {
        this.Hit();
    }

    private void BigBoomHit()
    {
        this.Hit();
    }
}

