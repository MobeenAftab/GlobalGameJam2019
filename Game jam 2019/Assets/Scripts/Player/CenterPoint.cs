/**
 * Class Purpose: This class is assigned to the empty game object of the player object. The camera will focus and follow this
 * objects transform over the player.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPoint : MonoBehaviour
{
    public Transform pos;

    void FixedUpdate()
    {
        transform.position = pos.position;
    }
}
