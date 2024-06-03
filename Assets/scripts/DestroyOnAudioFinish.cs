using System.Collections;
using UnityEngine;

public class DestroyOnAudioFinish : MonoBehaviour
{
    private bool _audioPlaying;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        StartCoroutine(WaitForAudioComplete());
    }

    private IEnumerator WaitForAudioComplete()
    {
        while (_audioPlaying == false)
        {
            if (_audioSource.isPlaying)
            {
                _audioPlaying = true;
            }

            yield return null;
        }

        while (_audioSource.isPlaying && Time.timeScale > 0f)
        {
            yield return null;
        }

        Destroy(gameObject);

        yield return null;
    }
}