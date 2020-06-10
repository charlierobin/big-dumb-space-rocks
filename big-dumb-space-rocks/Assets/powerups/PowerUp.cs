using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float timer;
    public PowerUps.Prize prize;

    public GameObject countdown;

    public GameObject explosionPrefab;

    private void Start()
    {
        this.timer = Time.time + Random.Range(15.0f, 25.0f);
    }

    public void Initialise(PowerUps.Prize prize)
    {
        this.prize = prize;
    }

    private void Update()
    {
        if (Time.time > this.timer)
        {
            Instantiate(this.explosionPrefab, new Vector3(this.transform.position.x, this.transform.position.y, SpawnLevels.Instance.particlesZ), Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (this.timer - 5.0f < Time.time)
        {
            this.countdown.SetActive(true);
        }
    }

    private void Hit()
    {
        Player.Instance.gameObject.BroadcastMessage("PowerUp", this, SendMessageOptions.DontRequireReceiver);
        Instantiate(this.explosionPrefab, new Vector3(this.transform.position.x, this.transform.position.y, SpawnLevels.Instance.particlesZ), Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void ShieldHit()
    {
        //this.Hit();
    }

    private void BigBoomHit()
    {
        //this.Hit();
        // TODO ?????
    }

    //private void OnGUI()
    //{
    //    Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);

    //    GUI.Label(new Rect(screenPos.x, Screen.height - screenPos.y, 1000, 300), this.prize.ToString());
    //}

    private void GameIsOver()
    {
        Instantiate(this.explosionPrefab, new Vector3(this.transform.position.x, this.transform.position.y, SpawnLevels.Instance.particlesZ), Quaternion.identity);
        Destroy(this.gameObject);
    }
}

