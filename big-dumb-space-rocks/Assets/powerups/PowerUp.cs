using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUps.Prize prize;

    //public GameObject countdown;

    private static GUIStyle _staticStyle;

    public GameObject explosionPrefab;

    public float fontSize = 12;

    private float timer;

    private void Start()
    {
        this.timer = Time.time + Random.Range(15.0f, 25.0f);

        if (_staticStyle == null)
        {
            _staticStyle = new GUIStyle();
            _staticStyle.fontSize = (int)(this.fontSize * Globals.Instance.ratio);
            _staticStyle.normal.textColor = Color.white;
        }
    }

    public void Initialise(PowerUps.Prize prize)
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
            //this.countdown.SetActive(true);
        }
    }

    private void Hit()
    {
        Instantiate(this.explosionPrefab, new Vector3(this.transform.position.x, this.transform.position.y, ZLayers.Instance.particles), Quaternion.identity);

        Player.Instance.gameObject.BroadcastMessage("PowerUp", this, SendMessageOptions.DontRequireReceiver);

        Destroy(this.gameObject);
    }

    private void OnGUI()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);

        GUI.Label(new Rect(screenPos.x + (20 * Globals.Instance.ratio), Screen.height - screenPos.y, 1000, 300), this.prize.ToString(), _staticStyle);

        int remaining = (int)(this.timer - Time.time);

        GUI.Label(new Rect(screenPos.x + (20 * Globals.Instance.ratio), Screen.height - screenPos.y + ((this.fontSize + 0) * Globals.Instance.ratio), 1000, 300), remaining.ToString(), _staticStyle);
    }

    private void EndGame()
    {
        Destroy(this.gameObject);
    }
}


