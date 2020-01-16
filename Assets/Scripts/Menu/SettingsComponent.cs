using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsComponent : MonoBehaviour
{
    [SerializeField] private Settings settings;
    [SerializeField] private SoundManager soundManager;

    [SerializeField] private Image onImageEnabled;
    [SerializeField] private Image offImageEnabled;

    public enum ButtonType { On, Off }

    private void Start()
    {
        soundManager.SetVolume(settings.SoundOn);

        gameObject.SetActive(false);
    }

    public void SwitchSoundTo(bool state)
    {
        settings.SoundOn = state;

        soundManager.SetVolume(settings.SoundOn);
    }

    public void ToggleOffSprite()
    {
        onImageEnabled.enabled = !onImageEnabled.enabled;
    }

    public void ToggleOnSprite()
    {
        offImageEnabled.enabled = !offImageEnabled.enabled;
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}
