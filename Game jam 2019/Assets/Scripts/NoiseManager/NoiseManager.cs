﻿/*
 * This class is a global object in the scene.
 * Its purpose is for onjects that make a sound to update the current sound level and track it.
 * if the noise gets too loud end the game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NoiseManager : MonoBehaviour
{
    public float noiseLevel = 0.0f;
    public Slider fun;
    public Slider Noise;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("NoiseManager Awake");
        //StartCoroutine("LoseTime");
        //fun.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        // DO this in the update function
        CheckNoiseLevel();
        // UpdateNoise(10.0f); Testing purposes only
    }

    public void UpdateNoise(float updateNoise)
    {
        this.noiseLevel += updateNoise;
        Debug.Log("Noise Manager: " + noiseLevel);
    }

    private void CheckNoiseLevel()
    {
        if (noiseLevel > 100.0f)
        {
            Debug.Log("Noise Level Is To Highh!" + noiseLevel);
            SceneManager.LoadScene(3);
        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            fun.value -= 0.01f;
            Debug.Log(fun.value);
            Noise.value -= 0.7f;
        }
    }
}
