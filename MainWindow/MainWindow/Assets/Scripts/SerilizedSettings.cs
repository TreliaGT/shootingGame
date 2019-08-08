using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerilizedSettings
{
    float brightness = 0;


    float volumn = 0;

    public float Brightness
    {
        get{
            return brightness;
        }
    }

    public float Volumn
    {
        get
        {
            return volumn;
        }
    }

    public SerilizedSettings(float _brightness , float _volumn)
    {
        brightness = _brightness;
        volumn = _volumn;
    }

    public SerilizedSettings()
    {
    }
}
