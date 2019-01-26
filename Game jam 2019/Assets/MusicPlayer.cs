using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip intro;
    public AudioSource source;
    public AudioClip loop;
    
    // Start is called before the first frame update
    void Start()
    {
        source.clip = intro;
        source.Play();
      //  intro.Play();
      //  loop.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (source.isPlaying)
        {

        }
        else
        {
            source.clip = loop;
            source.Play();
        }
    }
}
