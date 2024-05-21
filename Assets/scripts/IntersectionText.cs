using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IntersectionText : MonoBehaviour
{
    private float textlist = 8;
    private float scenelist = 3;

    public bool isquotesstage;
    public bool quotesToggledOn;

    void Awake()
    { 
        quotesToggledOn = PlayerPrefs.GetInt("quotesstate") == 1;
        if (!quotesToggledOn) LevelPicker();
    }

    void Start()
    {
        TextMeshProUGUI tmp = GetComponent<TextMeshProUGUI>();

        if (isquotesstage)
        {
            float randomtext = Mathf.Round(UnityEngine.Random.Range(0, textlist - 1));
            switch (randomtext)
            {
                case 7:
                    tmp.text = "The world's freedom starts where yours ends.";
                    break;
                case 6:
                    tmp.text = "The end of the beginning is only the beginning of the end.";
                    break;
                case 5:
                    tmp.text = "There is no end though there is a start in space.";
                    break;
                case 4:
                    tmp.text = "Nothing is everything, but everything isn't nothing.";
                    break;
                case 3:
                    tmp.text = "Only the person who has wisdom can read the most foolish one from history.";
                    break;
                case 2:
                    tmp.text = "There are more possibilities in life than stars in the universe.";
                    break;
                case 1:
                    tmp.text = "In the end, everything returns to nothing and then back to anything.";
                    break;
                case 0:
                    tmp.text = "It keeps moving; it never ends.";
                    break;
            }
        }
        else
        {
            tmp.text = "Level " + PlayerPrefs.GetInt("globalscore");
        }
    }

    void LoadMain()
    {
        if (isquotesstage)
        {
            // load intersection2, which loads the next level
            SceneManager.LoadScene("Intersection2");
        }
        else
        {
            LevelPicker();
        }
    }

    public void LevelPicker()
    {
        float randomscene = Mathf.Round(UnityEngine.Random.Range(0, scenelist - 1));

        switch (randomscene)
        {
            case 2:
                SceneManager.LoadScene("MainLevel3");
                break;
            case 1:
                SceneManager.LoadScene("MainLevel2");
                break;
            case 0:
                SceneManager.LoadScene("MainLevel1");
                break;
        }
    }
}
