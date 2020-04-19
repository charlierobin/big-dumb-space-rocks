using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreenController : MonoBehaviour
{
    public void Show()
    {
        this.transform.Find("content").gameObject.SetActive(true);

        this.gameObject.GetComponentInChildren<FadeIn>().Begin();
    }

    public void Hide()
    {
        this.gameObject.GetComponentInChildren<FadeOut>().Begin();
    }
}
