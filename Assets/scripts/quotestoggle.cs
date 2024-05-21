using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class quotestoggle : MonoBehaviour
{
    public bool toggledOn;
    public TextMeshProUGUI quotesText;
    public Animator animator;
    public AudioSource buttonaudio;

    
    void Start()
    { 
        toggledOn = PlayerPrefs.GetInt("quotesstate") == 1 ? true : false;
        buttonaudio = gameObject.GetComponent<AudioSource>();
        changeQuotesText();
    }

    void changeQuotesText()
    {
        if (toggledOn) quotesText.text = "Slow Mode";
        else quotesText.text = "Fast Mode";
    }

    public void QuotesToggle ()
    {
        animator.SetTrigger("Changed Mode");
        buttonaudio.Play(0);
        toggledOn = !toggledOn;
        changeQuotesText();
        PlayerPrefs.SetInt("quotesstate", toggledOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
