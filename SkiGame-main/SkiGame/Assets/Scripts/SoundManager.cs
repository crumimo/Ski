using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip sound;

    public void PlayHitSound()
    {
        soundSource.PlayOneShot(sound);
    }

    private void OnEnable()
    {
        PLayerEvents.playerHitEvent += PlayHitSound;
    }

    private void OnDisable()
    {
        PLayerEvents.playerHitEvent -= PlayHitSound;
    }
}
