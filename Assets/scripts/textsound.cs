using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textsound : MonoBehaviour
{
    private AudioSource audiotext;

    void Start()
    {
        audiotext = gameObject.GetComponent<AudioSource>();
    }

    public void AudioPlay()
    {
        audiotext.Play(0);
    }

}
