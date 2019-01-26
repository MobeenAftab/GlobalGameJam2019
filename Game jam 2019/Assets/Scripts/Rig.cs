using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rig : MonoBehaviour
{
    public Transform otherTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (otherTransform != null)
        {
            transform.position = otherTransform.position;
        }
    }
}
