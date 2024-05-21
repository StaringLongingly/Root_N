using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public Animator MenuAnimator;
    public AudioSource startsound;

    void Start ()
    {
        Application.targetFrameRate = 240;
        startsound = gameObject.GetComponent<AudioSource>();
        MenuAnimator = gameObject.GetComponent<Animator>();
    }

    public void LoadTrigger ()
    {
        MenuAnimator.SetTrigger("trigger");
    }

    public void LoadGame ()
    {
        SceneManager.LoadScene("MainLevel1");
    }

    public void LoadSound ()
    {
        startsound.Play(0);
    }
}
