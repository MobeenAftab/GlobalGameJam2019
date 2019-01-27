using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : MonoBehaviour
{
    //TEST SCRIPT: For messing around in editor
    //NOT FOR GAME
    Rigidbody rb;

    float speed = 0.5f;
    float timer = 0.0f;

    readonly float jumpTime = 1.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position += speed * transform.forward * Input.GetAxis("Vertical");
        transform.Rotate(transform.up, Input.GetAxis("Horizontal") * 2.0f);

        if (timer < 0.0f)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(transform.up * 6.0f, ForceMode.Impulse);
                timer = jumpTime;
            }
        }else
        {
            timer -= Time.deltaTime;
        }

    }
}
