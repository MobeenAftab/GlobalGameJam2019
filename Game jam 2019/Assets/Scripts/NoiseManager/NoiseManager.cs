using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseManager : MonoBehaviour
{
    public float noiseLevel = 0.0f;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("NoiseManager Awake");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateNoise(float updateNoise)
    {
        this.noiseLevel += updateNoise;
        Debug.Log("Noise Manager: " + noiseLevel);
    }
}
