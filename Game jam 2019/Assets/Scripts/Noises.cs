using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noises : MonoBehaviour
{

    public AudioClip[] audioClips;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("CheckTimePassed", 0f, 5f);
    }

    void CheckTimePassed()
    {
        int Probability = Random.Range(0, 100);
        if (Probability > 60)
        {
            int idx = Random.Range(0, audioClips.Length);
            audioSource.clip = audioClips[idx];
            audioSource.Play();
        }
        
    }
}
