using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingLoad : MonoBehaviour
{
    public SettingsData masterSettings;
    public Slider Brightness;
    public Slider Volumn;

    // Start is called before the first frame update
    void Start()
    {
        SerilizedSettings loadedsettings = masterSettings.LoadSettings();
        if(loadedsettings == null)
        {
            Brightness.value = Brightness.maxValue;
            Volumn.value = Volumn.maxValue;
        }
        else
        {
            Brightness.value = loadedsettings.Brightness;
            Volumn.value = loadedsettings.Volumn;
        }
    }



   
}
