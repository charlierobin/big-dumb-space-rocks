using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShotUI : MonoBehaviour
{
    public GameObject icon;

    private List<GameObject> current = new List<GameObject>();

    public void set(int value)
    {
        foreach (GameObject element in this.current)
        {
            Destroy(element);
        }

        float x = 0.0f;

        //if (value > 6)
        //{
        //    for (int i = 0; i < value; i++)
        //    {
        //        GameObject element = Instantiate(this.icon, this.transform);
        //        element.SetActive(true);
        //        element.transform.localPosition = new Vector2(x, 0);
        //        this.current.Add(element);
        //        x = x + element.GetComponent<RectTransform>().rect.width;
        //    }







        //}
        //else
        {
            for (int i = 0; i < value; i++)
            {
                GameObject element = Instantiate(this.icon, this.transform);
                element.SetActive(true);
                element.transform.localPosition = new Vector2(x, 0);
                this.current.Add(element);
                x = x + element.GetComponent<RectTransform>().rect.width;
            }
        }
    }
}
