using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class currentlvltext : MonoBehaviour
{
    public TextMeshProUGUI textmp;
    void Start()
    {
        textmp = gameObject.GetComponent<TextMeshProUGUI>();
        float lvlscore = PlayerPrefs.GetInt("globalscore");
        textmp.text = lvlscore.ToString();
    }

}
