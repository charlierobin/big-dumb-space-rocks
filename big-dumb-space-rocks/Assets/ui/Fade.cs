using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public float duration = 1.0f;
    public bool targetSelf;
    public GameObject[] targets;
    public bool sendMessage;
    public bool deactivateOnDone;

    protected bool fading;
    protected float alpha = 0.0f;

    protected float started;

    public void apply()
    {
        List<GameObject> items = new List<GameObject>();

        if (this.targetSelf)
        {
            items.Add(this.gameObject);
        }

        foreach (GameObject target in this.targets)
        {
            items.Add(target);
        }

        foreach (GameObject item in items)
        {
            item.GetComponent<UnityEngine.CanvasGroup>().alpha = this.alpha;
        }
    }
}
