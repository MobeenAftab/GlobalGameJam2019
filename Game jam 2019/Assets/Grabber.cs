using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{

    public bool grabbing;
    public HingeJoint joint;

    Collision collision;

    void Start()
    {
        grabbing = false;
        joint = GetComponent<HingeJoint>();
    }

    void Update()
    {
        //Only grab stuff when player is holding button
        if (Input.GetButton("Jump"))
        {
            grabbing = true;
        }
        else
        {
            grabbing = false;
            if(joint != null)
            {
                if(joint.connectedBody != null)
                {
                    joint.connectedBody.AddForce(100.0f * joint.connectedBody.velocity);
                }

                Destroy(joint);
            }
        }

        if (grabbing)
        {
            if (joint == null)
            {
                gameObject.AddComponent<HingeJoint>();
                joint = GetComponent<HingeJoint>();
                joint.connectedBody = collision.rigidbody;
            }
        }
    }

    void OnCollisionEnter(Collision c)
    {
        collision = c;
    }
}
