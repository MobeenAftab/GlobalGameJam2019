using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // ArrowMovement();
        ForceMovement();
    }

    /// <summary>
    /// Move the object using forces, constant ammount of force applied during transition
    /// </summary>
    private void ForceMovement()
    {
        //Use GetAxisRaw instead of GetAxis because GetAxis is smoothed and causes overshooting when moving
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveX != 0 || moveY != 0) {
            Vector3 movement = (new Vector3(moveX, 0, moveY)).normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + transform.TransformDirection(movement));
        }
    }

    /// <summary>
    /// Move game object based on Transform position
    /// </summary>
    private void ArrowMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
    }
}
