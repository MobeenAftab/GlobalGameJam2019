/*
 * Interface that all object that make noise must implement.
 *  Must implement three properties:
 *  noise value of object.
 *  get player object.
 *  update player object noise level
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoiseSuperclass : MonoBehaviour
{
    public float NoiseInc  = 5.0f;

    public NoiseManager noiseM;   

    void Start()
    {
        //Debug.Log("Make Noise SuperClass");
        noiseM = GameObject.Find("NoiseManager").GetComponent<NoiseManager>();
        //Debug.Log("YEYEY: " + noiseM.noiseLevel);
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("AAAAAAAAAAAAAAAA");
            noiseM.UpdateNoise(NoiseInc);
            Debug.Log("NoiseTest" + collision + "\t" + collision.gameObject.tag);
            Debug.Log("Collision Position: " + collision.transform.position);
        }
       
    }

    public void AddNoise(float NoiseInc)
    {
        Debug.Log("AAA");
        noiseM.UpdateNoise(NoiseInc);
        Debug.Log("AddNoise: " + noiseM.noiseLevel);
    }

    /// <summary>
    /// Reduce the noise level every second or so
    /// </summary>

    void Update()
    {


    }


}
