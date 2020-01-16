using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private List<SetupableSound> sources;
    
    public void SetVolume(bool state)
    {
        foreach (SetupableSound source in sources)
            source.SetVolumeState(state);
    }
}
