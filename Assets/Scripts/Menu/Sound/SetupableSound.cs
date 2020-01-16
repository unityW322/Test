using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SetupableSound : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    
    public void SetVolumeState(bool state)
    {
        source.volume = Convert.ToInt32(state);
    }
}
