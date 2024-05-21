using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkmodeColorChange : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        bool isDarkmodeToggledOff = PlayerPrefs.GetInt("darkmodestate") == 1;
        if (!isDarkmodeToggledOff) 
        {
            Color newColor = Color.white - spriteRenderer.color;
            newColor.a = spriteRenderer.color.a;
            spriteRenderer.color = newColor;
        }
    }
}
