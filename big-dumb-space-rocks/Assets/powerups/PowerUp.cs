using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUps.Prize prize;

    public GameObject countdown;

    public GameObject explosionPrefab;



    private float timer;



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
            Destroy(this.gameObject);
        }
        else if (this.timer - 5.0f < Time.time)
        {
            //this.countdown.SetActive(true);
        }
    }


    private void Hit()
    {
        //Destroy(GetComponent<CircleCollider2D>());

        //this.gameObject.GetComponent<SphereCollider>().enabled = false;

        //Explosions.Instance.newAt(this.transform);


        Player.Instance.gameObject.BroadcastMessage("PowerUp", this, SendMessageOptions.DontRequireReceiver);

        //Globals.Instance.powerUp(this);

        

        //Destroy(this.gameObject, 0.1f);

        Destroy(this.gameObject);
    }




#if UNITY_EDITOR

    void OnDrawGizmos()
    {
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(this.transform.position, this.GetComponent<SphereCollider>().radius * this.transform.localScale.x);

        Gizmos.color = Color.white;

        //Gizmos.DrawWireSphere(this.transform.position, this.GetComponent<SphereCollider>().radius);

        //Gizmos.color = new Color(1, 0, 0, 0.2f);
        //Gizmos.DrawWireSphere(this.transform.position, this.targetRadius);
    }

#endif

    private void OnGUI()
    {

        Vector2 nativeSize = new Vector2(1800, 800);

        float ratio = Screen.width / nativeSize.x;

        //Vector3 scale = new Vector3(Screen.width / nativeSize.x, Screen.height / nativeSize.y, 1.0f);



        GUIStyle style = new GUIStyle();

        style.fontSize = (int)(12 * ratio);

        style.normal.textColor = Color.white;

        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);


        GUI.Label(new Rect(screenPos.x + (20 * ratio), Screen.height - screenPos.y, 1000, 300), this.prize.ToString(), style);

        float remaining = this.timer - Time.time;

        GUI.Label(new Rect(screenPos.x + (20 * ratio), Screen.height - screenPos.y + (20 * ratio), 1000, 300), remaining.ToString(), style);


    }


    private void EndGame()
    {
        Destroy(this.gameObject);
    }

}


