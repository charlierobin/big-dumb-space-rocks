using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

using UnityEngine.UI;

public class ButtonHighlight : MonoBehaviour, IPointerEnterHandler
{
    public GameObject highlightPrefab;
    public GameObject parentTo;

    private GameObject highlight;

    private bool isEnabled = true;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.highlight == null && this.isEnabled)
        {
            this.highlight = Instantiate(this.highlightPrefab, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);

            this.highlight.transform.SetParent(this.parentTo.transform);

            this.highlight.transform.SetSiblingIndex(0);
        }
    }

    private void disable()
    {
        this.isEnabled = false;

        //this.GetComponent<Button>().interactable = false;
    }

    private void enable()
    {
        this.isEnabled = true;

        //this.GetComponent<Button>().interactable = true;
    }

}

