using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody mainBody;
    private Rigidbody handRB;

    private float moveForce = 200.0f;

    void Start()
    {
        handRB = GetComponent<Rigidbody>();
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
        if (Input.GetButton("Jump") && GetComponent<HingeJoint>() == null)
        {
            Vector3 moveDir = handRB.transform.position - mainBody.transform.position;
            if(moveDir.magnitude > 2.0f)
            {
                moveDir.Normalize();
                mainBody.AddForce(moveDir * moveForce);
            }
            
        }else
        {
            //Use GetAxisRaw instead of GetAxis because GetAxis is smoothed and causes overshooting when moving
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            if (moveX != 0 || moveY != 0)
            {
                Vector3 movement = (new Vector3(moveX, 0, moveY)).normalized * speed * Time.deltaTime;
                handRB.MovePosition(transform.position + transform.TransformDirection(movement));
            }
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
