using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject pinPrefab2, pinPrefab4, pinPrefab8;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Transform childTransform;
    public bool gameHasEnded = false;
    private int prefablist = 3;
    public int winScore = 5;
    public int objectsEntered = 0;
    public GameObject hiteffect;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !gameHasEnded)
        {
            SpawnPin();
            //Debug.Log("Spawned Pin!");
        }
    }

    public void LoadIntersection()
    {
        if (PlayerPrefs.GetInt("quotesstate") == 1)
        {
            Debug.Log("Loading Intersection1..");
            SceneManager.LoadScene("Intersection1");
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
                Instantiate(pinPrefab2, childTransform.position, pinPrefab2.transform.rotation);
                break;
            case 2:
                Instantiate(pinPrefab4, childTransform.position, pinPrefab4.transform.rotation);
                break;
            case 1:
                Instantiate(pinPrefab8, childTransform.position, pinPrefab8.transform.rotation);
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
        int randomscene = UnityEngine.Random.Range(0, scenelist);
        Debug.Log("New Level: " + randomscene);
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

    public void OnTriggerEnter2D(Collider2D col)
    {
        audioSource.PlayOneShot(audioClip, new Vector2(-0.2f, 0.2f));
        childTransform.gameObject.GetComponent<Animator>().SetTrigger("EndGame");
        Instantiate(hiteffect, col.ClosestPoint(transform.position) - new Vector2(0, 2), transform.rotation);
        objectsEntered++;
        Debug.Log("Objects entered: " + objectsEntered);
        if (objectsEntered >= winScore + 3) StartCoroutine(PickLevel()); 
    }

    IEnumerator PickLevel()
    {
        yield return new WaitForSeconds(0.5f);
        LoadIntersection(); 
    }
}

public static class AudioSourceHelper
{
    public static void PlayOneShot(this AudioSource audioSource, AudioClip clip, Vector2 pitchRange, float volumeScale = 1.0f)
    {
        // Instantiate a duplicate of the original audiosource gameobject
        GameObject newGo = GameObject.Instantiate(audioSource.gameObject);
        // Ensure positions are matched
        newGo.transform.position = audioSource.transform.position;
        AudioSource oneShot = newGo.GetComponent<AudioSource>();

        if (oneShot != null)
        {
            newGo.AddComponent<DestroyOnAudioFinish>();

            oneShot.clip = clip;
            oneShot.volume *= volumeScale;
            oneShot.pitch = Random.Range(pitchRange.x, pitchRange.y);
            oneShot.Play();
        }
        else
        {
            GameObject.Destroy(newGo);
        }
    }
}
