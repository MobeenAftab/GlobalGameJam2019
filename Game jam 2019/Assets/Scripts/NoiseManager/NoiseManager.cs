using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        //Noise.value += 0.5f;

    }

    public void UpdateNoise(float updateNoise)
    {
        this.noiseLevel += updateNoise;
        Debug.Log("Noise Manager: " + noiseLevel);
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
