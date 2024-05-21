using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;
    public bool isInMainMenu = false;
    public bool levelHasBeenWon = false;
    public float score;
    public float winScore = 5;
    public float thrust = 20f;

    private int globalScore;

    public TextMeshProUGUI scoreText;

    public rotator rotator;
    public Spawner spawner;

    public GameObject hitMarker, winEffect, finishText, rotatorObj, deathSoundObj;
    public Animator deathAnimator, textPop, spawnerAnimator;
    public Rigidbody2D circle1, circle2;
    private AudioSource rotatorSound, restartSound;

    void Start()
    {
        if (!isInMainMenu) rotatorSound = rotatorObj.GetComponent<AudioSource>();
        restartSound = gameObject.GetComponent<AudioSource>();
        globalScore = PlayerPrefs.GetInt("globalscore");
    }

    public void EndGame()
    {
        if (gameHasEnded)
            return;

        rotator.enabled = false;
        spawner.enabled = false;

        bool isDarkmodeToggledOff = PlayerPrefs.GetInt("darkmodestate") == 1;
        if (isDarkmodeToggledOff) deathAnimator.SetTrigger("EndGame");
        else deathAnimator.SetTrigger("EndGameDarkMode");

        gameHasEnded = true;
        Debug.Log("END GAME");
    }

    void Update()
    {
        if (gameHasEnded && Input.GetButtonDown("Fire1"))
        {
            deathAnimator.SetTrigger("RestartGame");
        }
    }

    public void ScoreAdd()
    {
        Debug.LogWarning("ScoreAdd called!");
        if (score < winScore)
        {
            // WHEN A PLAYER SUCCESSFULLY PINS
            score += 1;
            scoreText.text = (winScore - score).ToString();
            textPop.SetTrigger("poptrigger");
            Instantiate(hitMarker, new Vector3(0, 0, 2), transform.rotation);

            // WHEN THE TARGET IS ABOUT TO BREAK
            if (score == winScore)
            {
                finishText.SetActive(true);
            }
        }
        else
        {
            // WHEN THE PLAYER COMPLETES THE LEVEL
            PlayerPrefs.SetInt("globalscore", globalScore + 1);
            Debug.LogWarning(PlayerPrefs.GetInt("globalscore"));

            rotatorSound.Play(0);

            levelHasBeenWon = true;

            rotator.enabled = false;
            spawner.enabled = false;

            circle1.AddForce(transform.right * -thrust);
            circle2.AddForce(transform.right * thrust);

            circle1.gravityScale = 0.2f;
            circle2.gravityScale = 0.2f;

            Instantiate(winEffect, new Vector3(0, 0, 2), transform.rotation);
            spawnerAnimator.SetTrigger("EndGame");
        }
    }

    public void ScoreRemove()
    {
        score -= 1f;
        scoreText.text = (winScore - score).ToString();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartSound()
    {
        restartSound.Play(0);
    }

    public void DeathSound()
    {
        deathSoundObj.SetActive(true);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
