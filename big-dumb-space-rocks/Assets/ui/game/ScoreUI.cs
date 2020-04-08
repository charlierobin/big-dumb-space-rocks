using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private void UpdateScoreDisplay(int value)
    {
        this.GetComponent<DynamicString>().set(value);
    }
}
