using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    public GameObject healthBar;
    public Gradient colour;

    private void UpdateHealthBarDisplay(float value)
    {
        Vector2 scale = this.healthBar.GetComponent<RectTransform>().localScale;

        this.healthBar.GetComponent<RectTransform>().localScale = new Vector3(value, 1.0f, 1.0f);

        UnityEngine.UI.Image image = this.healthBar.GetComponent<UnityEngine.UI.Image>();

        image.color = this.colour.Evaluate(1.0f - value);



    }
}
