using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public Animator camAnimator;
    public AudioSource menubuttonhit;
    public bool gotPressed = false;

    void Start ()
    {
        GameObject gamemanagerobject =  GameObject.Find("Main Camera").gameObject;
        camAnimator = gamemanagerobject.GetComponent<Animator>();
        menubuttonhit = gameObject.GetComponent<AudioSource>();
    }

    public void LoadTrigger ()
    {
        gotPressed = true;
        camAnimator.SetTrigger("menutrigger");
        menubuttonhit.Play(0);
    }

}
