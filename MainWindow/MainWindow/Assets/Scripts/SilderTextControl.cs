using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilderTextControl : MonoBehaviour
{
    public Slider mySilder;
    public Text MyText;
    public int multipler = 100;

    public void UpdateText(float value)
    {
        float Fraction = value - mySilder.minValue / (mySilder.maxValue - mySilder.minValue);
        MyText.text = Mathf.FloorToInt(Fraction * multipler).ToString();
    }
}
