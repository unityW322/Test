using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New settings", menuName = "Scriptables/Settings", order = 1)]
public class Settings : ScriptableObject
{
    [SerializeField] private bool soundOn;

    public bool SoundOn
    {
        get => soundOn;
        set
        {
            PlayerPrefs.SetInt(Constants.SOUND_SETTING, Convert.ToInt32(value));
            soundOn = value;
        }
    }
}