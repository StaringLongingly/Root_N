using System.Collections;
using System.Runtime.Serialization;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private bool isPinned = false;
    public float speed = 20f;
    public float hitspeedmin = 20f;
    public float hitspeedmax = 80f;
    public Rigidbody2D rb;
    public GameManager gameManager;
    public bool alive = true;
    public AudioSource audioping;

    void Start()
    {
        audioping = GetComponent<AudioSource>();
        GameObject gamemanagerobject = GameObject.Find("Main Camera");
        gameManager = gamemanagerobject.GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        if (!isPinned) rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
        if (gameManager.levelHasBeenWon)
        {
            rb.isKinematic = false;
            rb.gravityScale = 0.2f;
            gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (gameManager.levelHasBeenWon) return;
        Transform parentTransform = col.transform;

        if (col.tag == "Pin")
        {
            alive = false;
            //Debug.Log("Touched Pin!");
            PlayerPrefs.SetInt("globalscore", 1);
            PlayerPrefs.Save();
            // END GAME
            if (!isPinned)
            {
                gameManager.ScoreRemove();
            }
            gameManager.DeathSound();
            gameManager.EndGame();
        }
        else if (col.tag == "Rotator" && !isPinned && alive)
        {
            //Debug.Log("Touched Rotator");
            audioping.Play(0);
            parentTransform.GetComponentInParent<rotator>().speed += Random.Range(hitspeedmin, hitspeedmax);
            gameManager.ScoreAdd();
        }
        isPinned = true;
        transform.SetParent(parentTransform);
    }
}
