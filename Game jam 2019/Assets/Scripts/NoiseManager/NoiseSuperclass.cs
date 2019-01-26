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

public class NoiseSuperclass : MonoBehaviour
{
    public float NoiseInc { get; set; } = 5.0f;
    private bool isCollision = false;

    public NoiseManager noiseM;

    void Start()
    {
        noiseM = GameObject.Find("NoiseManager").GetComponent<NoiseManager>();
        Debug.Log("YEYEY: " + noiseM.noiseLevel);
    }

    public void OnCollisionEnter(Collision collision)
    {
        noiseM.UpdateNoise(NoiseInc);
        Debug.Log("NoiseTest" + collision + "\t" + collision.gameObject.tag);
        Debug.Log("Collision Position: " + collision.transform.position);
    }

    /// <summary>
    /// Reduce the noise level every second or so
    /// </summary>
    void FixedUpdate()
    {
    }




}
