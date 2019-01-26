using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : MonoBehaviour
{
    //TEST SCRIPT: For messing around in editor
    //NOT FOR GAME


    void Update()
    {
        transform.position += 0.1f * new Vector3(
            Input.GetAxis("Horizontal"),
            0.0f,
            Input.GetAxis("Vertical")
            );
    }
}
