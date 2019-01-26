using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Controls controllerinput;

    public float speed;
    public Rigidbody mainBody;
    private Rigidbody handRB;

    private float moveForce = 500.0f;

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
        trigger = controllerinput.leftTrigger || controllerinput.rightTrigger;
        HingeJoint joint = GetComponent<HingeJoint>();
        if ( trigger 
            && joint != null 
            && joint.connectedBody != null 
            && joint.connectedBody.gameObject.CompareTag("Level") )
        {
            Vector3 moveDir = handRB.transform.position - mainBody.transform.position;
            //if(moveDir.magnitude > 0.0f)
            //{
                moveDir.Normalize();
                mainBody.AddForce(moveDir * moveForce);
            //}
            
        }else
        {
            //Use GetAxisRaw instead of GetAxis because GetAxis is smoothed and causes overshooting when moving
            float moveX = 0.0f;
            float moveY = 0.0f;

            if (controllerinput.playerController == Controls.Controller.Player1)
            {
                moveX = controllerinput.leftThumbStickY * -1;
                moveY = controllerinput.leftThumbStickX;
            }else
            {
                moveX = controllerinput.rightThumbStickY * -1;
                moveY = controllerinput.rightThumbStickX;
            }



            if (moveX != 0 || moveY != 0)
            {
                Vector3 movement = (mainBody.transform.right * moveX + 
                    mainBody.transform.forward * moveY).normalized * speed * Time.deltaTime;
                handRB.MovePosition(transform.position + movement);
            }
        }
    }
}
