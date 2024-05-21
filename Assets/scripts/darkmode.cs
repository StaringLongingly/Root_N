using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class darkmode : MonoBehaviour
{
    public Volume volume;
    public AudioSource buttonaudio;
    public bool toggle;

    void Awake ()
    {
        volume = gameObject.GetComponentInChildren<Volume>();
        toggle = PlayerPrefs.GetInt("darkmodestate") == 1 ? true : false;
        volume.enabled = !toggle;
        buttonaudio = gameObject.GetComponent<AudioSource>();
    }

    public void DarkModeToggle ()
    {
        buttonaudio.Play(0);

        toggle = PlayerPrefs.GetInt("darkmodestate") == 1 ? true : false;
        PlayerPrefs.SetInt("darkmodestate", !toggle ? 1 : 0);
        PlayerPrefs.Save();

        volume.enabled = toggle;
    }
}
