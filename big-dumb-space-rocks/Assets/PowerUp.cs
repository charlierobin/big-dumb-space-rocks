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
        this.gameObject.SetActive(true);
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

    private void Hit(GameObject sender)
    {
        Destroy(GetComponent<CircleCollider2D>());

        Explosions.Instance.newAt(this.transform);

        Player.Instance.powerUp(this);

        Destroy(this.gameObject,0.25f);
    }
}

