using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[CreateAssetMenu()]
public class SettingsData : ScriptableObject
{
    [Header ("General")]
    public string fileName = "/Settings.dat";

    [Header ("Brightness")]
    public Image BrightnessImage;
    public float Brightness = 1;

    [Header("Volumn")]
    public AudioMixer AudioMix;
    public float MaxAudio = 0f;
    public float MinAudio = -80f;
    public float masterVolumn = 1;

    public void UpdateBrightness(float value)
    {
      
        Brightness = value;
        float buffer = 1 - Brightness;
        BrightnessImage.color = new Color(BrightnessImage.color.r, BrightnessImage.color.g, BrightnessImage.color.b, buffer);

    }

    public void UpdateVolumn(float value)
    {
        masterVolumn = value;
        float Range = MaxAudio - MinAudio; //80
        float VolumnLevel = Range * masterVolumn;
        VolumnLevel = MinAudio + VolumnLevel;
        AudioMix.SetFloat("masterVolumn", VolumnLevel);
    }

    public void SaveSetting()
    {
        BinaryFormatter B = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + fileName);
        SerilizedSettings settingstosave = new SerilizedSettings(Brightness , masterVolumn);
        B.Serialize(file, settingstosave);
        file.Close();
    }

    public SerilizedSettings LoadSettings()
    {
        SerilizedSettings loadedSettings = new SerilizedSettings();
        if (File.Exists(Application.persistentDataPath + fileName)){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + fileName, FileMode.Open);
            loadedSettings = bf.Deserialize(file) as SerilizedSettings;
            file.Close();
        }
        return loadedSettings;
    }

}
