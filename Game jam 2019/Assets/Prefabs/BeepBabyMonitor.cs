using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeepBabyMonitor : MonoBehaviour
{
    private NoiseSuperclass noiseSuper;
    private AudioSource  beepNoise;
    public bool detectPlayer;
    private SphereCollider sCollider;
    private bool isBeep, playerProxy;

    // Start is called before the first frame update
    void Start()
    {
        beepNoise = GetComponent<AudioSource>();
        noiseSuper = FindObjectOfType<NoiseSuperclass>();
        isBeep = false;

        //StartCoroutine(Beeper());
        sCollider = GetComponent<SphereCollider>();

    }

    // Update is called once per frame
   void OnTriggerEnter(Collider sCollider)
    {
        if (sCollider.CompareTag("Player"))
        {
            playerProxy = true;
        }


        StartCoroutine(Beeper());
        //Debug.Log("AAAAAAA");
    }

    void OnTriggerExit(Collider sCollider)
    {
        playerProxy = false;
    }

    public IEnumerator Beeper()
    {
        if(isBeep == false && playerProxy == true)
        {
            isBeep = true;
            beepNoise.Play();
            yield return new WaitForSeconds(1.0f);
            isBeep = false;
           // noiseSuper.AddNoise(10.0f);            //add AUDIO NOISE CODE!
           // Debug.Log(noiseSuper.NoiseInc + "AAAAAAAAAAAAAAAAAa");

            StartCoroutine(Beeper());
        }
    }

}
