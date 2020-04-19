using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetButtonColours : MonoBehaviour
{
    private void Awake()
    {
        Button button = this.GetComponent<Button>();

        ColorBlock block = button.colors;

        block.highlightedColor = ColourLibrary.Instance.lookup("highlighted");

        button.colors = block;


    }
}
