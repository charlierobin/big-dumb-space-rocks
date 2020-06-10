using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public GameObject engineGlow;
    public GameObject explosionPrefab;

    private float speed = 100.0f;
    private bool engineOn = false;

    private float health = 1.0f;

    private float lastHit;

    private Rigidbody rb;

    private void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Time.timeScale == 0.0f) return;

        if (Input.GetButtonDown("Debug Reset"))
        {
            this.destroy();
        }





        if (Input.GetButtonDown("Fire3"))
        {
            this.gameObject.BroadcastMessage("FireMultiShot", SendMessageOptions.DontRequireReceiver);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            this.gameObject.BroadcastMessage("FireBigBoom", SendMessageOptions.DontRequireReceiver);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            this.gameObject.BroadcastMessage("Fire", SendMessageOptions.DontRequireReceiver);
        }
        else if (Input.GetButton("Fire1"))
        {
            this.gameObject.BroadcastMessage("Fire", SendMessageOptions.DontRequireReceiver);
        }

        if (Input.GetButton("Shield"))
        {
            this.gameObject.BroadcastMessage("ShieldUp", SendMessageOptions.DontRequireReceiver);
        }
        else if (Input.GetButtonUp("Shield"))
        {
            this.gameObject.BroadcastMessage("ShieldDown", SendMessageOptions.DontRequireReceiver);
        }

        float rotation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        this.transform.Rotate(0, 0, -rotation);




        float thrust = Input.GetAxis("Vertical") * 10.0f * Time.deltaTime;

        if (thrust > 0.0f)
        {
            if (this.rb.velocity.magnitude < 5.0f) this.rb.AddForce(this.transform.up * thrust, ForceMode.Impulse);

            if (!this.engineOn)
            {
                this.engineOn = true;
                this.BroadcastMessage("EngineOn", SendMessageOptions.DontRequireReceiver);
            }
        }
        else
        {
            if (this.engineOn)
            {
                this.engineOn = false;
                this.BroadcastMessage("EngineOff", SendMessageOptions.DontRequireReceiver);
            }
        }


        if (this.health < 1.0f)
        {
            if (Time.time > this.lastHit + 5.0f)
            {
                this.health = this.health + 0.01f;
                this.health = Mathf.Min(this.health, 1.0f);
            }
            GameUI.SendMessage("UpdateHealthBar", this.health);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag != "hittable") return;

        if (this.GetComponentInChildren<Shield>().on)
        {
            return;
        }

        if (collision.gameObject.TryGetComponent<PowerUp>(out PowerUp powerup))
        {
            return;
        }

        this.lastHit = Time.time;

        collision.gameObject.SendMessage("PlayerHit", this.gameObject, SendMessageOptions.DontRequireReceiver);

        this.health = this.health - 0.1f;

        if (this.health <= 0.0f)
        {
            this.health = 0.0f;

            this.destroy();
        }

        GameUI.SendMessage("UpdateHealthBar", this.health);
    }

    private void destroy()
    {
        Instantiate(this.explosionPrefab, new Vector3(this.transform.position.x, this.transform.position.y, SpawnLevels.Instance.particlesZ), Quaternion.identity);

        Destroy(this.gameObject);

        Game.Instance.SendMessage("PlayerKilled");
    }
}

// TODO the player can hit something, a bullet can hit something
// player -> asteroid, flying saucer, flying saucer bullet
// player -> power up

// bullet -> asteroid, saucer, powerup
