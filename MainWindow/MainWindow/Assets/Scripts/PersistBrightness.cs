using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PersistBrightness : MonoBehaviour
{
    public SettingsData settings;
    public static GameObject BrightnessObject;



    // Start is called before the first frame update
    void Awake()
    {
        if(BrightnessObject != null)
            {
                 Destroy(gameObject);
        }
        else
        {
            BrightnessObject = gameObject;
        }
        DontDestroyOnLoad(gameObject);
        if(settings.BrightnessImage == null)
        {
            settings.BrightnessImage = transform.GetChild(0).GetComponent<Image>();
        }
    }

  
}
