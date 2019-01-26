using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Controls controllerinput;

    public float speed;
    public Rigidbody mainBody;
    private Rigidbody handRB;

    private float moveForce = 200.0f;

    public bool trigger;

    void Start()
    {
        handRB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        ForceMovement();
    }

    /// <summary>
    /// Move the object using forces, constant ammount of force applied during transition
    /// </summary>
    private void ForceMovement()
    {
        trigger = controllerinput.leftTrigger;
        if ( trigger && GetComponent<HingeJoint>() == null)
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
            float moveX = controllerinput.leftThumbStickX;
            float moveY = controllerinput.leftThumbStickY;

            if (moveX != 0 || moveY != 0)
            {
                Vector3 movement = (new Vector3(moveX, 0, moveY)).normalized * speed * Time.deltaTime;
                handRB.MovePosition(transform.position + transform.TransformDirection(movement));
            }
        }
    }
}
