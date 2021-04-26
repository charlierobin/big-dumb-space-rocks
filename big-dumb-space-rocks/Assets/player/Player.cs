using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public GameObject explosion;

    private Rigidbody rb;

    private bool guiDone;

    private float health;
    private float healthTimer;

    private float speed = 100.0f;
    private bool engineOn = false;

    private void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();

        this.health = 1.0f;
    }

    public void reduceHealth(float amount)
    {
        this.health = this.health - amount;

        this.health = Mathf.Max(this.health, 0);

        this.healthTimer = Time.time + 10.0f;

        if (this.health <= 0)
        {
            this.destroy();
        }
    }

    private void Update()
    {
        if (Time.timeScale == 0.0f) return;

        if (this.health < 1.0f && Time.time >= this.healthTimer) this.health = 1.0f;

        if (Input.GetButtonDown("Debug Reset"))
        {
            this.destroy();
            return;
        }

        float rotation = Input.GetAxis("Horizontal") * this.speed * Time.deltaTime;

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

        if (Input.GetButtonDown("Fire1"))
        {
            this.gameObject.BroadcastMessage("Fire", SendMessageOptions.DontRequireReceiver);
        }
        else if (Input.GetButton("Fire1"))
        {
            this.gameObject.BroadcastMessage("Fire", SendMessageOptions.DontRequireReceiver);
        }


        if (Input.GetButtonDown("Fire2"))
        {
            this.gameObject.BroadcastMessage("FireBigBoom", SendMessageOptions.DontRequireReceiver);
        }

        if (Input.GetButtonDown("Fire3"))
        {
            this.gameObject.BroadcastMessage("FireMultiShot", SendMessageOptions.DontRequireReceiver);
        }

        if (Input.GetButton("Shield"))
        {
            this.gameObject.BroadcastMessage("ShieldUp", SendMessageOptions.DontRequireReceiver);
        }
        else if (Input.GetButtonUp("Shield"))
        {
            this.gameObject.BroadcastMessage("ShieldDown", SendMessageOptions.DontRequireReceiver);
        }

    }

    public void GUI()
    {
        if (this.guiDone) return;

        this.guiDone = true;

        GUILayout.BeginVertical(GUILayout.Width(150));

        if (GUILayout.Button("Suicide"))
        {
            this.destroy();
        }

        GUILayout.Label("Health: " + this.health.ToString());

        if (this.health < 1.0f)
        {
            GUILayout.Space(5);

            GUILayout.Label((this.healthTimer - Time.time).ToString());
        }

        GUILayout.EndVertical();

        this.BroadcastMessage("GUI", SendMessageOptions.DontRequireReceiver);

        this.guiDone = false;
    }

    public void destroy()
    {
        Instantiate(this.explosion, new Vector3(this.transform.position.x, this.transform.position.y, ZLayers.Instance.particles), Quaternion.identity);

        Destroy(this.gameObject);

        Globals.Instance.playerWasDestroyed();
    }
}
