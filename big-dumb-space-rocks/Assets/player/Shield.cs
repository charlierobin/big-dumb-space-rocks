using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Gradient healthColours;

    private static Texture2D _staticRectTexture;
    private static GUIStyle _staticRectStyle;

    private float maxPower = 1.0f;

    private float power = 1.0f;

    //private float targetRadius = 1.0f;

    private bool on;

    private void Start()
    {
        this.power = this.maxPower;

        if (_staticRectTexture == null)
        {
            _staticRectTexture = new Texture2D(1, 1);
        }

        if (_staticRectStyle == null)
        {
            _staticRectStyle = new GUIStyle();
        }
    }

    private void ShieldUp()
    {
        if (this.power <= 0) return;

        this.on = true;
        //this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        this.GetComponent<SphereCollider>().enabled = true;
    }

    private void ShieldDown()
    {
        this.on = false;
        //this.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);

        this.GetComponent<SphereCollider>().enabled = false;
    }

    private void Update()
    {
        if (this.on)
        {
            this.power = this.power - 0.001f;

            if (this.power < 0)
            {
                this.power = 0.0f;
                this.ShieldDown();
            }
        }

        //GameUI.SendMessage("UpdateShieldBar", this.power);
    }

    private void PowerUp(PowerUp powerUp)
    {
        if (powerUp.prize == PowerUps.Prize.Shield)
        {
            this.power = this.maxPower;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log(collision.gameObject.name);

        //if (this.on)
        //{
        collision.gameObject.SendMessage("ShieldHit", SendMessageOptions.DontRequireReceiver);

        this.power = this.power - 0.1f;
        //}
    }

    public static void GUIDrawRect(Color color, float width)
    {
        _staticRectTexture.SetPixel(0, 0, color);

        _staticRectTexture.Apply();

        _staticRectStyle.normal.background = _staticRectTexture;

        GUILayout.BeginHorizontal();

        GUILayout.Space((150 - width) / 2.0f);

        GUILayout.Box(_staticRectTexture, _staticRectStyle, GUILayout.Width(width), GUILayout.Height(10));

        GUILayout.EndHorizontal();
    }

    private void GUI()
    {
        GUILayout.BeginVertical(GUILayout.Width(150));

        {
            if (GUILayout.Button("Shield recharge"))
            {
                this.power = this.maxPower;
            }

            //GUILayout.Label("Power: " + this.power.ToString());

            //GUILayout.Space(5);

            GUIDrawRect(this.healthColours.Evaluate(this.power / 1.0f), (this.power / 1.0f) * (150 - 20));
        }
        GUILayout.EndVertical();
    }

    void OnDrawGizmos()
    {
        if (this.on)
        {

            //Gizmos.color = Color.yellow;
            //Gizmos.DrawWireSphere(this.transform.position, this.GetComponent<SphereCollider>().radius * this.transform.localScale.x);

            Gizmos.color = new Color(1, 0, 0, 0.2f);

            Gizmos.DrawWireSphere(this.transform.position, this.GetComponent<SphereCollider>().radius);

            //Gizmos.color = new Color(1, 0, 0, 0.2f);
            //Gizmos.DrawWireSphere(this.transform.position, this.targetRadius);

        }
    }
}
