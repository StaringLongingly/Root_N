using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject pinPrefab2, pinPrefab4, pinPrefab8;
    public bool quotesmaster;
    private int prefablist = 3;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnPin();
            Debug.Log("Spawned Pin!");
        }
    }

    public void LoadIntersection()
    {
        quotesmaster = PlayerPrefs.GetInt("quotesstate") == 1;

        if (quotesmaster)
        {
            SceneManager.LoadScene("Intersection");
        }
        else
        {
            LevelPicker();
        }
    }

    void SpawnPin()
    {
        switch (prefablist)
        {
            case 3:
                Instantiate(pinPrefab2, transform.position, pinPrefab2.transform.rotation);
                break;
            case 2:
                Instantiate(pinPrefab4, transform.position, pinPrefab4.transform.rotation);
                break;
            case 1:
                Instantiate(pinPrefab8, transform.position, pinPrefab8.transform.rotation);
                prefablist += 1;
                break;
            default:
                break;
        }
        prefablist = Mathf.Max(prefablist - 1, 0);
    }

    public void LevelPicker()
    {
        int scenelist = 3;
        int randomscene = Mathf.RoundToInt(UnityEngine.Random.Range(0, scenelist - 1));

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
