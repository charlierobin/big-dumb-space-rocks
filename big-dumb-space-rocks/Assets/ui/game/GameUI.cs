using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : Singleton<GameUI>
{
    public GameObject dynamicString;

    private void UpdateScoreDisplay(int value)
    {
        this.dynamicString.GetComponent<DynamicString>().set(value);
    }

    public GameObject healthBar;
    public Gradient colour;

    private void UpdateHealthBar(float value)
    {
        Vector2 scale = this.healthBar.GetComponent<RectTransform>().localScale;

        this.healthBar.GetComponent<RectTransform>().localScale = new Vector3(value, 1.0f, 1.0f);

        UnityEngine.UI.Image image = this.healthBar.GetComponent<UnityEngine.UI.Image>();

        image.color = this.colour.Evaluate(1.0f - value);
    }

    public GameObject shieldBar;

    private void UpdateShieldBar(float value)
    {
        Vector2 scale = this.shieldBar.GetComponent<RectTransform>().localScale;

        this.shieldBar.GetComponent<RectTransform>().localScale = new Vector3(value, 1.0f, 1.0f);

        UnityEngine.UI.Image image = this.shieldBar.GetComponent<UnityEngine.UI.Image>();

        image.color = this.colour.Evaluate(1.0f - value);
    }

    public GameObject rateOfFireBar;

    private void UpdateRateOfFireBar(float value)
    {
        Vector2 scale = this.rateOfFireBar.GetComponent<RectTransform>().localScale;

        this.rateOfFireBar.GetComponent<RectTransform>().localScale = new Vector3(value, 1.0f, 1.0f);
    }

    public GameObject bulletPowerBar;

    private void UpdateBulletPowerBar(float value)
    {
        Vector2 scale = this.bulletPowerBar.GetComponent<RectTransform>().localScale;

        this.bulletPowerBar.GetComponent<RectTransform>().localScale = new Vector3(value, 1.0f, 1.0f);
    }

    public GameObject multiShotDisplay;

    private void UpdateMultiShotCount(int count)
    {
        this.multiShotDisplay.GetComponent<MultiShotUI>().set(count);
    }

    public GameObject bigBoomDisplay;

    private void UpdateBigBoomCount(int count)
    {
        this.bigBoomDisplay.GetComponent<BigBoomUI>().set(count);
    }

    public GameObject superfastDisplay;
    public GameObject superfastBar;

    private void SuperFastEnabled()
    {
        this.superfastDisplay.SetActive(true);
    }

    private void SuperFastDisabled()
    {
        this.superfastDisplay.SetActive(false);
    }

    private void UpdateSuperFastBar(float value)
    {
        Vector2 scale = this.superfastBar.GetComponent<RectTransform>().localScale;

        this.superfastBar.GetComponent<RectTransform>().localScale = new Vector3(value, 1.0f, 1.0f);
    }

}

