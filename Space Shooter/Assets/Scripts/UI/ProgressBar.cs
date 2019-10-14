using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Transform bar;
    public Text text;

    public enum ProgressBarType
    {
        HORIZONTAL,
        VERTICAL
    }
    public ProgressBarType type;
    public bool wholeValue = true;

    public void SetValue(int value, int maxValue)
    {
        SetValue(value, maxValue);
    }

    public void SetValue(float value, float maxValue)
    {
        SetValue(value / maxValue);
        if (wholeValue)
            text.text = Mathf.Round(value) + " / " + Mathf.Round(maxValue);
        else
            text.text = Mathf.Round(value / maxValue * 100).ToString();
    }

    public void SetValue(float ratio)
    {
        if (type == ProgressBarType.HORIZONTAL)
            bar.localScale = new Vector3(ratio, 1f, 1f);
        else
            bar.localScale = new Vector3(1f, ratio, 1f);
    }
}
