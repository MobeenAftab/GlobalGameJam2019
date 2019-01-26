using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{

    public bool grabbing;
    public HingeJoint joint;
    public Controls input;

    Collision collision;
    Rigidbody rb;

    void Start()
    {
        grabbing = false;
        joint = GetComponent<HingeJoint>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Only grab stuff when player is holding button
        if (input.leftTrigger || input.rightTrigger)
        {
            grabbing = true;
        }
        else
        {
            grabbing = false;
            if (joint != null)
            {
                if (joint.connectedBody != null)
                {
                    Vector3 throwDirection = joint.connectedBody.transform.position - transform.position;
                    throwDirection.Normalize();
                    joint.connectedBody.AddForce(50.0f * throwDirection);


                }

                Destroy(joint);
            }
        }

        if (grabbing)
        {
            if (joint == null)
            {
                if (collision != null)
                {
                    if (collision.rigidbody != null &&
                        ((collision.rigidbody.transform.position - transform.position).magnitude < 3.0f
                        || collision.gameObject.CompareTag("Level")))
                    {
                        gameObject.AddComponent<HingeJoint>();
                        joint = GetComponent<HingeJoint>();
                        joint.connectedBody = collision.rigidbody;
                    }
                }
            }
        }
    }

    void OnCollisionEnter(Collision c)
    {
        collision = c;
    }
}
