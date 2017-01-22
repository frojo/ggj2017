using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayAudioOnCollisionEnter : MonoBehaviour {

    AudioSource audioSource;

    void Start () {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
