using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSFX : MonoBehaviour
{
    public AudioSource audioSrc;

    void Start()
    {
        audioSrc = this.GetComponents<AudioSource>()[1];
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyBinds.DownArr) || Input.GetKeyDown(KeyBinds.DownS))
        {
            audioSrc.Play();
        }
        else if (Input.GetKeyDown(KeyBinds.upW) || Input.GetKeyDown(KeyBinds.UpArr))
        {
            audioSrc.Play();
        }

    }
}
