/*
 * Interface test for objects that make a noise.
 * Must implement three properties:
 *  noise value.
 *  get player object.
 *  update player object noise level
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseTest : MonoBehaviour
{
    private float noiseIncrement = 5.0f;
    public NoiseManager nm;

    // Start is called before the first frame update
    void Start()
    {
        //nm = GetComponent<NoiseManager>();
        nm = GameObject.Find("NoiseManager").GetComponent<NoiseManager>();


        //nm.UpdateNoise(noiseIncrement);
        Debug.Log("YEYEY: "+ nm.noiseLevel);
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnCollisionEnter(Collision collision)
    {
        nm.UpdateNoise(noiseIncrement);
        Debug.Log("NoiseTest" + collision + "\t" + collision.gameObject.tag);
        Debug.Log("Collision Position: " + collision.transform.position);

         //.SendMessage("UpdateNoise", noiseIncrement);
    }
}
