using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    private float speed = 100.0f;

    private Rigidbody2D rb;

    private void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
    }

    private void OnGUI()
    {
        string console = GetComponentInChildren<StandardWeapon>().consoleMessage();
        console = console + GetComponentInChildren<BigBoomWeapon>().consoleMessage();
        console = console + GetComponentInChildren<MultiShotWeapon>().consoleMessage();
        console = console + GetComponentInChildren<Shields>().consoleMessage();

        GUI.Label(new Rect(20, 20, 500, 500), console);
    }

    private void Update()
    {
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
            this.gameObject.BroadcastMessage("Shield", SendMessageOptions.DontRequireReceiver);
        }

        float rotation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        this.transform.Rotate(0, 0, -rotation);

        float thrust = Input.GetAxis("Vertical") * 10.0f * Time.deltaTime;

        this.rb.AddForce(this.transform.up * thrust, ForceMode2D.Impulse);

        // TODO implement a max speed?
    }

    public void powerUp(PowerUp powerUp)
    {
        this.gameObject.BroadcastMessage("PowerUp", powerUp, SendMessageOptions.DontRequireReceiver);
    }

    private void FixedUpdate()
    {
        if (this.transform.position.y >= ScreenBounds.Instance.bounds.yMax)
        {
            this.transform.position = new Vector2(this.transform.position.x, ScreenBounds.Instance.bounds.yMin);
        }
        else if (this.transform.position.y <= ScreenBounds.Instance.bounds.yMin)
        {
            this.transform.position = new Vector2(this.transform.position.x, ScreenBounds.Instance.bounds.yMax);
        }

        if (this.transform.position.x >= ScreenBounds.Instance.bounds.xMax)
        {
            this.transform.position = new Vector2(ScreenBounds.Instance.bounds.xMin, this.transform.position.y);
        }
        else if (this.transform.position.x <= ScreenBounds.Instance.bounds.xMin)
        {
            this.transform.position = new Vector2(ScreenBounds.Instance.bounds.xMax, this.transform.position.y);
        }
    }
}
