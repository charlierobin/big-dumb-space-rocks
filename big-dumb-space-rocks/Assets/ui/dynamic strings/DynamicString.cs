using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicString : MonoBehaviour
{
    public GameObject[] digits;

    public GameObject X;

    private List<GameObject> current = new List<GameObject>();

    public void set(int value)
    {
        foreach (GameObject digit in this.current)
        {
            Destroy(digit);
        }

        this.current = new List<GameObject>();

        string asString = value.ToString();

        char[] chars = asString.ToCharArray();

        float x = 0.0f;

        for (int i = 0; i < chars.Length; i++)
        {
            int v = int.Parse(System.Convert.ToString(chars[i]));

            GameObject digit = Instantiate(this.digits[v], this.transform);

            digit.transform.localPosition = new Vector2(x, 0);

            this.current.Add(digit);

            x = x + digit.GetComponent<RectTransform>().rect.width;
        }
    }
}
